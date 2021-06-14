namespace ArtistAssignment.Migrations
{
    using ArtistAssignment.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArtistAssignment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /*
        https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
         */
        protected override void Seed(ArtistAssignment.Models.ApplicationDbContext context)
        {
            var artist = new List<Artist>
            {
                new Artist()
                {
                    ID=1,
                    FirstName="Nikos",
                    LastName="Karvelas",
                    Albums=new List<Album>
                    {
                        new Album()
                        {
                            ID=1,
                            Title="First Karvela's Album",
                            Songs=new List<Song>()
                            {
                                new Song()
                                {
                                    ID=1,
                                    Title="To Krevati"
                                },
                                new Song()
                                {
                                    ID=2,
                                    Title="Nantia"
                                }
                            },
                        },
                        new Album()
                        {
                            ID = 2,
                            Title = "Second Karvela's Album",
                            Songs = new List<Song>()
                            {
                                new Song()
                                {
                                    ID = 3,
                                    Title = "Theia Lola"
                                },
                                new Song()
                                {
                                    ID = 4,
                                    Title = "Pote min les pote"
                                }
                            }

                        }
                    }
                } ,


               new Artist
                {
                    ID = 2,
                    FirstName = "Pasxalis",
                    LastName = "Terzis",
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            ID = 3,
                            Title = "Fwtia tis Nyxtes",
                            Songs = new List<Song>()
                            {
                                new Song()
                                {
                                    ID = 5,
                                    Title = "Parastratima"
                                },
                                new Song()
                                {
                                    ID = 6,
                                    Title = "Dikaiwma mou"
                                },
                                new Song()
                                {
                                    ID = 7,
                                    Title = "Fegari mou xlomo"
                                },
                            }

                        },
                        new Album()
                        {
                            ID = 4,
                            Title = "Afise me mono",
                            Songs = new List<Song>()
                            {
                                new Song()
                                {
                                    ID = 8,
                                    Title = "Eteron sou imisi "
                                },
                                new Song()
                                {
                                    ID = 9,
                                    Title = "Ine skarti"
                                },
                                new Song()
                                {
                                    ID = 10,
                                    Title = "Ti sou ftei"
                                },
                            }

                        }
                    }
                }




            };
            artist.ForEach(a=>context.Artists.AddOrUpdate(a));
            context.SaveChanges();
        }
    }
}
