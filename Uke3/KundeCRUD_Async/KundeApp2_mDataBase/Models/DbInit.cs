using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KundeApp2_mDataBase.Models
{
    public static class DbInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<KundeDB>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var poststed1 = new Poststed
                {
                    postNr = "1463",
                    postSted = "Fjellhamar"
                };
                var poststed2 = new Poststed
                {
                    postNr = "0270",
                    postSted = "Oslo"
                };

                var kunde1 = new Kunder
                {
                    forNavn = "Ole",
                    etterNavn = "Knoph",
                    adresse = "Haneborg Alle 35",
                    postSted = poststed1
                };
                var kunde2 = new Kunder
                {
                    forNavn = "Madelen",
                    etterNavn = "Halnes",
                    adresse = "Osloveien 2",
                    postSted = poststed2
                };

                context.Kunder.Add(kunde1);
                context.Kunder.Add(kunde2);

                context.SaveChanges();
            }
        }
    }
}

