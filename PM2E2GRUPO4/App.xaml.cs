﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E2GRUPO4.Vsitas;

namespace PM2E2GRUPO4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new inicio());
        }

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
