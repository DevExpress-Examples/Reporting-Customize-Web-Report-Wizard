using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.DataAccess;

namespace AspNetCoreWizardCustomization {
    public class Startup {
        readonly CustomConfigurationProvider configurationProvider;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment) {
            Configuration = configuration;
            FileProvider = hostingEnvironment.ContentRootFileProvider;
            this.configurationProvider = new CustomConfigurationProvider(hostingEnvironment);
        }

        public IFileProvider FileProvider { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDevExpressControls();
            services
                .AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.ConfigureReportingServices(configurator => {
                configurator.ConfigureReportDesigner(designerConfigurator => {
                    designerConfigurator.RegisterDataSourceWizardConfigurationConnectionStringsProvider(configurationProvider.GetSqlConnectionStrings(), configurationProvider.GetJsonConnectionStrings());
                }); 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            var reportDirectory = Path.Combine(env.ContentRootPath, "Reports");
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new ReportStorageWebExtension1(reportDirectory));
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
            app.UseDevExpressControls();
            DefaultConnectionStringProvider.AssignConnectionStrings(configurationProvider.GetGlobalConnectionStrings());
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules"
            });            
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
