using Microsoft.AspNetCore.Identity;

namespace ClubHouse.Backend.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public bool IsBanned { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double PrefferedRadiusKm {get;set;}
        public string PrefferedCategories { get; set; }

        public ICollection<ProfileSnapshot> ProfileSnapshots { get; set; }
        public bool AcceptedTermsAndConditions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
