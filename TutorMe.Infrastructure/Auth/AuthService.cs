using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TutorMe.Core.Enums;
using TutorMe.Core.Services;

namespace TutorMe.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateJwtToken(
        string userName, 
        string email, 
        RoleEnum role
    )
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];
        
        var securityKey = 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));

        var credentials = 
            new SigningCredentials(
                securityKey, 
                SecurityAlgorithms.HmacSha256
            );

        var claims = new List<Claim>
        {
            new ("userName", userName),
            new ("email", email),
            new (ClaimTypes.Role, role.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer, 
            audience: audience, 
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)), 
            signingCredentials: credentials,
            claims: claims
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }

    public string ComputeSha256Hash(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            
            return builder.ToString();
        }
    }
}