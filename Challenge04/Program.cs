var httpClient = new HttpClient();
var response = await httpClient.GetAsync("https://codember.dev/data/files_quarantine.txt");
var message = await response.Content.ReadAsStringAsync();
message = message.Trim();
var lines = message.Split("\n");

var correctChecksums = new List<string>();
foreach (var line in lines)
{
    var name = line.Split("-")[0];
    var checksum = line.Split("-")[1];

    var charGroup = name.GroupBy(c => c);

    var charList = charGroup.Where(grouping => grouping.Count() == 1)
        .Select(grouping => grouping.Key);
    
    var correctChecksum = string.Join("",charList);
   
    if(correctChecksum.Equals(checksum))
        correctChecksums.Add(checksum);
}

Console.WriteLine(correctChecksums.ElementAt(32));
Console.ReadKey();  
