using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForSale.ComunDll.Entidades;
using ForSale.WebbApp.Data.Entidades;
using ForSale.WebbApp.Helpers;
using ForSale.ComunDll.Enums;

namespace ForSale.WebbApp.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context,IUserHelper  userHHelper)
        {
            _context = context;
            _userHelper = userHHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Adonay", "Herrera", "adonayhv@gmail.com", "77018696", "Santa Tecls L.L", UserType.Admin);
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }


        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "El Salvador",
                    Departments = new List<Department>
                {
                    new Department
                    {
                        Name = "Sonsonate",
                        Cities = new List<City>
                        {
                            new City { Name = "Acajulta" },
                            new City { Name = "Izalco" },
                            new City { Name = "Itagüí" }
                        }
                    },
                    new Department
                    {
                        Name = "La Libertad",
                        Cities = new List<City>
                        {
                            new City { Name = "Santa Tecla" }
                        }
                    },
                    new Department
                    {
                        Name = "Chalatenango",
                        Cities = new List<City>
                        {
                            new City { Name = "Arcatao" },
                            new City { Name = "Las Vueltas" },
                            new City { Name = "Dulce Nombre de Maria" }
                        }
                    }
                }
                });
                _context.Countries.Add(new Country
                {
                    Name = "USA",
                    Departments = new List<Department>
                {
                    new Department
                    {
                        Name = "California",
                        Cities = new List<City>
                        {
                            new City { Name = "Los Angeles" },
                            new City { Name = "San Diego" },
                            new City { Name = "San Francisco" }
                        }
                    },
                    new Department
                    {
                        Name = "Illinois",
                        Cities = new List<City>
                        {
                            new City { Name = "Chicago" },
                            new City { Name = "Springfield" }
                        }
                    }
                }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
