using AFFHangfire;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddControllers();

builder.Services.AddScoped<ITestJob, TestJob>();

builder.Services.AddHangfire(x => 
x.UseSqlServerStorage("Data Source=SHADOW\\SQLEXPRESS;Initial Catalog=AFFHangfire;Integrated Security=True;Pooling=False"));
builder.Services.AddHangfireServer();

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
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate<ITestJob>("Owen's-job", job => job.register("Owen"), Cron.Minutely);


app.UseAuthorization();

app.MapControllers();

app.Run();
