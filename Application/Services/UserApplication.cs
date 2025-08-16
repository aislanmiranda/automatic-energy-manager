using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Interfaces;
using Application.DTOs;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace Application.Services;

public class UserApplication : IUserApplication
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _config;

    public UserApplication(IUserRepository userRepository,
        IConfiguration config)
	{
        _userRepository = userRepository;
        _config = config;
	}

    public async Task<Result<string>> AuthLogin(LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {            
            var user = await _userRepository.AuthAsync(p => p.Login.Equals(request.Login)
            && p.Password.Equals(request.Password), cancellationToken);

            if (user == null)
                return Result<string>.Fail("Usuário não cadastrado no sistema.");

            if (user != null && user.Status == 0)
                return Result<string>.Fail("Usuário desativado no sistema.");

            if (user != null && user.Status == 2)
                return Result<string>.Fail("Usuário ainda não liberado no sistema.");

            var identity = new ClaimsIdentity(new[]
            {
                //TODO: setar informacao relevante aqui
                //new Claim(ClaimTypes.NameIdentifier, user?.UserCustomer?.Customer?.AliasCustomer ?? "admin"),
                new Claim(ClaimTypes.Name, user?.UserCustomer?.Customer?.Name ?? "Administrador"),
                new Claim(ClaimTypes.Role, user?.UserCustomer?.Customer?.TypeCustomer.Length > 0 ? "C" : "A"),
                new Claim(ClaimTypes.Sid, user?.UserCustomer?.Customer?.Id.ToString()  ?? "")
            });

            string accessToken = GenerateAccessToken(identity);
            string refreshToken = GenerateRefreshToken();

            return Result<string>.Ok(accessToken);
        }
        catch (Exception ex)
        {
            return Result<string>.InternalError("Erro interno no processo de autenticação.");
        }
    }

    private string GenerateAccessToken(ClaimsIdentity identity)
    {        
        var key = Encoding.ASCII.GetBytes(_config["JwtSettings:SecretKey"]!);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(_config["JwtSettings:AccessTokenExpirationMinutes"]!)),
            Issuer = _config["JwtSettings:Issuer"],
            Audience = _config["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
}


