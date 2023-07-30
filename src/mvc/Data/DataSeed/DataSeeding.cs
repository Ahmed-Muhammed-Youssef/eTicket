using Microsoft.AspNetCore.Identity;
using mvc.Data.Enums;
using mvc.Data.Static;
using mvc.Models;

namespace mvc.Data.DataSeed
{
    public class DataSeeding
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                try
                {
                    // context?.Database.EnsureCreated();

                    // cinema

                    if (!context!.Cinemas.Any())
                    {
                        context.Cinemas.AddRange(new List<Cinema>()
                        {
                            new Cinema()
                            {
                                Name = "Vox",
                                Description = "Owned and operated by Majid Al Futtaim Entertainment, VOX Cinemas is the cinema arm of Majid Al Futtaim, the leading shopping malls, communities, retail and leisure pioneer across the Middle East, Africa and Central Asia. VOX Cinemas is the Middle East’s most innovative and customer-focused exhibitor, and the fastest growing cinema business in the MENA region. With 57 locations totalling 573 screens across the region, including 237 screens in the UAE, 15 screens in Lebanon, 63 screens in Oman, 30 screens in Bahrain, 44 screens in Egypt, 149 screens in Saudi Arabia and 17 screens in Kuwait, VOX Cinemas is the Middle East’s largest and most rapidly growing exhibitor. ",
                                Image = new Image()
                                {
                                    ImagePath = "images/test/cinemas/vox.jpeg"
                                }
                            },
                            new Cinema()
                            {
                                Name = "Galaxy",
                                Description = "located at 26th of July Corridor, Al Giza Desert, Giza Governorate.",
                                Image = new Image()
                                {
                                    ImagePath = "images/test/cinemas/galaxy.jpg"
                                }
                            },
                            new Cinema()
                            {
                                Name = "Sun City",
                                Description = "Suncity Entertainments Pvt Ltd was established in June 2004. Suncity Cinemas is the Hisar’s perfect entertainment destination for people from all walks of life, from all ages and users.",
                                Image = new Image()
                                {
                                    ImagePath = "images/test/cinemas/suncity.jpeg"
                                }
                            }
                        });
                        context.SaveChanges();

                    }
                   
                    if (!context.Actors.Any())
                    {
                        context.Actors.AddRange(new List<Actor>(){
                            new Actor()
                            {
                                FullName = "Ryan Thomas Gosling",
                                Bio = "Canadian actor who is Prominent in both independent film and major studio features of varying genres, his films have accrued a worldwide box office gross of over 1.9 billion USD.",
                                Image = new Image() { ImagePath = "images/test/actors/actor-ryan-gosling.webp" }
                            },
                            new Actor()
                            {
                                FullName = "Matt LeBlanc",
                                Bio = "American actor garnered global recognition with his portrayal of Joey Tribbiani in the NBC sitcom Friends and in its spin-off series, Joey. For his work on Friends, LeBlanc received three nominations at the Primetime Emmy Awards. He has also starred as a fictionalized version of himself in Episodes (2011–2017), for which he won a Golden Globe Award and received four additional Emmy Award nominations. He co-hosted Top Gear from 2016 to 2019. From 2016 to 2020, he played patriarch Adam Burns in the CBS sitcom Man with a Plan.",
                                Image = new Image { ImagePath = "images/test/actors/actorMatt-LeBlanc-232420843.jpeg" }
                            },
                            new Actor()
                            {
                                FullName = "Margot Robbie",
                                Bio = "Australian actress and producer who is Known for her work in both blockbuster and independent films, she has received various accolades, including nominations for two Academy Awards, four Golden Globe Awards, and five British Academy Film Awards.",
                                Image = new Image { ImagePath = "images/test/actors/actor-margot.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Michael Cera",
                                Bio = "Canadian actor who is known for his awkward, offbeat characters in coming of age comedy films and for portraying George Michael Bluth in the sitcom Arrested Development. He is also known for portraying Brother Bear in The Berenstain Bears.",
                                Image = new Image { ImagePath = "images/test/actors/actor-michael.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Will Ferrell",
                                Bio = "American actor, comedian, writer, and producer. Ferrell is known for his leading man roles in comedy films and for his work as a television producer. He has earned four Emmy Awards and in 2011 was honored with the Mark Twain Prize for American Humor.",
                                Image = new Image { ImagePath = "images/test/actors/actor-will-ferrell.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Cillian Murphy",
                                Bio = "Irish actor who made his professional debut in Enda Walsh's 1996 play Disco Pigs, a role he later reprised in the 2001 screen adaptation.",
                                Image = new Image { ImagePath = "images/test/actors/actor-Cillian-Murphy.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Robert Downey Jr.",
                                Bio = "Robert John Downey Jr. is an American actor. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career.",
                                Image = new Image { ImagePath = "images/test/actors/actor-Robert_Downey.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Rami Malek",
                                Bio = "Rami Said Malek is an American actor. He is known for portraying computer hacker Elliot Alderson in the USA Network television series Mr. Robot, for which he received the Primetime Emmy Award.",
                                Image= new Image { ImagePath = "images/test/actors/actor-Rami.webp" }
                            }
                        });

                        context.SaveChanges();
                    }
                    if (!context.Directors.Any())
                    {
                        context.Directors.AddRange(new List<Director>()
                        {
                            new Director()
                            {
                                FullName = "Greta Gerwig",
                                Bio = "an American director, screenwriter, and actress who first garnered attention after working on and appearing in several mumblecore movies.",
                                Image = new Image() { ImagePath = "images/test/directors/greta-gerwig.jpeg" }

                            },
                            new Director()
                            {
                                FullName = "Christopher Nolan",
                                Bio = "Christopher Edward Nolan CBE is a British and American filmmaker. Known for his Hollywood blockbusters with complex storytelling, Nolan is considered a leading filmmaker of the 21st century. His films have grossed $5 billion worldwide.",
                                Image = new Image() { ImagePath = "images/test/directors/cristopher-nolan.jpeg" }

                            },
                            new Director()
                            {
                                FullName = "Christopher McQuarrie",
                                Bio = "Christopher McQuarrie is an American film director, producer and screenwriter. He received the BAFTA Award, Independent Spirit Award, and Academy Award for Best Original Screenplay for the neo-noir mystery film The Usual Suspects. He made his directorial debut with the crime thriller film The Way of the Gun.",
                                Image = new Image() { ImagePath = "images/test/directors/Christopher_McQuarrie.jpg" }

                            },
                            new Director()
                            {
                                FullName = "Peter Sohn",
                                Bio = "Peter Sohn is an American animator, filmmaker, and voice actor, best known for his work at Pixar Animation Studios. He directed the short film Partly Cloudy and the feature films The Good Dinosaur and Elemental. He has also been the voice of Emile in Ratatouille, Squishy in Monsters University, and Sox in Lightyear.",
                                Image = new Image() { ImagePath = "images/test/directors/peter.jpeg" }
                            },
                            new Director()
                            {
                                FullName = "Alejandro Monteverde",
                                Bio = "José Alejandro Gómez Monteverde is a Mexican film director. His first film, Bella, took top prize at the 2006 Toronto International Film Festival by winning the \"People's Choice Award\".",
                                Image = new Image() { ImagePath = "images/test/directors/gomez.webp" }
                            }

                        });
                        context.SaveChanges();
                    }
                   /* if (!context.Movie.Any())
                    {
                        context.Movie.AddRange(new List<Movie>()
                        {
                            new Movie()
                            {
                                Name = "Life",
                                Description = "This is the Life movie description",
                                Price = 39.50M,
                                ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                                StratDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(10),
                                CinemaId = 3,
                                ProducerId = 3,
                                MovieCategory = MovieCategory.Documentary
                            },
                            new Movie()
                            {
                                Name = "The Shawshank Redemption",
                                Description = "This is the Shawshank Redemption description",
                                Price = 29.50M,
                                ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                                StratDate = DateTime.Now,
                                EndDate = DateTime.Now.AddDays(3),
                                CinemaId = 1,
                                ProducerId = 1,
                                MovieCategory = MovieCategory.Action
                            },
                            new Movie()
                            {
                                Name = "Ghost",
                                Description = "This is the Ghost movie description",
                                Price = 39.50M,
                                ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                                StratDate = DateTime.Now,
                                EndDate = DateTime.Now.AddDays(7),
                                CinemaId = 4,
                                ProducerId = 4,
                                MovieCategory = MovieCategory.Horror
                            },
                            new Movie()
                            {
                                Name = "Race",
                                Description = "This is the Race movie description",
                                Price = 39.50M,
                                ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                                StratDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(-5),
                                CinemaId = 1,
                                ProducerId = 2,
                                MovieCategory = MovieCategory.Documentary
                            },
                            new Movie()
                            {
                                Name = "Scoob",
                                Description = "This is the Scoob movie description",
                                Price = 39.50M,
                                ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                                StratDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(-2),
                                CinemaId = 1,
                                ProducerId = 3,
                                MovieCategory = MovieCategory.Cartoon
                            },
                            new Movie()
                            {
                                Name = "Cold Soles",
                                Description = "This is the Cold Soles movie description",
                                Price = 39.50M,
                                ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                                StratDate = DateTime.Now.AddDays(3),
                                EndDate = DateTime.Now.AddDays(20),
                                CinemaId = 1,
                                ProducerId = 5,
                                MovieCategory = MovieCategory.Drama
                            }
                        });
                        context.SaveChanges();
                    }*/
                   /* if (!context.ActorMovie.Any())
                    {
                        context.ActorMovie.AddRange(new List<ActorMovie>()
                        {
                            new ActorMovie()
                            {
                                ActorId = 1,
                                MovieId = 1
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 1
                            },

                             new ActorMovie()
                            {
                                ActorId = 1,
                                MovieId = 2
                            },
                             new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 2
                            },

                            new ActorMovie()
                            {
                                ActorId = 1,
                                MovieId = 3
                            },
                            new ActorMovie()
                            {
                                ActorId = 2,
                                MovieId = 3
                            },
                            new ActorMovie()
                            {
                                ActorId = 5,
                                MovieId = 3
                            },


                            new ActorMovie()
                            {
                                ActorId = 2,
                                MovieId = 4
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 4
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 4
                            },


                            new ActorMovie()
                            {
                                ActorId = 2,
                                MovieId = 5
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 5
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 5
                            },
                            new ActorMovie()
                            {
                                ActorId = 5,
                                MovieId = 5
                            },


                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 6
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 6
                            },
                            new ActorMovie()
                            {
                                ActorId = 5,
                                MovieId = 6
                            },
                        });
                        context.SaveChanges();
                    }*/

                }
                catch (Exception ex)
                {
                    throw new Exception("Seeding data error", ex);
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
                try
                {
                    // Add Roles
                    if (await roleManager!.RoleExistsAsync(UserRolesValues.Admin) == false)
                    {
                        await roleManager!.CreateAsync(new IdentityRole(UserRolesValues.Admin));
                    }
                    if (await roleManager!.RoleExistsAsync(UserRolesValues.User) == false)
                    {
                        await roleManager!.CreateAsync(new IdentityRole(UserRolesValues.User));
                    }


                    // Add users
                    var adminUser = await userManager!.FindByEmailAsync(configuration.GetSection("AdminUser")["Email"]!);
                    if(adminUser == null) 
                    {
                        adminUser = new AppUser()
                        {
                            FirstName = configuration.GetSection("AdminUser")["FirstName"]!,
                            LastName = configuration.GetSection("AdminUser")["LastName"]!,
                            UserName = configuration.GetSection("AdminUser")["UserName"]!,
                            Email = configuration.GetSection("AdminUser")["Email"]!,
                            EmailConfirmed = true
                        };
                        await userManager.CreateAsync(adminUser, configuration.GetSection("AdminUser")["Password"]!);
                        await userManager.AddToRoleAsync(adminUser, UserRolesValues.Admin);
                    }

                    var testUser = await userManager!.FindByEmailAsync(configuration.GetSection("TestUser")["Email"]!);
                    if (testUser == null)
                    {
                        testUser = new AppUser()
                        {
                            FirstName = configuration.GetSection("TestUser")["FirstName"]!,
                            LastName = configuration.GetSection("TestUser")["LastName"]!,
                            UserName = configuration.GetSection("TestUser")["UserName"]!,
                            Email = configuration.GetSection("TestUser")["Email"]!,
                            EmailConfirmed = true
                        };
                        await userManager.CreateAsync(testUser, configuration.GetSection("TestUser")["Password"]!);
                        await userManager.AddToRoleAsync(testUser, UserRolesValues.User);
                    }

                    await context!.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Seeding users and roles error", ex);
                }
            }
        }
    }
}
