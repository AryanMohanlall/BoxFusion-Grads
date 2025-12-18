namespace ClubHouse.Backend.Models
{
    public class ProfileSnapshot
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public double PrefferedRadiusKm { get; set; }
        public string PrefferedCategories { get; set; }

        public DateTime SnapshotTakenAt { get; set; }
        public string Reason { get; set; }
    }
}
