using Example.Domain.Common.Models;
using Example.Domain.MenuAggregate.ValueObjects;
using Example.Domain.HostAggregate.ValueObjects;
using Example.Domain.DinnerAggregate.ValueObjects;
using Example.Domain.MenuReviewAggregate.ValueObjects;
using Example.Domain.Common.ValueObjects;
using Example.Domain.MenuAggregate.Entities;

namespace Example.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _section = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }
        public IReadOnlyList<MenuSection> Sections => _section.AsReadOnly();
        public HostId HostId { get; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Menu(
            MenuId id,
            string name,
            string description,
            AverageRating averageRating,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            string name,
            string description,
            AverageRating averageRating,
            HostId hostId)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                averageRating,
                hostId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}