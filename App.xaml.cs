﻿using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;


namespace TutorLinkClient
{
    public partial class App : Application
    {
        public App(LoginViewModel vm)
        {

            //MainPage = new AppShell();
            MainPage = new Login(vm);
            ////  
            InitializeComponent();

        }
    }
}
