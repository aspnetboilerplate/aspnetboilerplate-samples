using System;
using System.Linq;

namespace StandartTestApp
{
    public static class DbInitializer
    {
        public  static async void Initialize(PersonContext context)
        {
            
            context.Database.EnsureCreated();

            // Look for any Persons.
            if (context.People.Any())
            {
                return;
            }

            var people = new Person[]
            {
                new Person{Name="Carson",PhoneNumber="4875124844"},
                new Person{Name="Meredith",PhoneNumber="4671325896"},
                new Person{Name="Arturo",PhoneNumber="4457813364"},
                new Person{Name="Gytis",PhoneNumber="7948793574"},
                new Person{Name="Yan",PhoneNumber="5876996312"},
                new Person{Name="Peggy",PhoneNumber="4748974512"},
                new Person{Name="Laura",PhoneNumber="7489667894"},
                new Person{Name="Nino",PhoneNumber="4714789451"}
            };
            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
            
        }
    }
}