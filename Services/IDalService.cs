using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRO2Zadanie1.Models;

namespace PRO2Zadanie1.Services
{
    public interface IDalService
    {
        public IEnumerable<User> GetUsers(string orderBy);
        public string CreateUser(User user);
        public string UpdateUser(string Id, User user);
        public string DeleteUser(string Id);
    }
}
