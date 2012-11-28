using Caliburn.Micro;
using Model.Shell;
using Navigation.Events;

namespace Navigation.Shell {
    public class AddressBarViewModel : Screen, IHandle<NavigationOccurred> {
        readonly INavigationService navigationService;
        string url;

        public AddressBarViewModel(IEventAggregator eventAggregator, INavigationService navigationService) {
            this.navigationService = navigationService;
            eventAggregator.Subscribe(this);
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