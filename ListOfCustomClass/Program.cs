using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfCustomClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! start of Caleb Curry Video #71");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            List<Person> people = new List<Person>();

            // instance of Person > person1 object
            var person1 = new Person();
            person1.FirstName = "Budong";
            person1.SecondName = "Drummond";
            Console.WriteLine($"Hi, {person1.FirstName}, Enter the year you are born in:");
            int birthYear = Convert.ToInt32(Console.ReadLine());
            person1.CalculateAge(birthYear);
            Console.WriteLine($"So I know you are now {person1.Age} years old");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            // another instance of Person > person2 object. Alternative simplified was to create and set names.
            var person2 = new Person { FirstName = "Clare", SecondName = "Carney" };
            Console.WriteLine($"Hi, {person2.FirstName}, Enter the year you are born in:");
            int birthYear2 = Convert.ToInt32(Console.ReadLine());
            person2.CalculateAge(birthYear2);
            Console.WriteLine($"So I know you are now {person2.Age} years old");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            people.Add(person1);
            people.Add(person2);

            /* Adding or filling value as a custome type inside a loop. e.g., asking user in cosole to add value in the loop
             * you can create user as many as you want it, alternatively, reading from a file, 
             * putting everything in the object and add it to the list.
             */

            // keep asking user until exit is chosen
            bool KeepGoing = true;
            do
            {
                // Using switch statement to add more user or not, via console.
                Console.WriteLine("Do you want to add more user? insert Y or N & press [ENTER]:");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "y":
                        Console.WriteLine("Enter the fullname seperated by comma or a space: ");
                        string UserFullName = Console.ReadLine(); // read full name
                        String[] Seperator = { " ", "," }; // set the seperators betwwen 1st & 2nd name

                        // split the fullname into 2 and store in in new string array. removed any empty spaces.
                        String[] FirstAndSecondName = UserFullName.Split(Seperator, 2, StringSplitOptions.RemoveEmptyEntries);

                        Console.WriteLine("Enter the year you are born in:");
                        int UserBirthYear = Convert.ToInt32(Console.ReadLine());

                        // **obsolete** int personNo = people.Count + 1; // to initialise the number of person object identifier
                        var NewPerson = new Person { FirstName = FirstAndSecondName[0], SecondName = FirstAndSecondName[1]}; // add 1st & 2nd name taken from String array
                        NewPerson.CalculateAge(UserBirthYear); // calculate age from given birth year.
                        people.Add(NewPerson); // add new person to people List
                        break;
                    case "n":
                        Console.WriteLine("Finished with adding more people\n");
                        KeepGoing = false;
                        break;
                    default:
                        break;
                }
            } while (KeepGoing);

            /* An example of one liner for the same result on creating list and assign person1 & person2:
             * List<Person> people = new List<Person>(){person1, person2};
             */
            Console.WriteLine($"Currently, there are {people.Count} people in the list:");

            // Iterate the people List
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            /* >>>>> List<Person> people = new List<Person>(); <<<<<
               is the list we are working on in this Main method.*/

            // Passing custom type into method - Video 73.
            Console.WriteLine("Insert the index of the person you want to pick from people list:");
            int index = Convert.ToInt32(Console.ReadLine());
            Person.PickAPerson(people[index]);

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            // Static Method(Method to Take an ArrayList of Custom Type) - Video 76.
            Person.PickAPerson(index, people); // 'people is a List of Type Person.

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            // Method overload & Optional parameter - Video 78.

            // Searching a List for custom object - Video 79.
            Console.WriteLine("Enter the firstname you want to find from the people list:");
            string UserInput = Console.ReadLine();
            Console.WriteLine(Person.FindPerson(people, UserInput));

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            // Override Equals methods - Video 82.
            bool TestEquals = people[2].Equals(people[3]);
            Console.WriteLine($"is {people[2]} and {people[3]} is the same object? the answer is {TestEquals}");

            /* i need help badly here...
             * 
             * .*/
            Console.WriteLine("Equals method override...do you want to check if two objects in the list have the same age? Y or N");
            var check = Console.ReadLine().ToLower();
            switch (check)
            {
                case "y":
                    // new age list. 
                    List<int> ageList = new List<int>(); 
                    // go through the people list of type Person (see line.17) - grab each Object's Age value store it in the new age list
                    foreach (Person person in people)
                    {
                        ageList.Add(Convert.ToInt32(person.Age));
                    }
                    // using LINQ to query the list where ages are the same <<<<<<<<<<<<<<<<<<

                    // Group the people list by age
                    var sameAgeQuery = from person in people
                                       group person by person.Age into ageGroup
                                       orderby ageGroup.Key
                                       select ageGroup;

                    Console.WriteLine("People grouped by age: ");

                    // loop through each age in the group and output the people with that age
                    foreach (var ageGroup in sameAgeQuery)
                    {
                        Console.WriteLine($"Age: {ageGroup.Key}");

                        foreach (var person in ageGroup)
                        {
                            Console.WriteLine(person.Fullname);
                        }
                    }

                    break;
                case "n":
                    break;
                default:
                    break;
            }

            // Overload methods - Video 83
            Console.ReadKey();
        }
    }
}
