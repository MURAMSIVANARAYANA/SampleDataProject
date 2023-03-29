using SampleDataProject.ViewModels;
using SampleDataProject.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleDataProject
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
           
        }

    }
}
