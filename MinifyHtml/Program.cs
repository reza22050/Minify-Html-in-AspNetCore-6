using WebMarkupMin.AspNetCore6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddWebMarkupMin(options =>
{
    options.AllowCompressionInDevelopmentEnvironment = true;
    options.AllowMinificationInDevelopmentEnvironment = true;
})
    .AddHtmlMinification(options => { 
        options.MinificationSettings.RemoveHtmlComments = true;
        options.MinificationSettings.RemoveHtmlCommentsFromScriptsAndStyles = true;
        options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
        options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
        options.MinificationSettings.RemoveOptionalEndTags = true;
        options.MinificationSettings.RemoveTagsWithoutContent = true;
        options.MinificationSettings.MinifyEmbeddedCssCode = true;
        options.MinificationSettings.MinifyInlineCssCode = true;
        options.MinificationSettings.MinifyInlineJsCode = true;

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWebMarkupMin();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
