using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_MVVM.Data
{
    class Person
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public Person()
        {
            FirstName = "Firstname";
            LastName = "Lastname";
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Person[] GetPersons() => new Person[]
            {
                new Person("Victor","Gorban"),
                new Person("Vadim","Vasilievich"),
                new Person("ThirdName","ThirdLastname")
            };
    }
}
