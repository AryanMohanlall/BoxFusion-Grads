namespace ClubHouse.Backend.DTOs
{
    public record RegisterDTO(string Name,
        string Surname,
        DateTime DateOfBirth,
        bool IsMale,
        string UserName,
        string Email,
        string Password,
        double Longitude,
        double Latitude,
        double PrefferedRadiusKm,
        string PrefferedCategories,
        bool AcceptedTermsAndConditions
    );
    
}
