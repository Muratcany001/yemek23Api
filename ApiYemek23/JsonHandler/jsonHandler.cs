using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System;
using System.IO;

public class JsonHandler
{
    public void ProcessJsonData()
    {
        try
        {
            string txtFilePath = "C:/restoranApi.txt";
            if (!File.Exists(txtFilePath))
            {
                Console.WriteLine("Txt dosyası bulunamadı.");
                return;
            }

            string jsonData = File.ReadAllText(txtFilePath);
            var jsonObject = JObject.Parse(jsonData);
            var businessesArray = (JArray)jsonObject["businesses"];
            string outputFilePath = "formatted_data.txt";

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var business in businessesArray)
                {
                    string id = business["id"]?.ToString();
                    string name = business["name"]?.ToString();
                    string rating = business["rating"]?.ToString();
                    string latitude = business["coordinates"]?["latitude"]?.ToString();
                    string longitude = business["coordinates"]?["longitude"]?.ToString();
                    string coordinates = string.Join(", ", latitude, longitude);
                    string address = string.Join(", ", business["location"]?["display_address"]?.ToObject<string[]>());
                    string phone = business["phone"]?.ToString();

                    string formatted = $"{id}, {name}, {rating}, {coordinates}, {address}, {phone}";
                    writer.WriteLine(formatted);
                }
            }
            Console.WriteLine("Veriler başarıyla 'formatted_data1.txt' dosyasına yazıldı.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata oluştu: " + ex.Message);
        }
    }
}
