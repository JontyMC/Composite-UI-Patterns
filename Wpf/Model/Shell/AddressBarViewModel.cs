using Caliburn.Micro;
using Model.Events;

namespace Model.Shell {
    public class AddressBarViewModel : Screen, IHandle<NavigationOccurred> {
        readonly INavigationService navigationService;
        string url;

        public AddressBarViewModel(IEventAggregator eventAggregator, INavigationService navigationService) {
            eventAggregator.Subscribe(this);
            this.navigationService = navigationService;
        }

        public string Url {
            get { return url; }
            set {
                url = value;
                NotifyOfPropertyChange(() => Url);
            }
        }

        public void Go() {
            navigationService.NavigateTo(url);
        }

        public void Handle(NavigationOccurred message) {
            Url = message.Url;
        }
    }
}