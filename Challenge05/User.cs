using System.Text.RegularExpressions;

namespace Challenge05;

public class User
{
    public string ID { get; set; }      
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Age { get; set; }
    public string Location { get; set; }

    public bool IsValid
    {
        get
        {
            if (!Regex.IsMatch(ID,"^[a-zA-Z0-9]*$"))
                return false;
            if (!Regex.IsMatch(UserName, "^[a-zA-Z0-9]*$"))
                return false;
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return false;
            
            return string.IsNullOrWhiteSpace(Age) || int.TryParse(Age, out var result);
        }
    }
}