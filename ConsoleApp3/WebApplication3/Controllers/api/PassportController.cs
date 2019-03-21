using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers.api
{
    public class PassportController : ApiController
    {
        [HttpPost] public string getPersonData(Person person)
        {
            return $"4511111111";
        }
    }
}
