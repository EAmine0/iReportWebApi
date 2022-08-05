using Icta.Reporting.Data.Implementations;
using Icta.Reporting.Data.Interfaces;
using Icta.Reporting.Repository.Implementations;
using Icta.Reporting.Repository.Interfaces;
using Icta.Reporting.Services.Implementations;
using Icta.Reporting.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icta.Reporting.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Icta.Reporting.WebApi", Version = "v1" });
            });

            services.AddScoped(typeof(IDataWarehouseConnector<>), typeof(DataWarehouseConnector<>));
            services.AddScoped(typeof(IIctaCubeConnector<>), typeof(IctaCubeConnector<>));

            services.AddScoped(typeof(IDataWarehouseRepository<>), typeof(DataWarehouseRepository<>));
            services.AddScoped(typeof(IIctaCubeRepository<>), typeof(IctaCubeRepository<>));

            services.AddScoped<IIdentifiedSiteByCountryService, IdentifiedSiteByCountryService>();
            services.AddScoped<ISiteStatusService, SiteStatusService>();
            services.AddScoped<ISitesService, SitesService>();
            services.AddScoped<IPatientsService, PatientsService>();
            services.AddScoped<IPatientStatusService, PatientStatusService>();
            services.AddScoped<ICurveOfInclusionService, CurveOfInclusionService >();
            services.AddScoped<IMonitoringService, MonitoringService>();
            services.AddScoped<IDocumentConformityService, DocumentConformityService>();
            services.AddScoped<ISafetyAEService, SafetyAEService>();

            services.AddScoped<IDMCRFVisitsService, DMCRFVisitsService>();
            services.AddScoped<IDMCRFPatientCleanedService, DMCRFPatientCleanedService>();
            services.AddScoped<IDMCRFDMQueriesService, DMCRFDMQueriesService>();
            services.AddScoped<IDMCRFPatientMandatoryConsultService, DMCRFPatientMandatoryConsultService>();

            services.AddScoped<IDMeCRFVisitsService, DMeCRFVisitsService>();
            services.AddScoped<IDMeCRFPatientSignedService, DMeCRFPatientSignedService>();
            services.AddScoped<IDMeCRFDMQueriesService, DMeCRFDMQueriesService>();
            services.AddScoped<IDMeCRFPatientMandatoryConsultService, DMeCRFPatientMandatoryConsultService>();

            services.AddScoped<IStatusSummaryService, StatusSummaryService>();
            services.AddScoped<IStatusDetailsService, StatusDetailsService>();
            services.AddScoped<IActivitiesMonitoringService, ActivitiesMonitoringService>();

            services.AddScoped<IGANTTCountryService, GANTTCountryService>();
            services.AddScoped<ITimelineService, TimelineService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Icta.Reporting.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
