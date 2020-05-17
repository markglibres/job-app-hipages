using System;
using System.Collections.Generic;
using Leads.Domain.Entities;
using Leads.Domain.Services;
using Leads.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Presentation.Api.Seed
{
    public static class SeedJobs
    {
        public static void EnsureSeedData(IServiceProvider services)
        {
            var service = services.GetService<IJobService>();

            foreach (var data in SeedData())
            {
                var isExists = service.IsExists(data.ReferenceId).Result;
                if(isExists) continue;

                var entity = service
                    .Create(
                        data.Contact.Name,
                        data.Contact.Phone,
                        data.Contact.Email,
                        data.Price,
                        data.Description,
                        data.SuburbId,
                        data.CategoryId,
                        data.ReferenceId)
                    .Result;
            }
        }

        private static IEnumerable<Job> SeedData()
        {
            return new List<Job>
            {
                new Job(
                    20,
                    "Integer aliquam pulvinar odio et convallis. Integer id tristique ex. " +
                    "Aenean scelerisque massa vel est sollicitudin vulputate. Suspendisse quis ex eu " +
                    "ligula elementum suscipit nec a est. Aliquam a gravida diam. Donec placerat magna " +
                    "posuere massa maximus vehicula. Cras nisl ipsum, fermentum nec odio in, ultricies" +
                    " dapibus risus. Vivamus neque.",
                    new Contact("Luke Skywalker", "0412345678", "luke@mailinator.com"),
                    1, 1, Guid.Parse("f054da6c-9821-11ea-bb37-0242ac130002")),
                new Job(
                    30, "Praesent elit dui, blandit eget nisl sed, ornare pharetra urna. " +
                        "In cursus auctor tellus. Quisque ligula metus, viverra nec nibh ut, sagittis luctus " +
                        "tellus. Nulla egestas nibh ut diam vehicula, ut auctor lectus pharetra. " +
                        "Aliquam condimentum, erat eget vehicula eleifend, nulla risus consequat augue, " +
                        "quis convallis mi diam et dui.",
                    new Contact("Darth Vader", "0422223333", "darth@mailinator.com"),
                    2, 2, Guid.Parse("2a884e74-9824-11ea-bb37-0242ac130002")),
                new Job(
                    45, "Aliquam posuere est sit amet libero egestas tempus. Donec ut " +
                        "efficitur sapien. Sed molestie nec lacus malesuada suscipit. Aliquam suscipit nibh" +
                        " at posuere tempor. Etiam a sollicitudin felis. In et enim leo. Morbi vel " +
                        "imperdiet purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Etiam posuere auctor elit, id venenatis.",
                    new Contact("Han Solo", "0498765432", "han@mailinator.com"),
                    3, 3, Guid.Parse("52b1ebda-9824-11ea-bb37-0242ac130002")),
                new Job(
                    15, "Proin semper consectetur mauris id commodo. In accumsan est ligula, " +
                        "id posuere libero placerat ac. Nunc non volutpat sem. Mauris gravida dictum " +
                        "eleifend. Praesent quis mattis arcu, rutrum sagittis diam. Nullam tempus sagittis " +
                        "diam, vel viverra nunc ultricies non. Sed at orci sem. Phasellus eget arcu " +
                        "hendrerit, congue metus ut, mollis tellus. Quisque gravida metus ut libero porta, " +
                        "sit amet rutrum odio porta. Fusce interdum est sed quam venenatis dictum. Integer " +
                        "ultrices est in odio semper dictum. Proin nec urna vel quam finibus maximus.Sed " +
                        "accumsan urna vitae libero luctus volutpat. Nulla eu sodales enim, vitae blandit " +
                        "ligula. Suspendisse at magna pellentesque, rhoncus orci quis, consequat diam. " +
                        "Donec pulvinar accumsan erat, quis hendrerit est ultricies vel. Vivamus felis " +
                        "justo, vulputate non urna sed, finibus semper ipsum. Cras mattis, est vel posuere " +
                        "mattis, turpis augue elementum massa, vitae accumsan nibh nisl nec lectus. " +
                        "Maecenas porta sagittis erat at consequat. Suspendisse fermentum rutrum bibendum. " +
                        "Donec tempor mollis massa vel egestas. Morbi rutrum felis lacinia eros tincidunt " +
                        "scelerisque. Morbi aliquam porttitor sapien. Phasellus eu odio ac neque faucibus " +
                        "suscipit in at lectus. Maecenas et blandit arcu. Nullam sed sem neque. Nulla sit " +
                        "amet tristique nisl. Ut et pretium velit. Fusce consequat tincidunt fringilla. " +
                        "Nunc gravida libero sit amet augue viverra, a imperdiet odio dictum. Sed iaculis, " +
                        "metus vel rutrum convallis, quam ex commodo nibh, eget ultrices nisi eros eu massa. " +
                        "Ut iaculis maximus ligula, sed efficitur mauris bibendum sagittis. Curabitur et " +
                        "dolor mi. Proin lorem urna, porttitor quis lacus pharetra, ornare porta nulla. " +
                        "Sed ultricies feugiat nibh, et semper tellus aliquet sit amet. Cras faucibus " +
                        "scelerisque nisi, at vestibulum massa pharetra et.",
                    new Contact("Kylo Ren", "0488770066", "kylo@mailinator.com"),
                    4, 4, Guid.Parse("9fea77dc-9824-11ea-bb37-0242ac130002")),
                new Job(
                    62, "Quisque blandit erat id mi tincidunt porta. Vivamus eleifend " +
                        "sagittis neque id maximus. Etiam molestie, massa ut tempus fermentum, augue nisi " +
                        "pulvinar nunc, id malesuada ipsum ipsum nec odio. Etiam et nisl facilisis, " +
                        "egestas massa eget, sagittis sapien. Curabitur eget consequat diam. Proin auctor " +
                        "rhoncus est, vitae imperdiet sem mollis.",
                    new Contact("Lando Calrissian", "0433335555", "lando@mailinator.com"),
                    5, 5, Guid.Parse("be1cff4a-9824-11ea-bb37-0242ac130002")),
                new Job(
                    55, "Suspendisse consequat malesuada arcu id venenatis. Donec maximus, " +
                        "dolor quis elementum scelerisque, lorem diam ornare arcu, sed venenatis orci justo " +
                        "nec nibh. Maecenas sollicitudin pulvinar lorem, at aliquet tortor tincidunt at. " +
                        "Vestibulum blandit, arcu eu blandit vehicula, orci nulla porta justo, a semper " +
                        "nunc risus sit amet ante. Donec lobortis.",
                    new Contact("Jabba TheHutt", "0411443322", "jabba@mailinator.com"),
                    1, 6, Guid.Parse("d99ffe16-9824-11ea-bb37-0242ac130002"))
            };
        }
    }
}