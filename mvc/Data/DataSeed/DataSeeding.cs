using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

                    if (!context!.Cinema.Any())
                    {
                        context.Cinema.AddRange(new List<Cinema>()
                        {
                            new Cinema()
                            {
                                Name = "Cinema 1",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                            new Cinema()
                            {
                                Name = "Cinema 2",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                            new Cinema()
                            {
                                Name = "Cinema 3",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                            new Cinema()
                            {
                                Name = "Cinema 4",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                            new Cinema()
                            {
                                Name = "Cinema 5",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                                Description = "This is the description of the first cinema"
                            }
                        });
                        context.SaveChanges();

                    }
                    if (!context.Actor.Any())
                    {
                        context.Actor.AddRange(new List<Actor>()
                        {
                            new Actor()
                            {
                                FullName = "Actor 1",
                                Bio = "This is the Bio of the first actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                            },
                            new Actor()
                            {
                                FullName = "Actor 2",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                            },
                            new Actor()
                            {
                                FullName = "Actor 3",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                            },
                            new Actor()
                            {
                                FullName = "Actor 4",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                            },
                            new Actor()
                            {
                                FullName = "Actor 5",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                            }
                        });
                        context.SaveChanges();
                    }
                    if (!context.Producer.Any())
                    {
                        context.Producer.AddRange(new List<Producer>()
                        {
                            new Producer()
                            {
                                FullName = "Producer 1",
                                Bio = "This is the Bio of the first actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                            },
                            new Producer()
                            {
                                FullName = "Producer 2",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                            },
                            new Producer()
                            {
                                FullName = "Producer 3",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                            },
                            new Producer()
                            {
                                FullName = "Producer 4",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                            },
                            new Producer()
                            {
                                FullName = "Producer 5",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                            }
                        });
                        context.SaveChanges();
                    }
                    if (!context.Movie.Any())
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
                    }
                    if (!context.ActorMovie.Any())
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
