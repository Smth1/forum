using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Forum.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Forum.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Users()
        {
            var model = new UserListViewModel();
            model.Users = LoadUsers();
            return View(model);
        }

        private List<UserViewModel> LoadUsers()
        {
            var users = new List<UserViewModel>();

            using (var conn = new MySqlConnection("Server=localhost;Database=forum;Uid=root;Pwd=root;"))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from Users", conn);
                cmd.CommandType = CommandType.Text;
                

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserViewModel
                        {
                            ID = reader.GetInt32("ID"),
                            Description = reader.GetString("Description"),
                            Nickname = reader.GetString("Nickname"),
                            Email = reader.GetString("Email")
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }
    }
}