using Zenworks_Forms_BusinessEntities.Interfaces;
using Zenworks_Forms_DBConnectivity;
using Zenworks_Forms_Repository;
using Zenworks_Forms_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Project related dependencies add here
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<IDepertmentRepository, DepertmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderServices>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeServices>();

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
