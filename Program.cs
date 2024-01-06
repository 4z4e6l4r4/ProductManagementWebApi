using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProductManagementWebApi.Models.Interfaces;
using ProductManagementWebApi.Models.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProductManagementWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Benim eklediklerim -Baþ
            builder.Services.AddTransient<IAuthService, AuthService>();

            builder.Services.AddTransient<ITokenService, TokenService>();

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
                    ValidAudience = builder.Configuration["AppSettings:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,

                };
            });

            //Benim eklediklerim -Son

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                policy =>
                {
                    policy.AllowAnyOrigin() // React uygulamanýzýn çalýþtýðý adres
    .AllowAnyHeader()
    .AllowAnyMethod();
                });
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication(); //Bunu ben ekledim

            app.UseCors("MyAllowSpecificOrigins");

            app.MapControllers();

            app.Run();
        }
    }
}