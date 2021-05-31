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
            SeedResources(modelBuilder);            
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
                    new User { Id = 13, FirstName = "Joyce", LastName = "Tomatenplukker", IsAdmin = false, Email = "Joyce@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Tomatenplukker" }
                    );
            });
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

    }
}
