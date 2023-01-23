
using System.Reflection;
using Recipes.Application;
using Recipes.Application.Common.Mappings;
using Recipes.Application.Interfaces;
using Recipes.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IRecipeDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<RecipeDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        
    }
}




//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}=Home/{action}=Index/{Id?}");

app.Run();
