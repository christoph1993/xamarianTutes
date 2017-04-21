﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhoneTranslator.ToNumber(phoneNumberText.Text);
            if(!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = String.Format("Call - {0}", translatedNumber);
            } else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if(await this.DisplayAlert (
                    "Dial a Number",
                    String.Format("Would you like to call {0}?",translatedNumber),
                    "Yes",
                    "No"
                ))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null) dialer.Dial(translatedNumber);
            }
        }
    }
}
