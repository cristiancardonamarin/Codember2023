var httpClient =  new HttpClient();
var response = await httpClient.GetAsync("https://codember.dev/data/encryption_policies.txt");
var message = await response.Content.ReadAsStringAsync();
var lines = message.Split("\n");

var invalidPasswords = new List<string>();

foreach (var line in lines)
{
    var splitLine = line.Split(":");
    var password = splitLine[1];
    var securityPolicy = splitLine[0].Split(" ");
    var range = securityPolicy[0].Split("-");
    var letter = securityPolicy[1];
    var minNumberOfLetters = int.Parse(range[0]);
    var maxNumberOfLetters = int.Parse(range[1]);

    var letterCount = password.Count(ch => ch.ToString().Equals(letter));

    if (letterCount >= minNumberOfLetters && letterCount <= maxNumberOfLetters)
        continue;
    
    invalidPasswords.Add(password);        
}

Console.WriteLine(invalidPasswords.ElementAt(41));
Console.ReadKey();