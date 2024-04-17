using ExampleApp.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Application.Interfaces;

public interface IRoleServices
{
    public Task<Role?> IsExistsRoleAsync(Role role);
    public Task<bool> IsFill(Role role);
}
