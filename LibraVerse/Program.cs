using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraVerse.ModelBinders;
using LibraVerse.Core.Contracts;
using LibraVerse.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "Book Details",
    pattern: "/Book/Details/{id}/{information}",
    defaults: new { Controller = "Book", Action = "Details" }
);

app.MapControllerRoute(
    name: "Article Details",
    pattern: "/Article/Details/{id}/{information}",
    defaults: new { Controller = "Article", Action = "Details" }
);

app.MapControllerRoute(
    name: "Event Details",
    pattern: "/Event/Details/{id}/{information}",
    defaults: new { Controller = "Event", Action = "Details" }
);

app.MapControllerRoute(
    name: "BookStore Details",
    pattern: "/BookStore/Details/{id}/{information}",
    defaults: new { Controller = "BookStore", Action = "Details" }
);


app.MapDefaultControllerRoute(); // Това е като "index" за контролерите, ако е необходимо

app.MapRazorPages(); // За Razor Pages


await app.CreateAdminRoleAsync();
await app.RunAsync();