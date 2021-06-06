using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedAddresses(modelBuilder);
            SeedResources(modelBuilder);
            SeedUserTradeItems(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                using var hmac = new HMACSHA512();
                x.HasData(
                    new User { Id = 1, FirstName = "Pieter", LastName = "Corp", IsAdmin = true, Email = "Pieter@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Pieter" },
                    new User { Id = 2, FirstName = "Nick", LastName = "Vr", IsAdmin = true, Email = "Nick@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Nick" },
                    new User { Id = 3, FirstName = "Kobe", LastName = "Delo", IsAdmin = true, Email = "Kobe@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Kobe" },
                    new User { Id = 4, FirstName = "Dries", LastName = "Maes", IsAdmin = true, Email = "Dries@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Dries" },
                    new User { Id = 5, FirstName = "BartjeWevertje", LastName = "Wevertje", IsAdmin = false, Email = "BartjeWevertje@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/BartjeWevertje" },
                    new User { Id = 6, FirstName = "Stofzuiger", LastName = "Zuiger", IsAdmin = false, Email = "Stofzuiger@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Stofzuiger" },
                    new User { Id = 7, FirstName = "Dirk", LastName = "Visser", IsAdmin = false, Email = "Dirk@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Dirk" },
                    new User { Id = 8, FirstName = "Andreas", LastName = "VanGrieken", IsAdmin = false, Email = "Andreas@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Andreas" },
                    new User { Id = 9, FirstName = "Mihiel", LastName = "Mihoen", IsAdmin = false, Email = "Mihiel@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Mihiel" },
                    new User { Id = 10, FirstName = "Luc", LastName = "DeHaantje", IsAdmin = false, Email = "Luc@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Luc" },
                    new User { Id = 11, FirstName = "Verhofstad", LastName = "Zeemlap", IsAdmin = false, Email = "VerhofstadDeZeemlap@europeesemailadres.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Zeemlap" },
                    new User { Id = 12, FirstName = "Dries", LastName = "VanKorteNekke", IsAdmin = false, Email = "Driesdentweedenmaarnidezelfden@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Dries2" },
                    new User { Id = 13, FirstName = "Joyce", LastName = "Tomatenplukker", IsAdmin = false, Email = "Joyce@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Tomatenplukker" },
                    new User { Id = 14, FirstName = "Marieke", LastName = "Van Leren Broeke", IsAdmin = false, Email = "Marieke@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "T1" },
                    new User { Id = 15, FirstName = "Anke", LastName = "Kleurenkenner", IsAdmin = false, Email = "Anke@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "27" },
                    new User { Id = 16, FirstName = "Emma", LastName = "Schoonkind", IsAdmin = false, Email = "Emma@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "45" },
                    new User { Id = 17, FirstName = "Sien", LastName = "Rommeltje", IsAdmin = false, Email = "Sien@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "57" },
                    new User { Id = 18, FirstName = "Joke", LastName = "LidlAnnoying", IsAdmin = false, Email = "Joke@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "24" },
                    new User { Id = 19, FirstName = "Karolien", LastName = "Vdabpolitie", IsAdmin = false, Email = "Karolien@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "78" },
                    new User { Id = 20, FirstName = "Hoon", LastName = "Tomatenplukker", IsAdmin = false, Email = "Hoon@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "99" },
                    new User { Id = 21, FirstName = "Michaël", LastName = "Wanderer", IsAdmin = false, Email = "Michaël@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "25" },
                    new User { Id = 22, FirstName = "Brent", LastName = "Tomatentrucker", IsAdmin = false, Email = "Brent@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "29" }
                    );
            });
        }

        private static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(x =>
            {
                x.HasData(
                new Address
                {
                    Id = 1,
                    StreetName = "Anti-Veggiestraat",
                    StreetNumber = 89,
                    PostalCode = 9000,
                    UserId = 1
                },
                new Address
                {
                    Id = 2,
                    StreetName = "Vrbaan",
                    StreetNumber = 45,
                    PostalCode = 3000,
                    UserId = 2
                },
                new Address
                {
                    Id = 3,
                    StreetName = "Balletjesstraat",
                    StreetNumber = 74,
                    PostalCode = 4000,
                    UserId = 3
                },
                new Address
                {
                    Id = 4,
                    StreetName = "Vleesbroodstraat",
                    StreetNumber = 66,
                    PostalCode = 1000,
                    UserId = 4
                },
                new Address
                {
                    Id = 5,
                    StreetName = "Boerenworststraat",
                    StreetNumber = 85,
                    PostalCode = 9000,
                    UserId = 5
                },
                new Address
                {
                    Id = 6,
                    StreetName = "Spekmeteierenstraat",
                    StreetNumber = 43,
                    PostalCode = 1000,
                    UserId = 6
                },
                new Address
                {
                    Id = 7,
                    StreetName = "Greenpeacestraat",
                    StreetNumber = 1,
                    PostalCode = 9050,
                    UserId = 7
                },
                new Address
                {
                    Id = 8,
                    StreetName = "Kotsvisplein",
                    StreetNumber = 96,
                    PostalCode = 1000,
                    UserId = 8
                },
                new Address
                {
                    Id = 9,
                    StreetName = "Greenlivesweg",
                    StreetNumber = 420,
                    PostalCode = 2000,
                    UserId = 9
                },
                new Address
                {
                    Id = 10,
                    StreetName = "Geenpolitiekstraat",
                    StreetNumber = 200,
                    PostalCode = 9070,
                    UserId = 10
                },
                new Address
                {
                    Id = 11,
                    StreetName = "Kalfslapjesstraat",
                    StreetNumber = 32,
                    PostalCode = 9500,
                    UserId = 11
                },
                new Address
                {
                    Id = 12,
                    StreetName = "Blacklivesmatterstraat",
                    StreetNumber = 78,
                    PostalCode = 1000,
                    UserId = 12
                },
                new Address
                {
                    Id = 13,
                    StreetName = "Worstenbroodjesstraat",
                    StreetNumber = 4,
                    PostalCode = 7000,
                    UserId = 13
                },
                new Address
                {
                    Id = 14,
                    StreetName = "Jurgenverstopstraat",
                    StreetNumber = 24,
                    PostalCode = 9000,
                    UserId = 14
                },
                new Address
                {
                    Id = 15,
                    StreetName = "Bloedworststraat",
                    StreetNumber = 78,
                    PostalCode = 1081,
                    UserId = 15
                },
                new Address
                {
                    Id = 16,
                    StreetName = "Runderlendedreef",
                    StreetNumber = 36,
                    PostalCode = 1180,
                    UserId = 16
                },
                new Address
                {
                    Id = 17,
                    StreetName = "Ribbetjesstraat",
                    StreetNumber = 14,
                    PostalCode = 1500,
                    UserId = 17
                },
                new Address
                {
                    Id = 18,
                    StreetName = "Bickyburgerstraat",
                    StreetNumber = 15,
                    PostalCode = 2070,
                    UserId = 18
                },
                new Address
                {
                    Id = 19,
                    StreetName = "Lookbroodjesstraat",
                    StreetNumber = 11,
                    PostalCode = 2323,
                    UserId = 19
                },
                new Address
                {
                    Id = 20,
                    StreetName = "Worstenbroodjesstraat",
                    StreetNumber = 79,
                    PostalCode = 2890,
                    UserId = 20
                },
                new Address
                {
                    Id = 21,
                    StreetName = "Balletjesstraat",
                    StreetNumber = 100,
                    PostalCode = 3020,
                    UserId = 21
                },
                new Address
                {
                    Id = 22,
                    StreetName = "Kalfsrib-eyelaan",
                    StreetNumber = 107,
                    PostalCode = 3110,
                    UserId = 22
                }

                );
            }
            );
        }

        private static void SeedResources(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(x =>
            {
                x.HasData(
                    new Resource { Id = 1, Name = "apples", ImageUrl = "apples.svg" },
                    new Resource { Id = 2, Name = "artichokes", ImageUrl = "artichokes.svg" },
                    new Resource { Id = 3, Name = "asparagus", ImageUrl = "asparagus.svg" },
                    new Resource { Id = 4, Name = "bananas", ImageUrl = "bananas.svg" },
                    new Resource { Id = 5, Name = "bell-peppers", ImageUrl = "bell-peppers.svg" },
                    new Resource { Id = 6, Name = "blueberries", ImageUrl = "blueberries.svg" },
                    new Resource { Id = 7, Name = "bok-choy", ImageUrl = "bok-choy.svg" },
                    new Resource { Id = 8, Name = "broccoli", ImageUrl = "broccoli.svg" },
                    new Resource { Id = 9, Name = "brussels-sprouts", ImageUrl = "brussels-sprouts.svg" },
                    new Resource { Id = 10, Name = "carrots", ImageUrl = "carrots.svg" },
                    new Resource { Id = 11, Name = "cherries", ImageUrl = "cherries.svg" },
                    new Resource { Id = 12, Name = "chilis", ImageUrl = "chilis.svg" },
                    new Resource { Id = 13, Name = "coconuts", ImageUrl = "coconuts.svg" },
                    new Resource { Id = 14, Name = "coriander", ImageUrl = "coriander.svg" },
                    new Resource { Id = 15, Name = "corn", ImageUrl = "corn.svg" },
                    new Resource { Id = 16, Name = "cucumbers", ImageUrl = "cucumbers.svg" },
                    new Resource { Id = 17, Name = "dragon-fruits", ImageUrl = "dragon-fruits.svg" },
                    new Resource { Id = 18, Name = "durians", ImageUrl = "durians.svg" },
                    new Resource { Id = 19, Name = "eggplants", ImageUrl = "eggplants.svg" },
                    new Resource { Id = 20, Name = "garlic", ImageUrl = "garlic.svg" },
                    new Resource { Id = 21, Name = "grapes", ImageUrl = "grapes.svg" },
                    new Resource { Id = 22, Name = "guavas", ImageUrl = "guavas.svg" },
                    new Resource { Id = 23, Name = "kiwis", ImageUrl = "kiwis.svg" },
                    new Resource { Id = 24, Name = "lemons", ImageUrl = "lemons.svg" },
                    new Resource { Id = 25, Name = "mangos", ImageUrl = "mangos.svg" },
                    new Resource { Id = 26, Name = "mangosteens", ImageUrl = "mangosteens.svg" },
                    new Resource { Id = 27, Name = "melons", ImageUrl = "melons.svg" },
                    new Resource { Id = 28, Name = "mushrooms", ImageUrl = "mushrooms.svg" },
                    new Resource { Id = 29, Name = "olives", ImageUrl = "olives.svg" },
                    new Resource { Id = 30, Name = "oranges", ImageUrl = "oranges.svg" },
                    new Resource { Id = 31, Name = "papayas", ImageUrl = "papayas.svg" },
                    new Resource { Id = 32, Name = "peaches", ImageUrl = "peaches.svg" },
                    new Resource { Id = 33, Name = "pears", ImageUrl = "pears.svg" },
                    new Resource { Id = 34, Name = "peas", ImageUrl = "peas.svg" },
                    new Resource { Id = 35, Name = "pineapples", ImageUrl = "pineapples.svg" },
                    new Resource { Id = 36, Name = "pomegranates", ImageUrl = "pomegranates.svg" },
                    new Resource { Id = 37, Name = "potatoes", ImageUrl = "potatoes.svg" },
                    new Resource { Id = 38, Name = "pumpkins", ImageUrl = "pumpkins.svg" },
                    new Resource { Id = 39, Name = "radish", ImageUrl = "radish.svg" },
                    new Resource { Id = 40, Name = "radishes", ImageUrl = "radishes.svg" },
                    new Resource { Id = 41, Name = "raspberries", ImageUrl = "raspberries.svg" },
                    new Resource { Id = 42, Name = "salad", ImageUrl = "salad.svg" },
                    new Resource { Id = 43, Name = "salads", ImageUrl = "salads.svg" },
                    new Resource { Id = 44, Name = "scallions", ImageUrl = "scallions.svg" },
                    new Resource { Id = 45, Name = "spinach", ImageUrl = "spinach.svg" },
                    new Resource { Id = 46, Name = "star-fruits", ImageUrl = "star-fruits.svg" },
                    new Resource { Id = 47, Name = "strawberries", ImageUrl = "strawberries.svg" },
                    new Resource { Id = 48, Name = "sweet-potatoes", ImageUrl = "sweet-potatoes.svg" },
                    new Resource { Id = 49, Name = "tomatoes", ImageUrl = "tomatoes.svg" },
                    new Resource { Id = 50, Name = "watermelons", ImageUrl = "watermelons.svg" },
                    new Resource { Id = 51, Name = "v-coin", ImageUrl = "v-coin.svg" }
                  );
            }
            );
        }

        private static void SeedUserTradeItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTradeItem>(x =>
            {
                using var hmac = new HMACSHA512();
                x.HasData(
                    new UserTradeItem { Id = 1, Amount = 50, UserId = 1, ResourceId = 1 },
                    new UserTradeItem { Id = 2, Amount = 50, UserId = 1, ResourceId = 2 },
                    new UserTradeItem { Id = 3, Amount = 50, UserId = 1, ResourceId = 3 },
                    new UserTradeItem { Id = 4, Amount = 50, UserId = 2, ResourceId = 10 },
                    new UserTradeItem { Id = 5, Amount = 50, UserId = 2, ResourceId = 11 },
                    new UserTradeItem { Id = 6, Amount = 50, UserId = 2, ResourceId = 12 },
                    new UserTradeItem { Id = 7, Amount = 50, UserId = 3, ResourceId = 1 },
                    new UserTradeItem { Id = 8, Amount = 50, UserId = 3, ResourceId = 5 },
                    new UserTradeItem { Id = 9, Amount = 50, UserId = 4, ResourceId = 7 },
                    new UserTradeItem { Id = 10, Amount = 50, UserId = 4, ResourceId = 20 },
                    new UserTradeItem { Id = 11, Amount = 50, UserId = 4, ResourceId = 21 },
                    new UserTradeItem { Id = 12, Amount = 50, UserId = 4, ResourceId = 22 },
                    new UserTradeItem { Id = 13, Amount = 50, UserId = 5, ResourceId = 1 },
                    new UserTradeItem { Id = 14, Amount = 50, UserId = 5, ResourceId = 2 },
                    new UserTradeItem { Id = 15, Amount = 50, UserId = 6, ResourceId = 3 },
                    new UserTradeItem { Id = 16, Amount = 50, UserId = 6, ResourceId = 10 },
                    new UserTradeItem { Id = 17, Amount = 50, UserId = 6, ResourceId = 11 },
                    new UserTradeItem { Id = 18, Amount = 50, UserId = 6, ResourceId = 12 },
                    new UserTradeItem { Id = 19, Amount = 50, UserId = 7, ResourceId = 1 },
                    new UserTradeItem { Id = 20, Amount = 50, UserId = 7, ResourceId = 5 },
                    new UserTradeItem { Id = 21, Amount = 50, UserId = 7, ResourceId = 7 },
                    new UserTradeItem { Id = 22, Amount = 50, UserId = 8, ResourceId = 20 },
                    new UserTradeItem { Id = 23, Amount = 50, UserId = 8, ResourceId = 21 },
                    new UserTradeItem { Id = 24, Amount = 50, UserId = 9, ResourceId = 11 },
                    new UserTradeItem { Id = 25, Amount = 50, UserId = 9, ResourceId = 12 },
                    new UserTradeItem { Id = 26, Amount = 50, UserId = 9, ResourceId = 10 },
                    new UserTradeItem { Id = 27, Amount = 50, UserId = 10, ResourceId = 35 },
                    new UserTradeItem { Id = 28, Amount = 50, UserId = 10, ResourceId = 37 },
                    new UserTradeItem { Id = 29, Amount = 50, UserId = 10, ResourceId = 30 },
                    new UserTradeItem { Id = 30, Amount = 50, UserId = 10, ResourceId = 31 }
                    );
            });
        }

    }
}
