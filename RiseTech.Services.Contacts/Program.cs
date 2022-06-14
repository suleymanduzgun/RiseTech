using RiseTech.Services.Contacts.Businesses.Settings;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using FluentValidation.AspNetCore;
using System.Reflection;
using RiseTech.Services.Contacts.Businesses.Interfaces;
using RiseTech.Services.Contacts.Businesses.Services;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var dbs = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>(sp => { return dbs; });


builder.Services.AddScoped(typeof(IContactService), typeof(ContactService));
//builder.Services.AddScoped(typeof(IContactDetailService), typeof(ContactDetailService));


builder.Services.AddControllers()
	.AddFluentValidation(options =>
	{
		// Validate child properties and root collection elements
		options.ImplicitlyValidateChildProperties = true;
		options.ImplicitlyValidateRootCollectionElements = true;
		// Automatic registration of validators in assembly
		options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
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

app.UseAuthorization();

app.MapControllers();

app.Run();
