using Acme.SimpleTaskApp.EntityFrameworkCore;
using Acme.SimpleTaskApp.People;
using Acme.SimpleTaskApp.Tasks;

namespace Acme.SimpleTaskApp.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly SimpleTaskAppDbContext _context;

        public TestDataBuilder(SimpleTaskAppDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            var neo = new Person("Neo");
            _context.People.Add(neo);
            _context.SaveChanges();

            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality.", neo.Id),
                new Task("Clean your room") { State = TaskState.Completed }
                );
        }
    }
}