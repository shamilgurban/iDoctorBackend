using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using iDoctor.Models;
using Microsoft.AspNetCore.Authorization;


namespace iDoctor.Controllers;

public class User
{
    public User(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly List<User> _users = new List<User>()
    {
        new User("doctor@gmail.com", "123", "doctor"),
        new User("patient@gmail.com", "1234", "patient")
    };

    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _users.Find(u => u.Username == request.Username && u.Password == request.Password);

        if (user is null)
        {
            return Unauthorized();
        }

        string token = GenerateJwtToken(user.Username, user.Role);
        return Ok(token);
    }

    [HttpGet]
    [Authorize(Roles = "patient")]
    public IActionResult TestPatient()
    {
        return Ok("Only patients");
    }

    [HttpGet]
    [Authorize(Roles = "doctor")]
    public IActionResult TestDoctor()
    {
        return Ok("Only doctors");
    }

    private string GenerateJwtToken(string username, string role)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var x = jwtSettings["Key"];
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(ClaimTypes.Role, role)
        };

        var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}