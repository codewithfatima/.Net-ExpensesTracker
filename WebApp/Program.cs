using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Interface;


var builder = WebApplication.CreateBuilder(args);

//add cors to connect with frowenrt
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    policy.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod());
});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();



// Add Entity Framework and connect it to SQL Server
builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();           
    app.UseSwaggerUI();        
}

app.UseHttpsRedirection();
app.UseStaticFiles();


//cors 
app.UseCors("AllowAngular");
app.UseRouting();

app.UseAuthorization();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
app.Run();
