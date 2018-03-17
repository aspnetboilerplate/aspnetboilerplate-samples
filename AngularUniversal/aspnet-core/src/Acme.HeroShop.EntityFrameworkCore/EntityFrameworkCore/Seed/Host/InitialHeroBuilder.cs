using Acme.HeroShop.Heros;
using System.Linq;

namespace Acme.HeroShop.EntityFrameworkCore.Seed.Host
{
    public class InitialHeroBuilder
    {
        private readonly HeroShopDbContext _context;

        public InitialHeroBuilder(HeroShopDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            if (!_context.HeroCompanies.Any(e=> e.Name == "Marvel Studios"))
            {
                var marvel = new HeroCompany
                {
                    Name = "Marvel Studios"
                };

                _context.HeroCompanies.Add(marvel);
                _context.SaveChanges();

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Spider-Man"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Hulk"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Iron Man"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Captain America"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Thor"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Black Widow"
                });
            }

            if (!_context.HeroCompanies.Any(e => e.Name == "DC Comics"))
            {
                var marvel = new HeroCompany
                {
                    Name = "DC Comics"
                };

                _context.HeroCompanies.Add(marvel);
                _context.SaveChanges();

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Batman"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Green Lantern"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Aquaman"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Superman"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "Wonder Woman"
                });

                _context.Heroes.Add(new Hero
                {
                    HeroCompanyId = marvel.Id,
                    Name = "The Flash"
                });
            }
        }
    }
}
