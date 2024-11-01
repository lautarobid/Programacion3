using Aplication.Models.Request;
using Aplication.Models.Response;
using System.Drawing;

namespace Aplication.Models.Mappings
{
    public class TripMapping
    {
        private readonly BillMapping _billMapping;
        public TripMapping(BillMapping billMapping)
        {
            _billMapping = billMapping;
        }
        public Trip MapToEntity(TripRequest request)
        {
            return new Trip
            {
                StartingPoint = request.StartingPoint,
                Destination = request.Destination,
                DepartureDate = request.DepartureDate,
                TruckDriverId = request.TruckDriverId,
                ClientId = request.ClientId,
                Bill = _billMapping.MapBillRequestToEntity(request.Bill)

            };
        }

        public TripResponse MapToResponse(Trip trip)
        {
            return new TripResponse
            {
                Id = trip.Id,
                StartingPoint = trip.StartingPoint,
                Destination = trip.Destination,
                DepartureDate = trip.DepartureDate,
                Bill = _billMapping.MapBillToResponse(trip.Bill)

            };
        }
        public Trip MapToExistingEntity(Trip trip, TripRequest request)
        {
            trip.StartingPoint = request.StartingPoint ?? trip.StartingPoint;
            trip.Destination = request.Destination ?? trip.Destination;
            trip.DepartureDate = request.DepartureDate ?? trip.DepartureDate;
            trip.TruckDriverId = request.TruckDriverId ?? trip.TruckDriverId;
            trip.ClientId = request.ClientId ?? trip.ClientId;
            if (request.Bill != null)
            {
                trip.Bill = _billMapping.UpdateBillFromRequest(trip.Bill, request.Bill);
            }
            return trip;
        }
    }
}
