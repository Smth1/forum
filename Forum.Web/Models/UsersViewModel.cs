using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models
{

    public class UserListViewModel
    {
        public List<UserViewModel> Users { get; set; }
    }

    public class UserViewModel
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Description { get; set; }
    }
}
