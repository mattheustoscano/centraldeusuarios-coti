using CentralDeUsuarios.Infra.Messages.Consumers;
using CentralDeUsuarios.Services.Api;
using CentralDeUsuarios.Services.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

Setup.AddRegisterServices(builder);
Setup.AddEntityFrameworkServices(builder);
Setup.AddMessageServices(builder);
Setup.AddAutoMapperServices(builder);
Setup.AddMediatRServices(builder);
Setup.AddMongoDBServices(builder);
Setup.AddJwtBearerSecurity(builder);
Setup.AddSwagger(builder);
Setup.AddCors(builder);


//ativando o consumidor da mensageria
builder.Services.AddHostedService<MessageQueueConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();

Setup.UseCors(app);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

//Declaração publica da classe
public partial class Program { }