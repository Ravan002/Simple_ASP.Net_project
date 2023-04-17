﻿using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Token? Token { get; set; }
        public string Message { get; set; }
    }
}
