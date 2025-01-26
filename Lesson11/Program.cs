using Lesson11.Exceptions;
using Lesson11.Models;

namespace Lesson11;
internal class Program
{
    static void Main(string[] args)
    {
        string[] users = new string[4000];
        User user1 = new User("Ivan", 16, "ivan16@gmail.com");
        User user2 = new User("Jack", 51, "jack51@mail.com");
        User user3 = new User("David", 23, "david23@gmail.com");
        string jsonUser1 = System.Text.Json.JsonSerializer.Serialize<User>(user1);
        string jsonUser2 = System.Text.Json.JsonSerializer.Serialize<User>(user2);
        string jsonUser3 = System.Text.Json.JsonSerializer.Serialize<User>(user3);
        users[0] = jsonUser1;
        users[1] = jsonUser2;
        users[2] = jsonUser3;
        File.WriteAllLines("users.json", users);
        var isNotExit = true;
        while (isNotExit)
        {
            var option = Menu();
            switch (option)
            {
                case "1":
                    AddUserToFile();
                    break;

                case "2":
                    ShowInfoFromFile();
                    break;

                case "3":
                    isNotExit = false;
                    break;

                default:
                    Console.WriteLine("Entered incorrect data");
                    break;
            }
        }
        static void AddUserToFile()
        {
            var isFieldsNull = true;
            while (isFieldsNull)
            {
                User user4 = new User();
                try
                {
                    Console.WriteLine("Enter your username:");
                    user4.Name = Console.ReadLine();
                    Console.WriteLine("Enter your age:");
                    int age;
                    while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                    {
                        Console.WriteLine("Incorrect data entered. \nEnter your age:");
                    }
                    user4.Age = age;
                    Console.WriteLine("Enter your email:");
                    user4.Email = Console.ReadLine();
                }
                catch (EmptyStringException emptStrEx)
                {
                    Console.WriteLine($"Error: {emptStrEx.Message}");
                }
                catch (WrongEmailException wrngEmailEx)
                {
                    Console.WriteLine($"Error:{wrngEmailEx.Message}");
                }
                if (user4.Name != null && user4.Email != null)
                {
                    string jsonUser4 = System.Text.Json.JsonSerializer.Serialize<User>(user4);
                    string[] users = File.ReadAllLines("users.json");
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i] == "")
                        {
                            users[i] = jsonUser4;
                            File.WriteAllLines("users.json", users);
                            isFieldsNull = false;
                            break;
                        }
                    }
                }
            }
        }

        static void ShowInfoFromFile()
        {
            Console.WriteLine("List of all users:");
            string[] users = File.ReadAllLines("users.json");
            foreach (string user in users)
            {
                if (user != "")
                {
                    System.Text.Json.JsonSerializer.Deserialize<User>(user).ShowInfo();
                }
            }
        }

        static string Menu()
        {
            string option;
            Console.WriteLine("\nMenu:");
            Console.WriteLine("Enter 1 to add user");
            Console.WriteLine("Enter 2 to view information about all users");
            Console.WriteLine("Enter 3 to exit the program ");
            Console.WriteLine("\nEnter key:");
            option = Console.ReadLine();
            return option;
        }
    }
}

