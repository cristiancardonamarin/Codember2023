using Challenge05;

var httpClient = new HttpClient();
var response = await httpClient.GetAsync("https://codember.dev/data/database_attacked.txt");
var message = await response.Content.ReadAsStringAsync();
message = message.Trim();
var userDatabase = message.Split("\n");

var users = userDatabase.Select(data =>
{
    var dataSplit = data.Split(",");
    return new User
    {
        ID = dataSplit[0],
        UserName = dataSplit[1],
        Email = dataSplit[2],
        Age = dataSplit[3],
        Location = dataSplit[4]
    };
});

var invalidUsers = users.Where(user => !user.IsValid);
var secretMessage = string.Join("",invalidUsers.Select(user => user.UserName[0]));

Console.WriteLine(secretMessage);
Console.Read();