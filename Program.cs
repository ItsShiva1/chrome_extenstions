using chrome_extenstions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

builder.Services.AddControllers();
builder.Services.AddSingleton<FirebaseService>(provider => {
    var config = provider.GetRequiredService<IConfiguration>();
    var firebaseApiKey = config["FirebaseApiKey"];
    var firebasePath = config["FirebasePath"];
    return new FirebaseService(firebaseApiKey, firebasePath);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
