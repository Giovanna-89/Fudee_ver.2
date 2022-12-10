using Fudee_v2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fudee_v2.Data
{
    public class RestaurantSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))

                if (dbContext.Database.CanConnect())
                {
                    SeedRoles(dbContext);
                    SeedUsers(dbContext);
                    SeedCategoris(dbContext);
                    SeedAdresses(dbContext);
                    SeedRestaurants(dbContext);
                    SeedDishes(dbContext);
                    //SeedOpinions(dbContext);

                }
        }
        // Tabele które się ładują 
        //role w aplikacji
        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            var roleStore = new RoleStore<IdentityRole>(dbContext);
            if (!dbContext.Roles.Any(r => r.Name == "admin"))
            {
                roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" }).Wait();
            }

            if (!dbContext.Roles.Any(r => r.Name == "restaurator"))
            {
                roleStore.CreateAsync(new IdentityRole { Name = "restaurator", NormalizedName = "restaurator" }).Wait();
            }
        }

        //konta użytkowników
        private static void SeedUsers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any(u => u.UserName == "admin@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "admin@fudee.pl",
                    NormalizedUserName = "admin@fudee.pl",
                    Email = "admin@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Jan",
                    LastName = "Pulpecik",
                    Photo = "admin.png",
                    Information = ""

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "admin").Wait();
                dbContext.SaveChanges();

            };

            if (!dbContext.Users.Any(u => u.UserName == "restaurator1@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "restaurator1@fudee.pl",
                    NormalizedUserName = "restaurator1@fudee.pl",
                    Email = "restaurator1@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Maja",
                    LastName = "Szpinak",
                    Photo = "user.png",
                    Information = "Lorem ipsum dolor sit amet. Eum Quis distinctio ab exercitationem sapiente vel ducimus omnis et quisquam dolor ea dolorem provident."

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "restaurator").Wait();

                dbContext.SaveChanges();

            };

            if (!dbContext.Users.Any(u => u.UserName == "restaurator2@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "restaurator2@fudee.pl",
                    NormalizedUserName = "restaurator2@fudee.pl",
                    Email = "restaurator2@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Adam",
                    LastName = "Stek",
                    Photo = "person(1).png",
                    Information = "Lorem ipsum dolor sit amet. Eum Quis distinctio ab exercitationem sapiente vel ducimus omnis et quisquam dolor ea dolorem provident."

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "restaurator").Wait();

                dbContext.SaveChanges();

            };


            if (!dbContext.Users.Any(u => u.UserName == "restaurator3@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "restaurator3@fudee.pl",
                    NormalizedUserName = "restaurator3@fudee.pl",
                    Email = "restaurator3@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Malwina",
                    LastName = "Malina",
                    Photo = "person(2).png",
                    Information = "Lorem ipsum dolor sit amet. Eum Quis distinctio ab exercitationem sapiente vel ducimus omnis et quisquam dolor ea dolorem provident."

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "restaurator").Wait();

                dbContext.SaveChanges();

            };
        }

        //dodawanie danych kategorii
        private static void SeedCategoris(ApplicationDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var kat = new List<Category>
                {
                    new Category {
                        NameCategory = "Kawiarnie",
                        Icon = "1.png",
                        DescriptionCategoryy = "Zawsze jest czas na coś słodkiego."
                    },
                    new Category {
                        NameCategory = "Fast Food",
                        Icon = "2.png",
                        DescriptionCategoryy = "Szybkie smaczne potrawy w stylu amerykańskim."
                    },
                    new Category {
                        NameCategory = "Kuchnia domowa",
                        Icon = "3.png",
                        DescriptionCategoryy = "Tradycyjna polska kuchnia. Smaczne domowe obiady, jak u mamy."
                    },
                    new Category {
                        NameCategory = "Pizza",
                        Icon = "4.png",
                        DescriptionCategoryy = "Klasyczne danie włoskiej kuchni."
                    },
                    new Category {
                        NameCategory = "Kuchnia azjatycka",
                        Icon = "5.png",
                        DescriptionCategoryy = "Orientalny smak"
                    },
                    new Category {
                        NameCategory = "Inne smaki",
                        Icon = "6.png",
                        DescriptionCategoryy = "Wychodząc poza schemat, każdy znajdzie tu coś dla siebie."
                    }
                };
                dbContext.AddRange(kat);
                dbContext.SaveChanges();
            };

        }
        // koniec tabel które się ładują  

        //dodawanie restauracji
        private static void SeedRestaurants(ApplicationDbContext dbContext)
        {
            if (dbContext.Restaurants.Any())
            {
                var idRestatora1 = dbContext.AppUsers
                    .Where(u => u.UserName == "restaurator1@fudee.pl")
                    .FirstOrDefault()
                    .Id;
                var restauracja1 = new Restaurant()
                {
                    NameRestaurant = "Babcia Jadzia",
                    IdAddress = 1,
                    Logo = "d1.png",
                    DescriptionRestaurant = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis. Sed harum officia sed dolorem velit et natus eaque in voluptas molestias!",
                    HasDelivery = true,
                    HasCatering = true,
                    Events = false,
                    SocialMedia = "babciajadzia@insta",
                    AddedDate = DateTime.Now,
                    IdCategory = 3,
                    Id = idRestatora1
                };
                dbContext.Set<Restaurant>().Add(restauracja1);
                dbContext.SaveChanges();

                var restauracja2 = new Restaurant()
                {
                    NameRestaurant = "Sweet dreams",
                    IdAddress = 2,
                    Logo = "k1.png",
                    DescriptionRestaurant = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis. Sed harum officia sed dolorem velit et natus eaque in voluptas molestias!",
                    HasDelivery = false,
                    HasCatering = true,
                    Events = false,
                    SocialMedia = "sweetdreams@insta",
                    AddedDate = DateTime.Now,
                    IdCategory = 1,
                    Id = idRestatora1
                };
                dbContext.Set<Restaurant>().Add(restauracja2);
                dbContext.SaveChanges();

                var idRestatora2 = dbContext.AppUsers
                   .Where(u => u.UserName == "restaurator2@fudee.pl")
                   .FirstOrDefault()
                   .Id;
                var restauracja3 = new Restaurant()
                {
                    NameRestaurant = "Italiana Festa",
                    IdAddress = 3,
                    Logo = "p1.png",
                    DescriptionRestaurant = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis. Sed harum officia sed dolorem velit et natus eaque in voluptas molestias!",
                    HasDelivery = true,
                    HasCatering = false,
                    Events = false,
                    SocialMedia = "italianafesta@insta",
                    AddedDate = DateTime.Now,
                    IdCategory = 4,
                    Id = idRestatora2,
                };
                dbContext.Set<Restaurant>().Add(restauracja3);
                dbContext.SaveChanges();

                var restauracja4 = new Restaurant()
                {
                    NameRestaurant = "American Burger",
                    IdAddress = 4,
                    Logo = "ff2.png",
                    DescriptionRestaurant = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis. Sed harum officia sed dolorem velit et natus eaque in voluptas molestias!",
                    HasDelivery = true,
                    HasCatering = false,
                    Events = false,
                    SocialMedia = "americanburger",
                    AddedDate = DateTime.Now,
                    IdCategory = 2,
                    Id = idRestatora2,
                };
                dbContext.Set<Restaurant>().Add(restauracja3);
                dbContext.SaveChanges();

                var idRestatora3 = dbContext.AppUsers
                   .Where(u => u.UserName == "restaurator3@fudee.pl")
                   .FirstOrDefault()
                   .Id;
                var restauracja5 = new Restaurant()
                {
                    NameRestaurant = "Fast Burger",
                    IdAddress = 5,
                    Logo = "ff1.png",
                    DescriptionRestaurant = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis. Sed harum officia sed dolorem velit et natus eaque in voluptas molestias!",
                    HasDelivery = true,
                    HasCatering = false,
                    Events = false,
                    SocialMedia = "fastburger@insta",
                    AddedDate = DateTime.Now,
                    IdCategory = 2,
                    Id = idRestatora3,

                };
                dbContext.Set<Restaurant>().Add(restauracja3);
                dbContext.SaveChanges();
            }

        }

        //dodawanie adresów
        private static void SeedAdresses(ApplicationDbContext dbContext)
        {
            if (dbContext.Addresses.Any())
            {
                var adres = new List<Address>
                {
                     new Address{
                        City = "Płock",
                        StreetName = "Kozia",
                        StreetNr = "3",
                        LocalNr = 2,
                        PostCode = "09-400",
                        ContactPhone = "565656565",
                        ContactEmail = "babciajadzia@poczta.pl"
                    },
                    new Address{
                        City = "Płock",
                        StreetName = "Bielska",
                        StreetNr = "12",
                        LocalNr = 6,
                        PostCode= "09-402",
                        ContactPhone = "589989821",
                        ContactEmail = "sweetdreams@poczta.pl"
                    },
                    new Address{
                        City = "Płock",
                        StreetName = "Wyszogrodzka",
                        StreetNr = "18A",
                        LocalNr = 1,
                        PostCode= "09-406",
                        ContactPhone = "888656565",
                        ContactEmail = "italianafesta@poczta.pl"
                    },
                    new Address{
                        City = "Płock",
                        StreetName = "Tumska",
                        StreetNr = "15",
                        LocalNr = 6,
                        PostCode = "09-400",
                        ContactPhone = "6649999821",
                        ContactEmail = "americanburger@poczta.pl"

                    },
                    new Address{
                        City = "Płock",
                        StreetName = "Godzka",
                        StreetNr = "3c",
                        LocalNr = 4,
                        PostCode = "09-400",
                        ContactPhone = "1119999821",
                        ContactEmail = "fastburger@poczta.pl"

                    }
                };
                dbContext.AddRange(adres);
                dbContext.SaveChanges();
            }
        }
        //dodawanie dań


        private static void SeedDishes(ApplicationDbContext dbContext)
        {
            if (dbContext.Dishes.Any())
            {

                var danie = new List<Dish>()
                    {
                        new Dish(){
                            ImageDish = "domowa1.jpg",
                            NameDishes = "Kaczka",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 56,
                            IdRestaurant= 1
                        },
                        new Dish(){
                            ImageDish = "domowa2.jpg",
                            NameDishes = "Pierogi",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 18,
                            IdRestaurant= 1
                        },
                        new Dish(){
                            ImageDish = "slodycze1.jpg",
                            NameDishes = "Malinowa słodycz",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 12,
                            IdRestaurant= 2
                        },
                        new Dish(){
                            ImageDish = "slodycze2.jpg",
                            NameDishes = "Tiramisu",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 16,
                            IdRestaurant= 2
                        },
                        new Dish(){
                            ImageDish = "pizza1.jpg",
                            NameDishes = "Margherita",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 32,
                            IdRestaurant= 3
                        },
                        new Dish(){
                            ImageDish = "pizza2.jpg",
                            NameDishes = "Capriciosa",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 34,
                            IdRestaurant= 3
                        },
                        new Dish(){
                            ImageDish = "pizza3.jpg",
                            NameDishes = "Pizza Szefa",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 38,
                            IdRestaurant= 3
                        },
                        new Dish(){
                            ImageDish = "fastfood1.jpg",
                            NameDishes = "American Lunch",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 69,
                            IdRestaurant= 4

                        },
                        new Dish(){
                            ImageDish = "fastfood2.jpg",
                            NameDishes = "American Burger",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 32,
                            IdRestaurant= 4
                        },

                        new Dish(){
                            ImageDish = "fastfood3.jpg",
                            NameDishes = "Burger na ostro",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 29,
                            IdRestaurant= 5
                        },
                        new Dish(){
                            ImageDish = "fastfood5.jpg",
                            NameDishes = "Maxi Burger",
                            DescriptionDishes = "Lorem ipsum dolor sit amet. Ea voluptatibus perspiciatis ut cupiditate nemo qui eveniet fuga sit temporibus sapiente qui voluptatem omnis.",
                            Price = 36,
                            IdRestaurant= 5
                        }

                    };
                dbContext.AddRange(danie);
                dbContext.SaveChanges();
            }
        }

        //dodawanie treści opinii - błąd
        private static void SeedOpinions(ApplicationDbContext dbContext)
        {
            if (!dbContext.Opinions.Any())
            {
                var idUzytkownika1 = dbContext.AppUsers
                .Where(u => u.UserName == "restaurator1@fudee.pl").FirstOrDefault()
                .Id;

                for (int i = 1; i <= 5; i++)
                {
                    var komentarz = new Opinion()
                    {
                        Comment = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                        AddedDate = DateTime.Now.AddDays(-i),
                        Id = idUzytkownika1,
                        IdRestaurant = i,
                        Rating = (TypeOfGrade?)5
                    };
                    dbContext.Set<Opinion>().Add(komentarz);
                }
                dbContext.SaveChanges();

                var idUzytkownika2 = dbContext.AppUsers
                .Where(u => u.UserName == "restaurator2@fudee.pl").FirstOrDefault()
                .Id;

                for (int i = 1; i <= 5; i++)
                {
                    var komentarz = new Opinion()
                    {
                        Comment = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.",
                        AddedDate = DateTime.Now.AddDays(-i),
                        Id = idUzytkownika2,
                        IdRestaurant = i,
                        Rating = (TypeOfGrade?)4
                    };
                    dbContext.Set<Opinion>().Add(komentarz);
                }
                dbContext.SaveChanges();
            }
        }

    }
}
