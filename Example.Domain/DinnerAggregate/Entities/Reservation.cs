using Example.Domain.BillAggregate.ValueObjects;
using Example.Domain.Common.Models;
using Example.Domain.DinnerAggregate.Enums;
using Example.Domain.DinnerAggregate.ValueObjects;
using Example.Domain.GuestAggregate.ValueObjects;

namespace Example.Domain.DinnerAggregate.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; }
        public ReservationStatus ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime ArrivalDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Reservation(
            ReservationId id,
            int guestCount,
            ReservationStatus reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime arrivalDateTime,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(
            int guestCount,
            ReservationStatus reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime arrivalDateTime)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                reservationStatus,
                guestId,
                billId,
                arrivalDateTime,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}