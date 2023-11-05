using System.Linq;

var httpClient = new HttpClient();
var response = await httpClient.GetAsync("https://codember.dev/data/message_01.txt");
var message = await response.Content.ReadAsStringAsync();
message = message.Trim();

var words = message.Split(" ");
var groups = words.GroupBy(word => word);
var finalResult = string.Join("",groups.Select(group => $"{group.Key}{group.Count()}"));

Console.WriteLine(finalResult);
Console.ReadKey();
