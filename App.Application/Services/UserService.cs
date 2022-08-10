using App.Application.Dtos;
using App.Application.Helpers;
using App.Application.Interfaces;
using App.Infrastructure.Data;
using App.Infrastructure.Data.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;

        public UserService(ApplicationDbContext db, IMapper mapper, IEmailService emailService)
        {
            _db = db;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public async Task<User> GetLoginUser(string? userNameOrEmailAddress, string? password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(e =>
                (e.Username == userNameOrEmailAddress || e.EmailAddress == userNameOrEmailAddress) &&
                e.Password == password &&
                e.IsActive == true);

            return user;
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            user.IsActive = false;

            var userModel = mapper.Map<User>(user);

            userModel.ActivationKey = StringHelper.Base64Encode(Random.Shared.Next(100, 999).ToString());

            _db.Users.Add(userModel);
            _db.SaveChanges();


            var body = @$"
                <html>
                    <head>
                    <style>h1 {{ color: red }}</style>
                    </head>
                    <body>
                        <h1>Ecommerce</h1>
                        <h2>Üyelik Aktivasyonu</h2>
                        <p>Üyeliğinizi aktif etmek için aşağıdaki bağlantıya tıklayınız.</p>
                        <a href=""https://localhost:7134/Auth/Activate?email={userModel.EmailAddress}&activationKey={userModel.ActivationKey}"">Aktive Et</a>
                    </body>
                </html>
            ";

            this.emailService.Send(user.EmailAddress, "Ecommerce: Üyelik Aktivasyonu", body);

            return user;
        }

        public bool ValidateAndActivate(string email, string activationKey)
        {
            var user = _db.Users.FirstOrDefault(e => e.EmailAddress == email && e.ActivationKey == activationKey);

            if (user != null)
            {
                user.IsActive = true;
                _db.SaveChanges();
            }


            return user != null;
        }
    }
}
