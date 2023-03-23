using Example.Domain.Common.Models;
using Example.Domain.Common.ValueObjects;
using Example.Domain.DinnerAggregate.Enums;
using Example.Domain.DinnerAggregate.ValueObjects;
using Example.Domain.HostAggregate.ValueObjects;
using Example.Domain.MenuAggregate.ValueObjects;
using Example.Domain.DinnerAggregate.Entities;

namespace Example.Domain.DinnerAggregate
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations = new();
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; }
        public DateTime? EndedDateTime { get; }
        public DinnerStatus Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }
        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Dinner(
            DinnerId id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            List<Reservation> reservations,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            _reservations = reservations;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            List<Reservation> reservations)
        {
            return new(
                DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                status,
                isPublic,
                maxGuests,
                price,
                hostId,
                menuId,
                imageUrl,
                location,
                reservations,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}