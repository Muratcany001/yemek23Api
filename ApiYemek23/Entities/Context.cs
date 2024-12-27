using ApiYemek23.Entities.AppEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ApiYemek23.Entities
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public Context(DbContextOptions<Context> options)
      : base(options)
        {
        }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding restaurant data
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Restaurant_Id = 1,
                    Restaurant_code = "Muu1FZhmYLI6V97zpUSMag",
                    Restaurant_Name = "Efendi Beyzade Restaurant & Cafe",
                    Restaurant_Rating = 5,
                    Restaurant_Coordinates = "38.667326007826, 39.1802491620183",
                    Restaurant_Location = "Cumhuriyet Mh., Malatya Cad. Hazardağlı Plaza No: 58, 23100 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242480064"
                },
                new Restaurant
                {
                    Restaurant_Id = 2,
                    Restaurant_code = "XaAbfWZFcW9t1eqxGaR4xw",
                    Restaurant_Name = "Kilis Kebap Salonu 1952",
                    Restaurant_Rating = 5,
                    Restaurant_Coordinates = "38.675347, 39.222602",
                    Restaurant_Location = "İzzet Paşa Mah. Şehit Yüzbaşı Tahir Cad., No: 4, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242367572"
                },
                new Restaurant
                {
                    Restaurant_Id = 3,
                    Restaurant_code = "HzCYXjCrM-oMwuqWIi-aFQ",
                    Restaurant_Name = "Kebapçı Halit Usta",
                    Restaurant_Rating = 4,
                    Restaurant_Coordinates = "38.704532, 39.251641",
                    Restaurant_Location = "Harput Mah., Ahmet Kabaklı Blv. No:38, 23300 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242151176"
                },
                new Restaurant
                {
                    Restaurant_Id = 4,
                    Restaurant_code = "mrFQcvgO5EYnAKu7LSBGQg",
                    Restaurant_Name = "Kapalıçarşı Pide Fırını",
                    Restaurant_Rating = 5,
                    Restaurant_Coordinates = "38.6734962, 39.2241554",
                    Restaurant_Location = "Kapalıçarşı İşçiler Sok. No: 12, Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242378683"
                },
                new Restaurant
                {
                    Restaurant_Id = 5,
                    Restaurant_code = "JRxK3RVlAYrZa9bKHnxY2Q",
                    Restaurant_Name = "Örnek Lokantası",
                    Restaurant_Rating = 0,
                    Restaurant_Coordinates = "38.674839, 39.2172203",
                    Restaurant_Location = "Nailbey Mah., Bahçeli Sok. No: 7/A, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242361517"
                },
                new Restaurant
                {
                    Restaurant_Id = 6,
                    Restaurant_code = "1cU-59yZfDOKKG5U3-ggTg",
                    Restaurant_Name = "Aspirin Büfeterya",
                    Restaurant_Rating = 0,
                    Restaurant_Coordinates = "38.6733093, 39.1991196",
                    Restaurant_Location = "Üniversite Mah. Zübeyde Hanım Cad., 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242416622"
                },
                new Restaurant
                {
                    Restaurant_Id = 7,
                    Restaurant_code = "smKx_z-IEFuBaVK_b9hOhQ",
                    Restaurant_Name = "Ensar Mangal Vadisi",
                    Restaurant_Rating = 5,
                    Restaurant_Coordinates = "38.674817, 39.22252",
                    Restaurant_Location = "Harput Mah., Nadir Baba Sok. No:1, 23200 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242151033"
                },
                new Restaurant
                {
                    Restaurant_Id = 8,
                    Restaurant_code = "dUk8aTE1btTtIAbSKp8tfg",
                    Restaurant_Name = "Harput Hünkar Konağı",
                    Restaurant_Rating = 2,
                    Restaurant_Coordinates = "38.703999989036, 39.255048930645",
                    Restaurant_Location = "Harput Kales Yanı, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242156869"
                },
                new Restaurant
                {
                    Restaurant_Id = 9,
                    Restaurant_code = "eRPbK7RxaT2moDjko_34hg",
                    Restaurant_Name = "Çiğköfteci Hacı'nın Yeri",
                    Restaurant_Rating = 0,
                    Restaurant_Coordinates = "38.6733093, 39.1991196",
                    Restaurant_Location = "Zübeyde Hanım Cad., No: 116/B, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242369060"
                },
                new Restaurant
                {
                    Restaurant_Id = 10,
                    Restaurant_code = "XonqwJ2_GE2QGACKAtAGig",
                    Restaurant_Name = "Pizza Pizza",
                    Restaurant_Rating = 4,
                    Restaurant_Coordinates = "38.671868, 39.192114",
                    Restaurant_Location = "Zübeyde Hanım Cad., No: 102/B, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242378800"
                },
                new Restaurant
                {
                    Restaurant_Id = 11,
                    Restaurant_code = "rzv_N4V9blqyar27t3Tu_g",
                    Restaurant_Name = "Burger King",
                    Restaurant_Rating = 5,
                    Restaurant_Coordinates = "38.6420288, 39.1216393",
                    Restaurant_Location = "Nailbey Mah. Gazi Cad., No: 51/B, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242181864"
                },
                new Restaurant
                {
                    Restaurant_Id = 12,
                    Restaurant_code = "cD2rCiIRfaifrAuJhD-5vQ",
                    Restaurant_Name = "Dervişoğulları Restoran",
                    Restaurant_Rating = 5,
                    Restaurant_Coordinates = "38.680942, 39.207002",
                    Restaurant_Location = "Üniversite Mah. Yahya Kemal Cad., No: 54 D: 1B, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242187802"
                },
                new Restaurant
                {
                    Restaurant_Id = 13,
                    Restaurant_code = "ZLLcWmC2QZ5YCpc59-sjdg",
                    Restaurant_Name = "Kebapçı Rıza Usta",
                    Restaurant_Rating = 1,
                    Restaurant_Coordinates = "38.6820602, 39.2724991",
                    Restaurant_Location = "Yeni Mah. Yunus Emre Bulv., No: 70, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242340350"
                },
                new Restaurant
                {
                    Restaurant_Id = 14,
                    Restaurant_code = "P26OyN-VjM9F9zshZ5roEw",
                    Restaurant_Name = "Pukka Bistro & Language",
                    Restaurant_Rating = 3,
                    Restaurant_Coordinates = "38.673806, 39.170567",
                    Restaurant_Location = "Cumhuriyet Mah., Şht. Korg. Hulusi Sayın Blv. No:103, 23190 Elâzığ, Turkey",
                    Restaurant_Phone_Number = "+904242480903"
                },
                new Restaurant
                {
                    Restaurant_Id = 15,
                    Restaurant_code = "JJG8-1oGKT7OjBfUWA2KaA",
                    Restaurant_Name = "Nida Kebap Salonu",
                    Restaurant_Rating = 5,
                    Restaurant_Coordinates = "38.6292801, 39.2675705",
                    Restaurant_Location = "Olgunlar Mah. Elazığ Cad., D: 37/D, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242410211"
                },
                new Restaurant
                {
                    Restaurant_Id = 16,
                    Restaurant_code = "SyhkJ3IZg-CCqAtB53aP3Q",
                    Restaurant_Name = "Tavuk Dünyası Elazığ",
                    Restaurant_Rating = 2,
                    Restaurant_Coordinates = "38.674931, 39.220523",
                    Restaurant_Location = "Nail Bey Mah., Gazi Cad. No:9, 23100 Elâzığ, Turkey",
                    Restaurant_Phone_Number = "+904242364444"
                },
                new Restaurant
                {
                    Restaurant_Id = 17,
                    Restaurant_code = "hVZt_aMWCZ8q629i63RWoQ",
                    Restaurant_Name = "Kumpirci",
                    Restaurant_Rating = 3,
                    Restaurant_Coordinates = "38.673864, 39.176447",
                    Restaurant_Location = "Üniversite Mah., Şehit Korgeneral Hulusi Sayın Cad. No:18, 23100 Elâzığ, Turkey",
                    Restaurant_Phone_Number = "+905358414042"
                },
                new Restaurant
                {
                    Restaurant_Id = 18,
                    Restaurant_code = "ENSHPc5ZCVcsxd3ffgOZ3g",
                    Restaurant_Name = "Çiçek Börek Salonu",
                    Restaurant_Rating = 4,
                    Restaurant_Coordinates = "38.6827888, 39.2656097",
                    Restaurant_Location = "Rızaiye Mah. Emre Bulv., No: 84, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242331221"
                },
                new Restaurant
                {
                    Restaurant_Id = 19,
                    Restaurant_code = "B5czbVFNScth6Bm1XzvuMw",
                    Restaurant_Name = "Erhanlar Yöresel ev Yemekleri",
                    Restaurant_Rating = 0,
                    Restaurant_Coordinates = "38.6767693, 39.2232513",
                    Restaurant_Location = "İzzet Paşa Mah., Mehmetçik Sok. No: 36 / A, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242373731"
                },
                new Restaurant
                {
                    Restaurant_Id = 20,
                    Restaurant_code = "9uVc9itlSEbkifZ_FFE2yg",
                    Restaurant_Name = "Divan Baklava & Dondurma",
                    Restaurant_Rating = 0,
                    Restaurant_Coordinates = "38.6675301, 39.1591606",
                    Restaurant_Location = "Cumhuriyet Mah. Malatya Cad., No: 26, 23000 Elazığ, Turkey",
                    Restaurant_Phone_Number = "+904242477923"
                }
            );
        }
    }
}
