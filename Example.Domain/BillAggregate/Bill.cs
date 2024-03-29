using Example.Domain.BillAggregate.ValueObjects;
using Example.Domain.DinnerAggregate.ValueObjects;
using Example.Domain.HostAggregate.ValueObjects;
using Example.Domain.GuestAggregate.ValueObjects;
using Example.Domain.Common.Models;
using Example.Domain.Common.ValueObjects;

namespace Example.Domain.BillAggregate
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Bill(
            BillId id,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price)
        {
            return new(
                BillId.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}