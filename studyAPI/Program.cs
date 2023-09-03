using Microsoft.EntityFrameworkCore;
using studyAPI.Models;
using studyAPI.Controllers;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //CORS can delete with CORS comment


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200",
                                                  "http://localhost:4200/")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});
//CORS

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<KtdatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapStudentEndpoints();

app.Run();
