using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreWizardCustomization {
    public class CustomConfigurationProvider {
        readonly IHostingEnvironment hostingEnvironment;
        public CustomConfigurationProvider(IHostingEnvironment hostingEnvironment) {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IConfigurationSection GetSqlConnectionStrings() {
            return new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
                .GetSection("SqlConnectionStrings");
        }

        public IConfigurationSection GetJsonConnectionStrings() {
            return new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
                .GetSection("JsonConnectionStrings");
        }

        public IDictionary<string, string> GetGlobalConnectionStrings() {
			var sqlConnectionStrings = GetSqlConnectionStrings().AsEnumerable(true).ToDictionary(x => "ConnectionStrings:" + x.Key, x => x.Value);
			var jsonConnectionStrings = GetJsonConnectionStrings().AsEnumerable(true).ToDictionary(x => "ConnectionStrings:" + x.Key, x => x.Value);
			return new ConfigurationBuilder()
              .SetBasePath(hostingEnvironment.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			  .AddInMemoryCollection(sqlConnectionStrings)
			  .AddInMemoryCollection(jsonConnectionStrings)
              .AddEnvironmentVariables()
              .Build()
              .GetSection("ConnectionStrings")
              .AsEnumerable(true)
              .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
