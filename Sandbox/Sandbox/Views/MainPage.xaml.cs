using System;
using System.Collections.Generic;
using ReactiveUI;
using Sandbox.ViewModels;
using Xamarin.Forms;
using Xamvvm;

namespace Sandbox.Views
{
    public partial class MainPage : ContentPage, IBasePageRxUI<MainPageViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPageViewModel ViewModel { get; set; }
        object IViewFor.ViewModel { get; set; }

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
    }
}
