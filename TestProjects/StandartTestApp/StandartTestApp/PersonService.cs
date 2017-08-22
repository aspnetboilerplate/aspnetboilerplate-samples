using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<PersonDto>> GetAllPeople()
        {
            var people = await _context.People.ToListAsync();
            return people.Select(p => new PersonDto { Name = p.Name, Id = p.Id, PhoneNumber = p.PhoneNumber }).ToList();
        }

        public async Task Delete(DeletePersonInput input)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == input.Id);
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

    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
    
    public class DeletePersonInput
    {
        public int Id { get; set; }
    }

    public class InsertAndGetIdInput
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class InsertAndGetIdOutput
    {
        public int Id { get; set; }
    }
}
