namespace MMH.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MMH.Model.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MMHContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MMHContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.DocumentTypes.AddOrUpdate(dt => dt.DocumentTypeId, new DocumentType { DocumentTypeId = 1, Name = "NIF" });

            context.Documents.AddOrUpdate(dc => dc.DocumentId, new Document { DocumentId = 1, DocumentTypeId = 1, Number = "40987527" });

            context.States.AddOrUpdate(st => st.StateId, new State { StateId = 1, Name = "São Paulo" });

            context.Citys.AddOrUpdate(ct => ct.StateId, new City { CityId = 1, Name = "Capital", StateId = 1 });

            context.Addresses.AddOrUpdate(ad => ad.AddressId, new Address { AddressId = 1, CityId = 1, Neighborhood = "marajoara", PostalCode = "098312", StateId = 1, Street = "minha rua aqui" });

            if (!context.Users.Any(u => u.Email == "edward.silva@iteris.com.br"))
            {
                var store = new UserStore<Advertiser>(context);
                var manager = new UserManager<Advertiser>(store);
                var user = new Advertiser()
                {
                    Name = "Edward Carvalho",
                    BirthDate = new DateTime(1984, 10, 25),
                    Email = "edward.carvalho@gmail.com",
                    UserName = "edward.carvalho@gmail.com",
                    EmailConfirmed = true,
                    DocumentId = 1,
                    AddressId = 1
                };

                manager.Create(user, "#Teste1234");
            }
        }
    }
}
