using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Application.Authenticate.Models;
using SchoolManagementSystem.Application.Authenticate;
using SchoolManagementSystem.Application.Authenticate.Interfaces;

namespace SchoolManagementSystem.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddDbContext<SchoolContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("SchoolContextSQLite")));

        services.Configure<JWT>(Configuration.GetSection("JWT"));

        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("IdentityContextSQLite")));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })

        // Adding Jwt Bearer
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["JWT:Issuer"],
                ValidAudience = Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
            };
        });

        services.AddAutoMapper(typeof(Program));

        //Injection of deendencies with reflection
        MyDependencyInjections.SetUpMyServicesDependencyInjections(services, Configuration);


        services.AddScoped<IObjectContext, SchoolContext>();

        //Periodic Hosted Service
        services.AddScoped<DebtorNotificationService>();
        services.AddSingleton<PeriodicHostedService>();
        services.AddHostedService( provider => provider.GetRequiredService<PeriodicHostedService>());

        // Define a specific CORS policy for the React app
        services.AddCors(options =>
        {
            options.AddPolicy(name: "MyAllowSpecificOrigins",
                              policy  =>
                              {
                                  policy.WithOrigins("http://localhost:8080") // The origin of your React app
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                              });
        });
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Management System", Version = "v1" });
        });
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Management System v1"));
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
        
            var schoolContext = services.GetRequiredService<SchoolContext>();
            schoolContext.Database.EnsureCreated();
            
            var identityContext = services.GetRequiredService<IdentityContext>();
            identityContext.Database.EnsureCreated();

            SchoolInitializer.Initialize(schoolContext);
            
        }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Use the CORS policy you defined in ConfigureServices.
        // This must be placed after UseRouting and before UseAuthentication/UseAuthorization.
        app.UseCors("MyAllowSpecificOrigins");

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    } 
}
