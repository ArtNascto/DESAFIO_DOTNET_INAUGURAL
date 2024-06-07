using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzçÇáÁéÉíÍóÓúÚâÂêÊôÔãÃõÕàÀñÑ";
        var random = new Random();
        while (true)
            await Task.WhenAll(Enumerable.Range(0, 100).Select(async i =>
            {
                var number = random.Next(1, 100);
                var chars = new List<char>();
                while (number.ToString().Length + chars.Count < 5)
                {
                    chars.Add(letters[random.Next(0, letters.Length)]);
                }

                var combinations = new List<string>();
                for (int j = 0; j <= chars.Count; j++)
                {
                    var text = string.Empty;
                    text = string.Join("", chars).Insert(j, number.ToString());
                    combinations.Add(text);
                }

                foreach (var combination in combinations)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://fiap-inaugural.azurewebsites.net/fiap");
                    var reqJson = JsonConvert.SerializeObject(new
                    {
                        Key = combination,
                        grupo = "AAMEJ"
                    });
                    var content = new StringContent(reqJson, null, "application/json");
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Request {i} - {combination}");
                        var responseText = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseText);
                    }
                }
            }));
    }
}
