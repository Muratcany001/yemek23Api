using ApiYemek23.Abstract;
using ApiYemek23.Entities.AppEntities;
using System.Text.Json;

namespace ApiYemek23.JsonHandler
{
    public class PostRestaurantData
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public PostRestaurantData(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task RunAsync(string filePath)
        {
            Console.WriteLine($"Dosya kontrol ediliyor: {filePath}");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Dosya bulunamadı.");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Toplam {lines.Length} satır bulundu.");

            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (var line in lines)
            {
                try
                {
                    Console.WriteLine($"Satır işleniyor: {line}");
                    var parts = line.Split(',');

                    if (parts.Length < 9)
                    {
                        Console.WriteLine($"Hatalı format: {line}");
                        continue;
                    }

                    var restaurant = new Restaurant
                    {
                        Restaurant_code = parts[0]?.Trim(),
                        Restaurant_Name = parts[1]?.Trim(),
                        Restaurant_Rating = int.TryParse(parts[2]?.Trim(), out int rating) ? rating : 0,
                        Restaurant_Coordinates = $"{parts[3]?.Trim()}, {parts[4]?.Trim()}",
                        Restaurant_Location = parts.Length > 6 ? string.Join(",", parts.Skip(5).Take(parts.Length - 6)).Trim() : "Bilinmiyor",
                        Restaurant_Phone_Number = parts.Last()?.Trim()
                    };

                    restaurants.Add(restaurant);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {line} | {ex.Message}");
                }
            }

            Console.WriteLine($"Veritabanına kaydedilecek toplam restoran sayısı: {restaurants.Count}");
            await SaveRestaurantsToDatabase(restaurants);
        }

        private async Task SaveRestaurantsToDatabase(List<Restaurant> restaurants)
        {
            foreach (var restaurant in restaurants)
            {
                try
                {
                    Console.WriteLine($"Veritabanına ekleniyor: {restaurant.Restaurant_Name}");
                    await _restaurantRepository.AddAsync(restaurant);
                    Console.WriteLine($"Başarıyla eklendi: {restaurant.Restaurant_Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {restaurant.Restaurant_Name} | {ex.Message}");
                }
            }
        }
    }
}
