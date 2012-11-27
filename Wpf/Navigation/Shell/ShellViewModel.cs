using System;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using Navigation.Events;
using Navigation.Links;

namespace Navigation.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive, IHandle<UrlChanged> {
        public ShellViewModel() {
            var eventAggregator = new EventAggregator();
            eventAggregator.Subscribe(this);
            Widget = new AddressBarViewModel(eventAggregator);
            SideBar = new LinksViewModel(eventAggregator);
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
            var viewModel = ViewModelFromUrl(message.Url);

            DeactivateItem(Main, true);
            Main = viewModel;
            ActivateItem(viewModel);
        }

        static object ViewModelFromUrl(string url) {
            if (!string.IsNullOrEmpty(url)) {
                var viewModelTypes = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name.EndsWith("ViewModel"));
                var viewModelType = viewModelTypes.FirstOrDefault(x => x.Name.StartsWith(url, StringComparison.InvariantCultureIgnoreCase));
                if (viewModelType != null) {
                    return Activator.CreateInstance(viewModelType);
                }
            }
            return new NotFoundViewModel();
        }
    }
}