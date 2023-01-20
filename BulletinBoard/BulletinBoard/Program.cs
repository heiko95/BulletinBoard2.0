using BlazorStrap;
using BulletinBoard.Services;
using BulletinBoard.Services.Contracts;
using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.DomainServices.Services;
using hgSoftware.DomainServices.SettingModels;
using Infrastructure;
using Infrastructure.FileReaders;
using Infrastructure.Profiles;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorStrap();
builder.Services.AddOptions();
builder.Services.AddAutoMapper(typeof(EventToDomainProfile));

// Add Settings
//builder.Services.Configure<ElementSettings>(options => builder.Configuration.GetSection("ElementSettings").Bind(options));

//builder.Services.Configure<ElementSettings>(builder.Configuration.GetSection("ElementSettings"));
builder.Services.Configure<ElementSettings>(ElementSettings.EventScreenSettings, builder.Configuration.GetSection("ElementSettings:EventScreenSettings"));
builder.Services.Configure<ElementSettings>(ElementSettings.WelcomeScreenSettings, builder.Configuration.GetSection("ElementSettings:WelcomeScreenSettings"));
builder.Services.Configure<ElementSettings>(ElementSettings.ImageScreenSettings, builder.Configuration.GetSection("ElementSettings:ImageScreenSettings"));

builder.Services.AddSingleton<IBibleTextService, BibleTextService>();
builder.Services.AddSingleton<IBoardElementService, BoardElementService>();
builder.Services.AddSingleton<IImageService, ImageService>();
builder.Services.AddSingleton<IPlannerService, PlannerService>();
builder.Services.AddSingleton<IWelcomeService, WelcomeService>();
builder.Services.AddSingleton<IInitService, InitService>();
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddSingleton<IEventFileReader, EventFileReader>();
builder.Services.AddSingleton<IWelcomeImageReader, WelcomeImageReader>();
builder.Services.AddSingleton<IImageFilesReader, ImageFilesReader>();
builder.Services.AddSingleton<IImageRepository, ImageRepository>();

builder.Services.AddSingleton<Context>();

var app = builder.Build();

var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "BulletinBoard");
if (!Directory.Exists(filePath))
{
    Directory.CreateDirectory(filePath);
}

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