using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Domain;
using Repository;
using Microsoft.EntityFrameworkCore;
using MasterChef.Mappers;

namespace MasterChef
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
            services.AddDbContext<MasterChefDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MasterChef")));

            //Service
            services.AddTransient<IReceitaService, ReceitaService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IComentarioService, ComentarioService>();

            //Repository
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IDbContext, MasterChefDbContext>();
            services.AddDbContext<MasterChefDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));

            //Mapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DomainToViewModelMappingProfille>();
                    cfg.AddProfile<ViewModelToDamainMappingProfille>();
                });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "admin",
                    template: "{Areas}/{Admin}/{controller=Receita}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Receita}/{action=Index}/{id?}");
            });
        }
    }
}
