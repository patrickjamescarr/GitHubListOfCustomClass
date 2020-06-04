using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace ListOfCustomClass
{
    class Person
    {
        // fields
        private readonly DateTime _dateTime = DateTime.Now;
        

        // properties
        public string Fullname
        {
            get
            {
                return FirstName + " " + SecondName;
            }
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Age { get; set; }

        // methods
        public void CalculateAge(int birthYear)
        {
            int currentYear = Convert.ToInt32(_dateTime.Year);
            Age = Convert.ToString(currentYear - birthYear);
        }

        public static void PickAPerson(Person person)
        {
            Console.WriteLine($"The selected index for the People list is containing {person}");
        }

        public static void PickAPerson(int index, List<Person> person)
        {
            Console.WriteLine(person[index]);
        }

        /* To override the comparison of two objects with particular entity by accessing its members.
         * using Equals override method to further comparing two objects using Age properties (not just object 1 vs object 2, which is always 2 different things).
         * we use the Age properties, which we can entered for example below. */
        public override bool Equals(object obj)
        {
            if (Age == ((Person)obj).Age) // we cast object to type User so it can access it's properties/members
            {
                return true;
            }
            return false;
        }

        public static string FindPerson (List<Person> people, string firstName) // take in a people list, & user input for 1st name.
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].FirstName.Equals(firstName))
                {
                    return "There is a match! >> " + people[i].ToString();
                }
            }

            return "Cannot find the first name of " + firstName;
        }

        public override string ToString()
        {
            return "Fullname: " + Fullname + " >>> Age: " + Age;
        }
    }
}
