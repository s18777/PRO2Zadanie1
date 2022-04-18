using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PRO2Zadanie1.Models;

namespace PRO2Zadanie1.Services
{
    public class DalService : IDalService
    {

        private readonly IConfiguration _conf;
        public DalService(IConfiguration conf)
        {
            _conf = conf;
        }


        public IEnumerable<User> GetUsers(string orderBy)
        {

            var list = new List<User>();
            SqlConnection con = new SqlConnection(_conf.GetConnectionString("DB"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;

            if (orderBy.Equals("name"))
            {
                com.CommandText = "SELECT * FROM User ORDER BY Login";
            }
            if (orderBy.Equals("description"))
            {
                com.CommandText = "SELECT * FROM User ORDER BY Email";
            }
            if (orderBy.Equals("category"))
            {
                com.CommandText = "SELECT * FROM User ORDER BY HashedPassword";
            }
            if (orderBy.Equals("area"))
            {
                com.CommandText = "SELECT * FROM User ORDER BY RefreshToken";
            }

            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                string login = dr["Login"].ToString();
                string email = dr["Email"].ToString();
                string hashedPassword = dr["HashedPassword"].ToString();
                string refreshToken = dr["RefreshToken"].ToString();
                var user = new User
                {
                    Login = login,
                    Email = email,
                    HashedPassword = hashedPassword,
                    RefreshToken = refreshToken
                };
                list.Add(user);
            }

            con.Dispose(); //powinnienem using

            return list;
        }

        public string CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public string DeleteUser(string Id)
        {
            throw new NotImplementedException();
        }



        public string UpdateUser(string Id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
