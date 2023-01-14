using BlazorStrap;
using BulletinBoard.Services;
using BulletinBoard.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorStrap();
builder.Services.AddSingleton<IBibleTextService, BibleTextService>();
builder.Services.AddSingleton<IBoardElementService, BoardElementService>();
builder.Services.AddSingleton<IImageService, ImageService>();
builder.Services.AddSingleton<IPlannerService, PlannerService>();
builder.Services.AddSingleton<IWelcomeService, WelcomeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();