using Application.Exceptions;
using Domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager; 
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserCommandResponse response=new();
            IdentityResult result =await _userManager.CreateAsync(new()
            {
                FullName=request.FullName,
                Email=request.Email,
                UserName=request.Username,
            },request.Password);

            response.Success=result.Succeeded;
            if(result.Succeeded)
            {
                response.Message = "basariyla giris yapildi";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code}--{error.Description}";
                }
            }
            return response;
        }
    }
}
