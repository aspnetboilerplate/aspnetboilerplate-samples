using GraphQL;
using GraphQL.Types;

namespace Hotel.Web.Host.GraphQL
{
    public class HotelSchema : Schema
    {
        public HotelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<HotelQuery>();
        }
    }
}
