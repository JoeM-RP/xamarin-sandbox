using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;

namespace Sandbox.ViewModels
{
    public class MainPageViewModel : BasePageViewModel
    {
        public ReactiveCommand<Unit, bool> Navigate { get; }

        public MainPageViewModel()
        {
            InitRxBindings();
        }

        protected override void InitRxBindings()
        {
			// Behaviors
			//Observable.Merge(Navigate.IsExecuting)
			//	.ToProperty(this, vm => vm.IsBusy, out _busy);

			// Exceptions
			//Observable.Merge(Navigate.ThrownExceptions)
				//.Subscribe(async ex =>
				//{
				//	Debug.WriteLine($"[{ex.Source}] Error = {ex.Message}");

				//	var result = await Interactions.Errors.Handle(ex);
				//})
				//.DisposeWith(SubscriptionDisposables);
        }
    }
}
