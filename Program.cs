using RabitMqProductAPI.Data;
using RabitMqProductAPI.RabitMQ;
using RabitMqProductAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<IRabitMQProducer,RabitMQProducer>();

builder.Services.AddControllers();
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
/*
https://www.c-sharpcorner.com/article/rabbitmq-message-queue-using-net-core-6-web-api/


dotnet ef migrations add yourMigrationName

dotnet ef database update

--


Install Rabbitmq docker file using the following command (Note- docker desktop is in running mode):

docker pull rabbitmq:3-management

Next, create a container and start using the Rabbitmq Dockerfile that we downloaded:

docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

----


http://localhost:15672/

Enter default username ("guest") and password (also "guest"), and next you will see the dashboard.



*/