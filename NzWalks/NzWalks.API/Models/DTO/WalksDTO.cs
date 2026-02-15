namespace NzWalks.API.Models.DTO
{
    public class WalksDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? WalkImageUrl { get; set; } = null;

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
