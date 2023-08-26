using PicPyChallenge.Payment.Consumers.Users;
using PicPayChallenge.Payment.Ioc;
using PicPyChallenge.Payment.Consumers.Users.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddScoped<IUsersCreatedConsumer, UsersCreatedConsumer>();
builder.Services.AddHostedService<UsersCreatedBackgroundService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
