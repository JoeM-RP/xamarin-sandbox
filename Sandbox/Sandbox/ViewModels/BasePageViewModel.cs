using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using ReactiveUI;
using Sandbox.Abstractions;
using Xamarin.Forms;
using Xamvvm;

namespace Sandbox.ViewModels
{
    public abstract class BasePageViewModel : BasePageModelRxUI
    {
		protected CompositeDisposable SubscriptionDisposables = new CompositeDisposable();

		protected ObservableAsPropertyHelper<bool> _busy;
		public bool IsBusy => _busy.Value;

        // Properties
		private string _pageTitle;
		public string PageTitle
		{
			get { return _pageTitle; }
			set { this.RaiseAndSetIfChanged(ref _pageTitle, value); }
		}

		string _userName;
		public string UserName
		{
			get { return _userName; }
			set { this.RaiseAndSetIfChanged(ref _userName, value); }
		}

		AuthenticationResult _authorization;
		public AuthenticationResult Authorization
		{
			get { return _authorization; }
			set { this.RaiseAndSetIfChanged(ref _authorization, value); }
		}

		// Commands
		public ReactiveCommand<Unit, bool> GetSignOn { get; set; }
		public ReactiveCommand<Unit, bool> GetSignOff { get; set; }

        public BasePageViewModel(string title = "Sandbox")
        {
            PageTitle = title;

			GetSignOn = ReactiveCommand.CreateFromTask<Unit, bool>(async _ =>
			{
				return await ExecuteSignOnCommand();
			});

			GetSignOff = ReactiveCommand.CreateFromTask(_ =>
			{
				this.UserName = null;
				this.Authorization = null;

				return ExecuteSignOffCommand();
			});
        }

        protected abstract void InitRxBindings();

		private async Task<bool> ExecuteSignOnCommand()
		{
			try
			{
				var identity = DependencyService.Get<IIdentityService>();
                this.Authorization = await identity.Authorize();
				this.UserName = Authorization.UserInfo.GivenName + " " + Authorization.UserInfo.FamilyName;

				return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[{ex.Source}] Error = {ex.Message}");
			}

			return false;
		}

		private Task<bool> ExecuteSignOffCommand()
		{
			try
			{
				var identity = DependencyService.Get<IIdentityService>();
                identity.SignOut(App.AadAuthority);

                return Task.FromResult(true);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[{ex.Source}] Error = {ex.Message}");
			}

            return Task.FromResult(false);
		}
    }
}
