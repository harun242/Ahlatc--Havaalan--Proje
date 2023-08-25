using AýrportMvcUI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); //httpContext.session kullanabilmek için
builder.Services.AddHttpContextAccessor();// IHttpContextAccessor tipinden nesne isteyen yerlere ilgili nesnenin verilebilmesi için

//---------------------------------------------------
// Aþaðýdaki ikili IoC ye, web servisler haberleþmek için bie lazým olan HttpClient nesnesi üretmek ve HttpApiService nesnesi üretmek direktiflerini vermiþ oluyor. 
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

app.UseSession(); //httpContext.session kullanabilmek için pipelýne ekliyoruz

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Home

//www.Aýrport.com/Employe/Index/3
//www.Aýrport.com/Employe/Index
//www.Aýrport.com

app.MapAreaControllerRoute(
    name: "adminPanelDefault",
    areaName: "AdminPanel",
    pattern: "{area}/{controller=Auth}/{action=LogIn}/{id?}"
  );

//www.Aýrport.com/AdminPanel/Index/3
//www.Aýrport.com/AdminPanel

app.Run();
