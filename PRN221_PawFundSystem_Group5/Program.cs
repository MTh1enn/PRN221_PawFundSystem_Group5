using Repository.IRepository.Repository.IRepository;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IAdoptionRequestService, AdoptionRequestService>();
builder.Services.AddScoped<IShelterService, ShelterService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddSession();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
