﻿using OEM.Pages;
using OEM.Respositories;
using OEM.Webservices;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

[assembly: ExportFont("materialdesignicons-webfont.ttf", Alias = "MaterialDesignIcon")]
namespace OEM
{
    public partial class App
    {
        /*
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor.
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainNavigationPage/SearchPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainNavigationPage, MainNavigationPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();
            containerRegistry.RegisterForNavigation<ScanPage, ScanPageViewModel>();

            containerRegistry.RegisterInstance<IVinWebservice>(new VinWebservice());

            containerRegistry.RegisterSingleton<IVinRepository, VinRepository>();
        }
    }
}
