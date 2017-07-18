using System;
using System.Reactive.Disposables;
using ReactiveUI;
using Xamvvm;

namespace Sandbox.ViewModels
{
    public abstract class BasePageViewModel : BasePageModelRxUI
    {
		protected CompositeDisposable SubscriptionDisposables = new CompositeDisposable();

		protected ObservableAsPropertyHelper<bool> _busy;
		public bool IsBusy => _busy.Value;

		private string _pageTitle;
		public string PageTitle
		{
			get { return _pageTitle; }
			set { this.RaiseAndSetIfChanged(ref _pageTitle, value); }
		}

        public BasePageViewModel(string title = "Sandbox")
        {
            PageTitle = title;
        }

        protected abstract void InitRxBindings();
    }
}
