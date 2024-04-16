﻿using ExampleApp.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Application.Interfaces;

public interface IUserServices
{
    public Task<User?> IsExistsUser(User user);
    public Task<bool> IsFill(User user);
    public Task<User> Login(User user);
}
