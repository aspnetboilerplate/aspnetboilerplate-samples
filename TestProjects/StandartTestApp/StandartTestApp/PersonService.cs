using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StandartTestApp.dto;

namespace StandartTestApp
{
    public class PersonService
    {
        private readonly PersonContext _context;

        public PersonService(PersonContext context)
        {
            _context = context;
        }

        public async Task<InsertAndGetIdOutput> InsertAndGetId(InsertAndGetIdInput input)
        {
            var person = new Person {Name = input.Name, PhoneNumber = input.PhoneNumber};
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return new InsertAndGetIdOutput { Id = person.Id };
        }

        public async Task<List<Person>> GetAllPeople()
        {
            var people = await _context.People.ToListAsync();
            return people;
        }

        public async Task Delete(DeletePersonInput input)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.PhoneNumber == "000000");

            if (person == null)
            {
                return;
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }

        public int GetConstant()
        {
            return 42;
        }
    }
}
