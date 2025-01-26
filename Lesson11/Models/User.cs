using System.Text.RegularExpressions;
using Lesson11.Exceptions;

namespace Lesson11.Models;

internal class User
{
    private string _name;

    private int _age;

    private string _email;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyStringException("Nothing entered");
            }
            _name = value;
        }
    }

    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }

    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyStringException("Nothing entered");

            }
            Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");
            Match match = regex.Match(value);
            if (!match.Success)
            {
                throw new WrongEmailException("Entered invalid email");
            }
            _email = value;
        }
    }

    public User(string name, int age, string email)
    {
        _name = name;
        _age = age;
        _email = email;
    }

    public User()
    {
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Username: {this.Name}, user's age: {this.Age}, user's email: {this.Email}");
    }
}

