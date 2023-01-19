using NavGlasses.Services;
using NavGlasses.Views;
using NavGlasses.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavGlasses
{
    public partial class App : Application
    {
        public static IBluetoothClient BluetoothClient { get; set; }

        public App(IBluetoothClient bluetoothClient)
        {
            InitializeComponent();

            BluetoothClient = bluetoothClient;

            MainPage = new NavigationPage(new ConnectionPage());
        }

        //public App()
        //{
        //    InitializeComponent();

        //    DependencyService.Register<MockDataStore>();
        //    MainPage = new AppShell();
        //}

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
