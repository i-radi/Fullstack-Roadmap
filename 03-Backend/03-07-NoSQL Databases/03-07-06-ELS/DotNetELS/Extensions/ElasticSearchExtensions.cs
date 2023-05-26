using DotNetELS.Models;
using Nest;

namespace DotNetELS.Extensions
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ELKConfiguration:Uri"];
            var defaultIndex = configuration["ELKConfiguration:index"];
            var userIndex = configuration["ELKConfiguration:UserIndex"];
            var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
            if (!client.Indices.Exists(userIndex).Exists)
            {
                var createIndexResponse = client.Indices.Create(userIndex, c => c
               .Map<User>(m => m.AutoMap()
               )
           );
            }

            // create the index, adding the mapping for the Page type to the index
            // at the same time. Automap() will infer the mapping from the POCO

            CreateIndex(client, defaultIndex);
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings
                .DefaultMappingFor<Product>(m => m
                // .Ignore(p => p.Price)
                // .Ignore(p => p.Measurement)
                );
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<Product>(x => x.AutoMap())
            );
        }
    }
}
