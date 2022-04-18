using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PRO2Zadanie1.Models;
using PRO2Zadanie1.Services;

namespace PRO2Zadanie1.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private IDalService _dbService;

        public UsersController(IDalService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetUsers(string orderBy)
        {
            if (orderBy == null)
            {
                orderBy = "login";
            }
            if (orderBy != "login" && orderBy != "email" && orderBy != "hashedPassword" && orderBy != "refreshToken")
            {
                throw new Exception();
            }
            return Ok(_dbService.GetUsers(orderBy));
        }


    }
}
