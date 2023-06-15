using RoomBookings.Common.Domain;
using RoomBookings.Rooms.Domain.DomainEvent;

namespace RoomBookings.Rooms.Domain
{
    public class Booking : Entity
    {
        public int UserId { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public int GuestCount { get; }
        public bool IsCancelled { get; private set; }

        private Booking() { }

        public Booking(int userId, DateTime startDate, DateTime endDate, int guestCount)
        {
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            GuestCount = guestCount;

            AddDomainEvent(new RoomBookingCreatedDomainEvent());
        }

        public void Cancel()
        {
            IsCancelled = true;

            AddDomainEvent(new RoomBookingCancelledDomainEvent());
        }
    }
}
