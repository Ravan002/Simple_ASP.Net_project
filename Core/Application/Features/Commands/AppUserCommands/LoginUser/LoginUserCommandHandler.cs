using Application.TokenService;
using Domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly ILogger<LoginUserCommandHandler> _logger;

        public LoginUserCommandHandler(
            SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager, 
            ITokenHandler tokenHandler, 
            ILogger<LoginUserCommandHandler> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _logger = logger;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user= await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            }
            if (user == null)
            {
                throw new Exception("Kullcaninci bulunamadi");
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                _logger.LogInformation($"{user.UserName} adli kullanici basariyla giris yapdi");
                //token yaradaciyiq
                return new()
                {
                    Token = _tokenHandler.CreatAccessToken(15),
                    Message = "Basariyla giris yapildi"
                };
            }
            _logger.LogWarning($"{user.UserName} adli kullanici parolayi yanlis girdi");
            return new()
            {
                Message = "Password is incorrect"
            };
        }
    }
}
