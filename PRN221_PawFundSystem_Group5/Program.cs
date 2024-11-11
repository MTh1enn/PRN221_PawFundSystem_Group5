using Repository.IRepository.Repository.IRepository;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddSession();
var app = builder.Build();

builder.Services.AddRazorPages();

// Đăng ký các dịch vụ mà bạn sử dụng
builder.Services.AddScoped<IPetRepo, PetRepo>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IAdoptionRequestService, AdoptionRequestService>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
