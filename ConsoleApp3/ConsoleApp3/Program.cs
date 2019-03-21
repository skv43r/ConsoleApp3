using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "Александр",
                LastName = "Борейко",
                Gender = Genders.Male,
                Age = 21,
                Phone = "89153131111",
                City = "Moscow",
                Passport = "4511111111"
            };

            var obj = ApiClient.Post<Person, string>(person, "http://localhost:56727/api/Person/getPersonData");

            var jsonString = JsonConvert.SerializeObject(person);

            Console.WriteLine(jsonString);

            var stringWriter = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(Person));
            xmlSerializer.Serialize(stringWriter, person);
            var xmlString = stringWriter.ToString();

            Console.WriteLine(xmlString);

            Console.ReadKey();
        }
    }
}
