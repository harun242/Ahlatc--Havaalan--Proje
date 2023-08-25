using A�rportMvcUI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); //httpContext.session kullanabilmek i�in
builder.Services.AddHttpContextAccessor();// IHttpContextAccessor tipinden nesne isteyen yerlere ilgili nesnenin verilebilmesi i�in

//---------------------------------------------------
// A�a��daki ikili IoC ye, web servisler haberle�mek i�in bie laz�m olan HttpClient nesnesi �retmek ve HttpApiService nesnesi �retmek direktiflerini vermi� oluyor. 
builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpApiService, HttpApiService>();
//---------------------------------------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); //httpContext.session kullanabilmek i�in pipel�ne ekliyoruz

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Home

//www.A�rport.com/Employe/Index/3
//www.A�rport.com/Employe/Index
//www.A�rport.com

app.MapAreaControllerRoute(
    name: "adminPanelDefault",
    areaName: "AdminPanel",
    pattern: "{area}/{controller=Auth}/{action=LogIn}/{id?}"
  );

//www.A�rport.com/AdminPanel/Index/3
//www.A�rport.com/AdminPanel

app.Run();
