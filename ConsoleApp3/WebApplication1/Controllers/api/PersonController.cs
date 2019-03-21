using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers.api
{
    public class PersonController : ApiController
    {
        [HttpPost] public string getPersonData (Person person)
        {
            string result;
            var obj = ApiClient.Post<Person, string>(person, "http://localhost:56784/api/City/getPersonData");
            person.City = obj;
            var obj2 = ApiClient.Post<Person, string>(person, "http://localhost:56789/api/Passport/getPersonData");
            person.Passport = obj2;
            return $"Привет, {person.FirstName}, {person.LastName}, проживает в {person.City}, пасспорт {person.Passport}";
            
        }
    }
}
