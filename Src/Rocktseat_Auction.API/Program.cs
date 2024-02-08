using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Rocktseat_Auction.API.Filters;
using Rocktseat_Auction.API.Interface;
using Rocktseat_Auction.API.Repositories;
using Rocktseat_Auction.API.Repositories.DataAccess;
using Rocktseat_Auction.API.Services;
using Rocktseat_Auction.API.UseCases.Auction.GetCurrent;
using Rocktseat_Auction.API.UseCases.Offer.CreateOffer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
  opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Description = @"JWT Authorization header using the Bearer scheme.
                    Enter 'Bearer' [space] and then your token in the text input below.
                    Example: 'Bearer 1234acbdef'",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer"
  });

  opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        Name = "Bearer",
        In = ParameterLocation.Header
      },
      new List<string>()
    }
  });
});
builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentAcutionUseCase>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoggedUser, LoggedUser>();

builder.Services.AddDbContext<RockseatAuctionDbContext>(opt =>
{
  opt.UseSqlite("Data Source=C:\\Cursos\\CSharp\\Rocktseat\\Base\\leilaoDbNLW.db");
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();