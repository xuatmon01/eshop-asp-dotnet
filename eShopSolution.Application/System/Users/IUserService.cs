﻿using eShopSolution.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace eShopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<String> Authenticate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}