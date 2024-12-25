using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiYemek23.Migrations
{
    /// <inheritdoc />
    public partial class azure_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Restaurant_Id", "Restaurant_Coordinates", "Restaurant_Location", "Restaurant_Name", "Restaurant_Phone_Number", "Restaurant_Rating", "Restaurant_code" },
                values: new object[,]
                {
                    { 1, "38.667326007826, 39.1802491620183", "Cumhuriyet Mh., Malatya Cad. Hazardağlı Plaza No: 58, 23100 Elazığ, Turkey", "Efendi Beyzade Restaurant & Cafe", "+904242480064", 5, "Muu1FZhmYLI6V97zpUSMag" },
                    { 2, "38.675347, 39.222602", "İzzet Paşa Mah. Şehit Yüzbaşı Tahir Cad., No: 4, 23000 Elazığ, Turkey", "Kilis Kebap Salonu 1952", "+904242367572", 5, "XaAbfWZFcW9t1eqxGaR4xw" },
                    { 3, "38.704532, 39.251641", "Harput Mah., Ahmet Kabaklı Blv. No:38, 23300 Elazığ, Turkey", "Kebapçı Halit Usta", "+904242151176", 4, "HzCYXjCrM-oMwuqWIi-aFQ" },
                    { 4, "38.6734962, 39.2241554", "Kapalıçarşı İşçiler Sok. No: 12, Elazığ, Turkey", "Kapalıçarşı Pide Fırını", "+904242378683", 5, "mrFQcvgO5EYnAKu7LSBGQg" },
                    { 5, "38.674839, 39.2172203", "Nailbey Mah., Bahçeli Sok. No: 7/A, 23000 Elazığ, Turkey", "Örnek Lokantası", "+904242361517", 0, "JRxK3RVlAYrZa9bKHnxY2Q" },
                    { 6, "38.6733093, 39.1991196", "Üniversite Mah. Zübeyde Hanım Cad., 23000 Elazığ, Turkey", "Aspirin Büfeterya", "+904242416622", 0, "1cU-59yZfDOKKG5U3-ggTg" },
                    { 7, "38.674817, 39.22252", "Harput Mah., Nadir Baba Sok. No:1, 23200 Elazığ, Turkey", "Ensar Mangal Vadisi", "+904242151033", 5, "smKx_z-IEFuBaVK_b9hOhQ" },
                    { 8, "38.703999989036, 39.255048930645", "Harput Kales Yanı, 23000 Elazığ, Turkey", "Harput Hünkar Konağı", "+904242156869", 2, "dUk8aTE1btTtIAbSKp8tfg" },
                    { 9, "38.6733093, 39.1991196", "Zübeyde Hanım Cad., No: 116/B, 23000 Elazığ, Turkey", "Çiğköfteci Hacı'nın Yeri", "+904242369060", 0, "eRPbK7RxaT2moDjko_34hg" },
                    { 10, "38.671868, 39.192114", "Zübeyde Hanım Cad., No: 102/B, 23000 Elazığ, Turkey", "Pizza Pizza", "+904242378800", 4, "XonqwJ2_GE2QGACKAtAGig" },
                    { 11, "38.6420288, 39.1216393", "Nailbey Mah. Gazi Cad., No: 51/B, 23000 Elazığ, Turkey", "Burger King", "+904242181864", 5, "rzv_N4V9blqyar27t3Tu_g" },
                    { 12, "38.680942, 39.207002", "Üniversite Mah. Yahya Kemal Cad., No: 54 D: 1B, 23000 Elazığ, Turkey", "Dervişoğulları Restoran", "+904242187802", 5, "cD2rCiIRfaifrAuJhD-5vQ" },
                    { 13, "38.6820602, 39.2724991", "Yeni Mah. Yunus Emre Bulv., No: 70, 23000 Elazığ, Turkey", "Kebapçı Rıza Usta", "+904242340350", 1, "ZLLcWmC2QZ5YCpc59-sjdg" },
                    { 14, "38.673806, 39.170567", "Cumhuriyet Mah., Şht. Korg. Hulusi Sayın Blv. No:103, 23190 Elâzığ, Turkey", "Pukka Bistro & Language", "+904242480903", 3, "P26OyN-VjM9F9zshZ5roEw" },
                    { 15, "38.6292801, 39.2675705", "Olgunlar Mah. Elazığ Cad., D: 37/D, 23000 Elazığ, Turkey", "Nida Kebap Salonu", "+904242410211", 5, "JJG8-1oGKT7OjBfUWA2KaA" },
                    { 16, "38.674931, 39.220523", "Nail Bey Mah., Gazi Cad. No:9, 23100 Elâzığ, Turkey", "Tavuk Dünyası Elazığ", "+904242364444", 2, "SyhkJ3IZg-CCqAtB53aP3Q" },
                    { 17, "38.673864, 39.176447", "Üniversite Mah., Şehit Korgeneral Hulusi Sayın Cad. No:18, 23100 Elâzığ, Turkey", "Kumpirci", "+905358414042", 3, "hVZt_aMWCZ8q629i63RWoQ" },
                    { 18, "38.6827888, 39.2656097", "Rızaiye Mah. Emre Bulv., No: 84, 23000 Elazığ, Turkey", "Çiçek Börek Salonu", "+904242331221", 4, "ENSHPc5ZCVcsxd3ffgOZ3g" },
                    { 19, "38.6767693, 39.2232513", "İzzet Paşa Mah., Mehmetçik Sok. No: 36 / A, 23000 Elazığ, Turkey", "Erhanlar Yöresel ev Yemekleri", "+904242373731", 0, "B5czbVFNScth6Bm1XzvuMw" },
                    { 20, "38.6675301, 39.1591606", "Cumhuriyet Mah. Malatya Cad., No: 26, 23000 Elazığ, Turkey", "Divan Baklava & Dondurma", "+904242477923", 0, "9uVc9itlSEbkifZ_FFE2yg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Restaurant_Id",
                keyValue: 20);
        }
    }
}
