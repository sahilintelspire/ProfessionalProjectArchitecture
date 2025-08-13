using FluentValidation;
using FluentValidation.AspNetCore;
using ProfessionalProjectArchitecture.API.MappingProfiles;
using ProfessionalProjectArchitecture.Core.Interfaces;
using ProfessionalProjectArchitecture.Core.Validators;
using ProfessionalProjectArchitecture.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
//builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// FluentValidation (modern registration)
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();

// Service layer
builder.Services.AddScoped<IProductService, ProductService>();

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
