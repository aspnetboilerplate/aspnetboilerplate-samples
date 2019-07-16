using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Hotel.Rooms;

namespace Hotel.Web.Host.GraphQL
{
    public class RoomStatusType : EnumerationGraphType<RoomStatus>
    {
    }
}
