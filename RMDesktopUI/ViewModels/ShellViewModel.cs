using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using RMDesktopUI.EventModels;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
        }

        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            // Closes out the LoginView and opens up the SalesView. This happens because ActivateItemAsync is in the Conductor class,
            // and when we have Conductor class, only one item can be active at a time.
            ActivateItemAsync(_salesVM);

            return Task.CompletedTask;
        }
    }
}
