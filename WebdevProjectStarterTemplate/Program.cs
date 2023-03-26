using WebdevProjectStarterTemplate.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

Program.Configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//services.addsession();
//addsession moet waar?
//app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

new SQLrepository().createDatabase();

app.Run();



partial class Program
{
    public static IConfiguration Configuration { get; set; } = null!;
}