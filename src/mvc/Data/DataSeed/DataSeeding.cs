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
                    // lists
                    var actors = new List<Actor>(){
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
                            },
                             new Actor()
                            {
                                FullName = "Leah Lewis",
                                Bio = "Leah Lewis is an American actress. She is best known for her roles as Ellie Chu in the Netflix film The Half of It and Georgia \"George\" Fan in The CW series adaptation of Nancy Drew. She also voicing her lead role as Ember Lumen in the Pixar animated film Elemental.",
                                Image= new Image { ImagePath = "images/test/actors/Leah_Lewis.webp" }
                            },
                            new Actor()
                            {
                                FullName = "Tom Cruise",
                                Bio = "Thomas Cruise Mapother IV, known professionally by his stage name Tom Cruise, is an American actor and producer. One of the world's highest-paid actors, he has received various accolades, including an Honorary Palme d'Or and three Golden Globe Awards, in addition to nominations for four Academy Awards.",
                                Image= new Image { ImagePath = "images/test/actors/tom.jpg" }
                            }
                        };
                    if (!context!.Actors.Any())
                    {
                        context.Actors.AddRange(actors);

                        context.SaveChanges();
                    }
                    var cinemas = new List<Cinema>()
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
                        };
                    if (!context!.Cinemas.Any())
                    {
                        context.Cinemas.AddRange(cinemas);
                        context.SaveChanges();

                    }
                    var directors = new List<Director>()
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
                    };
                    if (!context.Directors.Any())
                    {
                        context.Directors.AddRange(directors);
                        context.SaveChanges();
                    }

                    var movies = new List<Movie>()
                        {
                            new Movie()
                            {
                                Name = "Barbie",
                                Description = "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.",
                                Price = 60.00M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[2].Id,
                                Cinema = cinemas[2],
                                MovieCategory = MovieCategory.Drama,
                                DirectorId = cinemas[0].Id,
                                Director = directors[0],
                                Image = new Image() { ImagePath = "images/test/movies/barbie.webp" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[0],
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[2]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[3]
                                    }
                                }
                            },
                            new Movie()
                            {
                                Name = "Elemental",
                                Description = "In a city where fire, water, land, and air residents live together, a fiery young woman and a go-with-the-flow guy discover something elemental: how much they actually have in common.",
                                Price = 29.50M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[0].Id,
                                Cinema = cinemas[0],
                                MovieCategory = MovieCategory.Comedy,
                                DirectorId = directors[3].Id,
                                Director = directors[3],
                                Image = new Image() { ImagePath = "images/test/movies/elemental.jpg" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[8]
                                    }
                                }
                            },
                            new Movie()
                            {
                                Name = "Oppenheimer",
                                Description = "During World War II, Lt. Gen. Leslie Groves Jr. appoints physicist J. Robert Oppenheimer to work on the top-secret Manhattan Project. Oppenheimer and a team of scientists spend years developing and designing the atomic bomb. Their work comes to fruition on July 16, 1945, as they witness the world's first nuclear explosion, forever changing the course of history.",
                                Price = 50.00M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[1].Id,
                                Cinema = cinemas[1],
                                MovieCategory = MovieCategory.Documentary,
                                DirectorId = directors[1].Id,
                                Director = directors[1],
                                Image = new Image() { ImagePath = "images/test/movies/film-oppen.jpeg" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[4]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[5]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[6]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[7]
                                    }
                                }
                            },
                            new Movie()
                            {
                                Name = "Mission: Impossible – Dead Reckoning Part One",
                                Description = "Ethan Hunt and the IMF team must track down a terrifying new weapon that threatens all of humanity if it falls into the wrong hands. With control of the future and the fate of the world at stake, a deadly race around the globe begins. Confronted by a mysterious, all-powerful enemy, Ethan is forced to consider that nothing can matter more than the mission -- not even the lives of those he cares about most.",
                                Price = 40.50M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[0].Id,
                                Cinema = cinemas[0],
                                MovieCategory = MovieCategory.Action,
                                DirectorId = directors[2].Id,
                                Director = directors[2],
                                Image = new Image() { ImagePath = "images/test/movies/Impossible.jpg" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[9]
                                    }
                                }
                            }
                        };
                    if (!context.Movies.Any())
                    {
                        context.Movies.AddRange(movies);
                        context.SaveChanges();
                    }
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
                            EmailConfirmed = true,
                            PhoneNumber = configuration.GetSection("AdminUser")["PhoneNumber"]!,
                            PhoneNumberConfirmed = true
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
                            EmailConfirmed = true,
                            PhoneNumber = configuration.GetSection("TestUser")["PhoneNumber"]!,
                            PhoneNumberConfirmed = true
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
