using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using GraphQL.Types;
using Hotel.Reservations;
using Hotel.Rooms;

namespace Hotel.Web.Host.GraphQL
{
    public class HotelQuery : ObjectGraphType
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public HotelQuery(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;

            Field<ListGraphType<ReservationType>>("reservations",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    },
                    new QueryArgument<DateGraphType>
                    {
                        Name = "checkinDate"
                    },
                    new QueryArgument<DateGraphType>
                    {
                        Name = "checkoutDate"
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "roomAllowedSmoking"
                    },
                    new QueryArgument<RoomStatusType>
                    {
                        Name = "roomStatus"
                    }
                }),
                resolve: InternalResolve
            );
        }

        [UnitOfWork]
        protected virtual List<Reservation> InternalResolve(ResolveFieldContext<object> context)
        {
            var query = _reservationRepository.GetAll();

            var reservationId = context.GetArgument<int?>("id");
            if (reservationId.HasValue)
            {
                return query.Where(r => r.Id == reservationId.Value).ToList();
            }

            var checkinDate = context.GetArgument<DateTime?>("checkinDate");
            if (checkinDate.HasValue)
            {
                return query.Where(r => r.CheckinDate.Date == checkinDate.Value.Date).ToList();
            }

            var checkoutDate = context.GetArgument<DateTime?>("checkoutDate");
            if (checkoutDate.HasValue)
            {
                return query.Where(r => r.CheckoutDate.Date >= checkoutDate.Value.Date).ToList();
            }

            var allowedSmoking = context.GetArgument<bool?>("roomAllowedSmoking");
            if (allowedSmoking.HasValue)
            {
                return query.Where(r => r.Room.AllowedSmoking == allowedSmoking.Value).ToList();
            }

            var roomStatus = context.GetArgument<RoomStatus?>("roomStatus");
            if (roomStatus.HasValue)
            {
                return query.Where(r => r.Room.Status == roomStatus.Value).ToList();
            }

            return query.ToList();
        }
    }
}
