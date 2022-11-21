
using DPWCMSApp.Services;
using DPWorldDR.Shared.Contracts;
using DPWorldDR.Shared.Services.OracleServices;
using KioscoWebView.Services;
using KioscoWebView.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Windows;

namespace Kiosco.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();

            //serviceCollection.AddRazorPages();
            //serviceCollection.AddServerSideBlazor();
            serviceCollection.AddScoped(x =>
            {
                var apiUrl = new Uri("https://localhost:7261/");
                return new HttpClient() { BaseAddress = apiUrl };
            });

            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddScoped<ITblResumenHorasService,
                TblResumenHorasService>().AddScoped<IDynamicFormsService,
                DynamicFormsService>().AddScoped<IHttpService,
                HttpService>().AddScoped<ILocalStorageService,
                LocalStorageService>().AddScoped<ICustomLogger,
                CustomLogger>().AddScoped<IOracleServices,
                OracleServices>().AddScoped<IPromocionesService, PromocionesService>()
               .AddScoped<ILoginService, LoginService>()
               .AddScoped<IVolantesPagosService, VolantesPagosService>()
               .AddScoped<ICertificacionesLaboralesService, CertificacionesLaboralesService>()
               .AddScoped<IVacantesService, VacantesService>()
               .AddScoped<IVacantesRequisitosService, VacantesRequisitosService>();

            serviceCollection.AddSingleton<ViewOptionService>();

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
