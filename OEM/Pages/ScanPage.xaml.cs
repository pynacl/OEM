﻿using Xamarin.Forms;
using ZXing;

namespace OEM.Pages
{
    public partial class ScanPage 
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //await DisplayAlert("Scanned result", result.Text, "OK");
                var viewModel = (ScanPageViewModel)this.BindingContext;
                viewModel.ScanCommand.Execute(result);
            });
        }
    }
}
