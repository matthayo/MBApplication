using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MBApplication
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            LoggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404
                && !Path.HasExtension(context.Request.Path.Value)){
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            //Configure a rewrite rule to auto-lookup for standard default files e.g. index.html
            app.UseDefaultFiles();

            //Serving static files i.e. .css, .js, images etc
            app.UseStaticFiles(new StaticFileOptions(){
                OnPrepareResponse = (context) =>
                {
                    //Disable caching for all stactic files.
                    context.Context.Response.Headers["Cache-Control"] = Configuration["StaticFiles:Headers:Cache-Control"];
                    context.Context.Response.Headers[""]
                }
            })

            app.UseMvc();
        }
    }
}
