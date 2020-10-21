using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Alert_To_Care.Repository;
using Alert_To_Care.SQLRepository;

namespace Alert_To_Care
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddDbContextPool<Database>(
                options => options.UseSqlServer(Configuration.GetConnectionString("PatientDBConnection")));
            services.AddControllers();
            services.AddTransient<IPatientDataRepository, SqlPatientDataRepository>();
            services.AddTransient<IIcuDataRepository, SqlIcuDataRepository>();
            services.AddTransient<IBedDataRepository, SqlBedDataRepository>();
            services.AddTransient<IVitalDataRepository, SqlVitalDataRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseRouting();

            //app.UseAuthorization();
           // app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
