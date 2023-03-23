using Example.Domain.DinnerAggregate.ValueObjects;
using Example.Domain.HostAggregate.ValueObjects;
using Example.Domain.Common.Models;
using Example.Domain.Common.ValueObjects;
using Example.Domain.UserAggregate.ValueObjects;
using Example.Domain.GuestAggregate.ValueObjects;
using Example.Domain.BillAggregate.ValueObjects;
using Example.Domain.MenuReviewAggregate.ValueObjects;

namespace Example.Domain.GuestAggregate
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }
        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Guest(
            GuestId id,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId)
        {
            return new(
                GuestId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}