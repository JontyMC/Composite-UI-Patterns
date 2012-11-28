using Caliburn.Micro;
using Navigation.Events;
using Navigation.Links;

namespace Navigation.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive, IHandle<NavigationOccurred> {
        public ShellViewModel() {
            var eventAggregator = new EventAggregator();
            var navigationService = new NavigationService(eventAggregator);
            eventAggregator.Subscribe(this);
            Widget = new AddressBarViewModel(eventAggregator, navigationService);
            SideBar = new LinksViewModel(navigationService);
        }

        public object SideBar { get; private set; }

        public object Widget { get; private set; }

        object main;

        public object Main {
            get { return main; }
            set {
                main = value;
                NotifyOfPropertyChange(() => Main);
            }
        }

        public void Handle(NavigationOccurred message) {
            DeactivateItem(Main, true);
            Main = message.ViewModel;
            ActivateItem(Main);
        }
    }
}