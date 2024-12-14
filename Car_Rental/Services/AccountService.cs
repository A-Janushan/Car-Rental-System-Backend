using Car_Rental.Data;
using Car_Rental.DTOS.Account;
using Car_Rental.Entities;
using Car_Rental.IRepositories;
using Car_Rental.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Car_Rental.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IConfiguration _configuration;
        public AccountService(IAccountRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<Token> PostUser(RegisterDto registerDto)
        {

            var user = new ApplicationUser()
            {
                FName = registerDto.FName,
                LName = registerDto.LName,
                Email = registerDto.Email,
                Address = registerDto.Address,
                DOB = registerDto.DOB,
                Password = registerDto.Password,
                Role = registerDto.Role,    
            };

            var data = await _repository.PostUser(user);

            var res = await CreateToken(user);
            return res;
        }

        public async Task<ApplicationUser> UpdateUser(UserDto userDto)
        {
            var user = new ApplicationUser();
            var data = await _repository.UpdateUser(user);
            return data;
        }

        public async Task<Token> LogIn(LoginDto logInDto)
        {
            var user = await _repository.GetUserByEmail(logInDto.Email);
            if (user == null) {
                throw new Exception("No user found");
            }
            if (user.Password != logInDto.Password) {
                throw new Exception("Invalid Password");
            }
            var res = await CreateToken(user);
            return res;
            
        }

       public async Task<bool> DeleteUser(int userId)
        {
            var getUser = await _repository.GetUserById(userId);
            if (getUser == null) {
                throw new Exception("No user found");
            }
            var result = await _repository.DeleteUser(getUser);
            return result;
        }

        public async Task<Token>CreateToken(ApplicationUser user)
        {
            var claimList = new List<Claim>();
            claimList.Add(new Claim("UserId", user.Id.ToString()));
            claimList.Add(new Claim("Name", user.FName));
            claimList.Add(new Claim("Email", user.Email));
            claimList.Add(new Claim("Role", user.Role.ToString()));


            var key = _configuration["JWT:Key"];
            var secKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claimList,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            var res = new Token();
            res.token = new JwtSecurityTokenHandler().WriteToken(token);
            return res;
        }
    }
}
