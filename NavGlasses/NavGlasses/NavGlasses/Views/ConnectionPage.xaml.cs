﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NavGlasses.Interfaces;
using NavGlasses.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavGlasses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {
        private StackLayout stackLayout;


        public ConnectionPage()
        {
            stackLayout = new StackLayout();
            this.Content = stackLayout;

            PageHelper.CreateButton("Show Paired Devices", ShowPairedDevices, stackLayout);
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    stackLayout = new StackLayout();
        //    this.Content = stackLayout;

        //    PageHelper.CreateButton("Show Paired Devices", ShowPairedDevices, stackLayout);

        //}

        private void ShowPairedDevices()
        {
            var pairDeviceIds = App.BluetoothClient.GetPairedDeviceIds(); // TODO: here is the stuck part thingy - use another thread 

            foreach (var deviceId in pairDeviceIds)
            {
                string deviceName = App.BluetoothClient.GetDeviceName(deviceId);
                if (deviceName.Contains("HC-06"))
                {
                    PageHelper.CreateButton(deviceName, () => ConnectToDevice(deviceId), stackLayout);
                }
            }

            if (pairDeviceIds.Count == 0)
            {
                DependencyService.Get<IMessage>().LongAlert("No paired devices found, check if the Bluetooth is on");
            }
        }

        private void ConnectToDevice(string deviceId)
        {
            //var isSuccess =  await App.BluetoothClient.ConnectAsync(deviceId);
            GoToControlerPage(deviceId);

            var isSuccess = App.BluetoothClient.Connect(deviceId);

            if (isSuccess)
            {
                DependencyService.Get<IMessage>().ShortAlert("Connected!");
                GoToControlerPage(deviceId);
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("Failed To Connect");
            }

        }

        private void GoToControlerPage(string deviceId)
        {
            Navigation.PushAsync(new ControlerPage(deviceId));
        }
    }
}