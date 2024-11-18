using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MvCProj_1.Context;
using MvCProj_1.Data;
using MvCProj_1.Models;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvCProj_1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvCProj_1Context") ?? throw new InvalidOperationException("Connection string 'MvCProj_1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DBContext>();
//// Add JWT authentication
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = jwtIssuer,
                   ValidAudience = jwtIssuer,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
               };
               // Allow token to be retrieved from cookies or headers
               options.Events = new JwtBearerEvents
               {
                   OnMessageReceived = context =>
                   {
                       var token = context.Request.Cookies["jwtToken"];
                       if (!string.IsNullOrEmpty(token))
                       {
                           context.Token = token;
                       }
                       return Task.CompletedTask;
                   }
               };
           });

//Jwt configuration ends here
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();



//send an instance of Service object to MovieSeedData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    MovieSeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
