using BlazorStrap;
using BulletinBoard.Services;
using BulletinBoard.Services.Contracts;
using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.DomainServices.Services;
using hgSoftware.DomainServices.SettingModels;
using hgSoftware.Infrastructure;
using hgSoftware.Infrastructure.FileReaders;
using hgSoftware.Infrastructure.Profiles;
using hgSoftware.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
          .ReadFrom.Configuration(builder.Configuration)
          .CreateLogger();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorStrap();
builder.Services.AddOptions();
builder.Services.AddAutoMapper(typeof(EventToDomainProfile));
builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

// Add Settings
builder.Services.Configure<ElementSettings>(ElementSettings.EventScreenSettings, builder.Configuration.GetSection("ElementSettings:EventScreenSettings"));
builder.Services.Configure<ElementSettings>(ElementSettings.WelcomeScreenSettings, builder.Configuration.GetSection("ElementSettings:WelcomeScreenSettings"));
builder.Services.Configure<ElementSettings>(ElementSettings.ImageScreenSettings, builder.Configuration.GetSection("ElementSettings:ImageScreenSettings"));
builder.Services.Configure<ElementSettings>(ElementSettings.BibleSettings, builder.Configuration.GetSection("ElementSettings:BibleSettings"));
builder.Services.Configure<SlideSettings>(builder.Configuration.GetSection("SlideSettings"));

// Add Domain and Infrastructure Services
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
builder.Services.AddSingleton<IBibleFileReader, BibleFileReader>();
builder.Services.AddSingleton<IBibleTextRepository, BibleTextRepository>();

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