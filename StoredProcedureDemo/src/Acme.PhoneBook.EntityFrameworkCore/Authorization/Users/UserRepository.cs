using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Data;
using Abp.EntityFrameworkCore;
using Acme.PhoneBook.Authorization.Users.Dtos;
using Acme.PhoneBook.EntityFrameworkCore;
using Acme.PhoneBook.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Acme.PhoneBook.Authorization.Users
{
    public class UserRepository : PhoneBookRepositoryBase<User, long>, IUserRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        public UserRepository(IDbContextProvider<PhoneBookDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        //TODO: Make async!
        public async Task<List<string>> GetUserNames()
        {
            EnsureConnectionOpen();

            using (var command = CreateCommand("GetUsernames", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<string>();

                    while (dataReader.Read())
                    {
                        result.Add(dataReader["UserName"].ToString());
                    }

                    return result;
                }
            }
        }


        public async Task<List<string>> GetAdminUsernames()
        {
            EnsureConnectionOpen();

            using (var command = CreateCommand("SELECT * FROM dbo.UserAdminView", CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<string>();

                    while (dataReader.Read())
                    {
                        result.Add(dataReader["UserName"].ToString());
                    }
                    return result;
                }
            }
        }

        public async Task DeleteUser(EntityDto input)
        {
            await Context.Database.ExecuteSqlCommandAsync(
                "EXEC DeleteUserById @id",
                default(CancellationToken),
                new SqlParameter("id", input.Id)
            );
        }

        public async Task UpdateEmail(UpdateEmailDto input)
        {
            await Context.Database.ExecuteSqlCommandAsync(
                "EXEC UpdateEmailById @email, @id",
                default(CancellationToken),
                new SqlParameter("id", input.Id),
                new SqlParameter("email", input.EmailAddress)
            );
        }

        public async Task<GetUserByIdOutput> GetUserById(EntityDto input)
        {
            EnsureConnectionOpen();
            using (var command = CreateCommand("SELECT dbo.GetUsernameById(@id)", CommandType.Text, new SqlParameter("@id", input.Id)))
            {
                var username = (await command.ExecuteScalarAsync()).ToString();
                return new GetUserByIdOutput() { Username = username };
            }

        }

        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.GetDbConnection().CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        private void EnsureConnectionOpen()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
            {
                {"ContextType", typeof(PhoneBookDbContext) },
                {"MultiTenancySide", MultiTenancySide }
            });
        }
    }
}
