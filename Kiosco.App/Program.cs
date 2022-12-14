using BlazorStrap;
using DPWCMSApp.Services;
using DPWorldDR.Shared.Contracts;
using DPWorldDR.Shared.Services.OracleServices;
using Kiosco.App.Data;
using Kiosco.App.Services;
using Kiosco.App.Utils;
using Kiosco.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBootstrapCss();
builder.Services.AddScoped(x =>
{
    var apiUrl = new Uri(builder.Configuration["apiUrl"]);
    return new HttpClient() { BaseAddress = apiUrl };
});

builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });



builder.Services.AddScoped<ITblResumenHorasService, TblResumenHorasService>()
   .AddScoped<IDynamicFormsService, DynamicFormsService>().AddScoped<IHttpService, HttpService>()
   .AddScoped<ILocalStorageService, LocalStorageService>().AddScoped<ICustomLogger, CustomLogger>()
   .AddScoped<IOracleServices, OracleServices>()
   .AddScoped<IPromocionesService, PromocionesService>()
   .AddScoped<INuevosIngresosServices, NuevosIngresosServices>()
   .AddScoped<ILoginService, LoginService>()
   .AddScoped<IVolantesPagosService, VolantesPagosService>()
   .AddScoped<ICertificacionesLaboralesService, CertificacionesLaboralesService>()
   .AddScoped<IVacantesService, VacantesService>()
   .AddScoped<ISendMailService, SendMailService>()
   .AddScoped<IEncuestasInternasService, EncuestasInternasService>()
   .AddScoped<IEmpleadosServices, EmpleadosServices>()
   .AddScoped<IVacantesRequisitosService, VacantesRequisitosService>();

 builder.Services.AddSingleton<ViewOptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
