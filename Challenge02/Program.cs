
//Obtener el mensaje
var httpClient = new HttpClient();
var response = await httpClient.GetAsync("https://codember.dev/data/message_02.txt");
var message = await response.Content.ReadAsStringAsync();
message = message.Trim();

// "#" Incrementa el valor numérico en 1.
// "@" Decrementa el valor numérico en 1.
// "*" Multiplica el valor numérico por sí mismo.
// "&" Imprime el valor numérico actual.

var currentValue = 0;

foreach (var @char in message)
{
    if (@char == '#')
        currentValue++;

    if (@char == '@')
        currentValue--;

    if (@char == '*')
        currentValue *= currentValue;
    
    if(@char == '&')
        Console.Write(currentValue);
}

Console.Read();