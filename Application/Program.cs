using Application.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UsersTable>();

string server = "db4free.net";
int port = 3306;
string username = "testdbqwe";
string password = "testdbqwetestdbqwe";
string database = "matchmaker";
builder.Services.AddSingleton<DB>(new DB(server, port, username, password, database));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();