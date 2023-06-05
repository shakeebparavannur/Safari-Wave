using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Safari_Wave.Models;
using Safari_Wave.Repository;
using Safari_Wave.Repository.Interface;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;

namespace Safari_Wave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });
            });
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    //ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

                };
            });
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddAutoMapper(typeof(Program));
            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<SafariWaveContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
            "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
            "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name ="Bearer",
                                In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            builder.Services.AddSingleton<SMSService>(provider =>
            {
                var accountSid = builder.Configuration["Twilio:Sid"];
                var authToken = builder.Configuration["Twilio:Token"];
                var verifySid = builder.Configuration["Twilio:verifySid"];
                var logger = provider.GetRequiredService<ILogger<SMSService>>();

                return new SMSService(accountSid, authToken, logger, verifySid);
            });

            builder.Services.AddScoped<IPackageManagement, PackageManagement>();
            builder.Services.AddScoped<IUserManagement, UserManagement>();
            builder.Services.AddScoped<IBookingSevice, BookingService>();
            builder.Services.AddScoped<IEnquiryService, EnquiryService>();
            builder.Services.AddScoped<IReviewServices,ReviewService>();
            builder.Services.AddScoped<SaveImage>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "coverImage")),
                RequestPath = "/coverImage"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Image")),
                RequestPath = "/Image"
            });

            app.UseHttpsRedirection();
            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}