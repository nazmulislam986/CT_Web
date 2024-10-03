using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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
using CT_Web.Repository_Layer;
using CT_Web.Service_Layer;

namespace CT_Web
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
            services.AddScoped<IBikeInfoSL, BikeInfoSL>();
            services.AddScoped<IBikeInfoRL, BikeInfoRL>();

            services.AddScoped<IDailyAntSL, DailyAntSL>();
            services.AddScoped<IDailyAntRL, DailyAntRL>();

            services.AddScoped<IDailyCutSL, DailyCutSL>();
            services.AddScoped<IDailyCutRL, DailyCutRL>();

            services.AddScoped<IDailySavingSL, DailySavingSL>();
            services.AddScoped<IDailySavingRL, DailySavingRL>();

            services.AddScoped<IDailySL, DailySL>();
            services.AddScoped<IDailyRL, DailyRL>();

            services.AddScoped<IGivenSL, GivenSL>();
            services.AddScoped<IGivenRL, GivenRL>();

            services.AddScoped<IImagesSL, ImagesSL>();
            services.AddScoped<IImagesRL, ImagesRL>();

            services.AddScoped<IInstallmentSL, InstallmentSL>();
            services.AddScoped<IInstallmentRL, InstallmentRL>();

            services.AddScoped<IMarketMemoSL, MarketMemoSL>();
            services.AddScoped<IMarketMemoRL, MarketMemoRL>();

            services.AddScoped<IMarketSL, MarketSL>();
            services.AddScoped<IMarketRL, MarketRL>();

            services.AddScoped<IMonthlyTakeSL, MonthlyTakeSL>();
            services.AddScoped<IMonthlyTakeRL, MonthlyTakeRL>();

            services.AddScoped<ISavingSL, SavingSL>();
            services.AddScoped<ISavingRL, SavingRL>();

            services.AddScoped<ITariffAmtSL, TariffAmtSL>();
            services.AddScoped<ITariffAmtRL, TariffAmtRL>();

            services.AddScoped<ITekenSL, TekenSL>();
            services.AddScoped<ITekenRL, TekenRL>();

            services.AddScoped<IUnratedSL, UnratedSL>();
            services.AddScoped<IUnratedRL, UnratedRL>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CT_Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
