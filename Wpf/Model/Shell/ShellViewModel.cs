using Caliburn.Micro;
using Model.Events;
using Model.Links;

namespace Model.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive, IHandle<NavigationOccurred> {
        public ShellViewModel(IEventAggregator eventAggregator, LinksViewModel linksViewModel, AddressBarViewModel addressBarViewModel) {
            eventAggregator.Subscribe(this);
            Widget = addressBarViewModel;
            SideBar = linksViewModel;
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