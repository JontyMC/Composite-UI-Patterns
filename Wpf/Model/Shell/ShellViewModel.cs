using Caliburn.Micro;
using Model.Events;

namespace Model.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive, IHandle<UrlChanged> {
        readonly INavigationService navigation;

        public ShellViewModel(IEventAggregator eventAggregator, INavigationService navigation) {
            this.navigation = navigation;
            eventAggregator.Subscribe(this);
            Widget = new AddressBarViewModel(eventAggregator);
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

        public void Handle(UrlChanged message) {
            DeactivateItem(Main, true);
            Main = navigation.ViewModelFromUrl(message.Url);
            ActivateItem(Main);
        }
    }
}