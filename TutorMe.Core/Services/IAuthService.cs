using TutorMe.Core.Enums;

namespace TutorMe.Core.Services;

public interface IAuthService
{
    string GenerateJwtToken(string userName, string email, RoleEnum role);
    string ComputeSha256Hash(string password);
}

