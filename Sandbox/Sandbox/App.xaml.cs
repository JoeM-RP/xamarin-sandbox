using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using ReactiveUI;
using Sandbox.Abstractions;
using Sandbox.Services;
using Sandbox.ViewModels;
using Splat;
using Xamarin.Forms;
using Xamvvm;

#if !DEBUG
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
#endif
namespace Sandbox
{
	public static class Interactions
	{
		public static readonly Interaction<Exception, ErrorRecoveryOption> Errors = new Interaction<Exception, ErrorRecoveryOption>();
	}

	public enum ErrorRecoveryOption
	{
		Cancel,
		Retry,
	}

	public partial class App : Application
    {
        IIdentityService IdentityService;

		public static string UserName;
		public static AuthenticationResult Authorization;

        public App()
        {
            InitializeComponent();
            InitializeServices();

			var factory = new XamvvmFormsRxUIFactory(this);
			XamvvmCore.SetCurrentFactory(factory);

			factory.RegisterNavigationPage<AppShellNavigationPageModel>(() => this.GetPageFromCache<MainPageViewModel>());

            MainPage = this.GetPageAsNewInstance<AppShellNavigationPageModel>() as Page;
		}

        private void InitializeServices()
        {
            IdentityService =  DependencyService.Get<IIdentityService>();

            Locator.CurrentMutable.RegisterLazySingleton(() => new UserService(), typeof(IUserService));
		}

        protected override void OnStart()
        {
            // Handle when your app starts

            // TODO: Refresh token
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
			// Handle when your app resumes

			// TODO: Refresh token
		}
    }
}
