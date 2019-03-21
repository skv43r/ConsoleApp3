using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers.api
{
    public class CityController : ApiController
    {
        [HttpPost]public string getPersonData(Person person)
        {
            return $"Москва";
        }
    }
}
