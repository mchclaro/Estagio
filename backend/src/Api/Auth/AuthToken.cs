// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Api.Configurations;
// using Domain.Entities;
// using Microsoft.IdentityModel.Tokens;


// namespace Api.Auth
// {
//     public class AuthToken
//     {
//         public string GenerateToken(User user)
//         {
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.ASCII.GetBytes(Settings.Secret);
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(new []
//                 {
//                     new Claim(ClaimTypes.Name, user.Name),
//                     new Claim(ClaimTypes.Role, user.Role.ToString())
//                 }),
//                 Expires = DateTime.UtcNow.AddHours(8),
//                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//             };

//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             return tokenHandler.WriteToken(token);
//         }

//         public LoginToken GenerateRefreshToken()
//         {
//             return new LoginToken
//             {
//                 Token = Guid.NewGuid().ToString("N"),
//                 Created = DateTime.UtcNow,
//                 Expiration = DateTime.UtcNow.AddDays(1)
//             };
//         }
//     }
// }