using System.Reflection;
using Desafio.Marin.Aplicacao.Comandos;
using Desafio.Marin.Aplicacao.Modelos;
using Desafio.Marin.Dominio;
using Desafio.Marin.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Desafio.Marin.API
{
    /// <summary>
    /// Inicialização da aplicação.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);

                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MarinLog API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Gregory",
                        Url = new Uri("https://github.com/LuucasGregory")
                    }
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PermitirTudo", policy =>
                {
                    policy.AllowAnyOrigin()  // Permite qualquer origem
                          .AllowAnyMethod()  // Permite qualquer método (GET, POST, PUT, DELETE, etc.)
                          .AllowAnyHeader(); // Permite qualquer cabeçalho
                });
            });

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining(typeof(ProcessarArquivoCNABCommand));
            });

            builder.Services.AddAutoMapper(typeof(TransacaoModelo));

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDatabaseContext, AppDbContext>();
            builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio.Marin.API v1");
                });
            }

            app.UseCors("PermitirTudo");

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
