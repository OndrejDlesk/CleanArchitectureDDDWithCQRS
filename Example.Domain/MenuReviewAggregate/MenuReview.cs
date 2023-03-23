using Example.Domain.DinnerAggregate.ValueObjects;
using Example.Domain.HostAggregate.ValueObjects;
using Example.Domain.MenuAggregate.ValueObjects;
using Example.Domain.GuestAggregate.ValueObjects;
using Example.Domain.Common.Models;
using Example.Domain.Common.ValueObjects;
using Example.Domain.MenuReviewAggregate.ValueObjects;

namespace Example.Domain.MenuReviewAggregate
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public Rating Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private MenuReview(
            MenuReviewId id,
            Rating rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static MenuReview Create(
            Rating rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId)
        {
            return new(
                MenuReviewId.CreateUnique(),
                rating,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}