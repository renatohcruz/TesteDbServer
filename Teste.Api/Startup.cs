using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.CasosDeUso;
using Teste.Domain.Repositorios;
using Teste.Infra.Contexto;
using Teste.Infra.Repositorios;
using Teste.Shared;

namespace Teste.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();
            services.AddResponseCompression();

            services.AddScoped<DbTesteContext, DbTesteContext>();
            services.AddTransient<TranferenciaEntreContas, TranferenciaEntreContas>();
            services.AddTransient<IContaRepositorio, ContaRepositorio>();
            services.AddTransient<ILancamentoRepositorio, LancamentoRepositorio>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            
            Settings.ConnectionString = $"{Configuration["connectionString"]}";
            Settings.SecurityKey = $"{Configuration["SecurityKey"]}";

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Teste",
                    ValidAudience = "Teste",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Settings.SecurityKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token inválido..:. " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Toekn válido...: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
