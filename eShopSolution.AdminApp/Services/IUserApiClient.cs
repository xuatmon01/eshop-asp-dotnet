﻿using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<String> Authenticate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}
