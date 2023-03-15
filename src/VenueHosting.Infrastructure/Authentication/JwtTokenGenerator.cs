using System.Security.Claims;
using VenueHosting.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VenueHosting.Domain.Entities;
using VenueHosting.Infrastructure.Configuration;

namespace VenueHosting.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;
    
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string Generate(User user)
    {
        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.FirstName + " " + user.LastName),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        JwtSecurityToken securityToken = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials,
            audience: _jwtSettings.Audience,
            issuer: _jwtSettings.Issuer,
            expires: _dateTimeProvider.GetUtcNow().AddMinutes(_jwtSettings.ExpiryDurationMinutes));

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}