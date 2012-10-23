using Caliburn.Micro;
using Model.Events;

namespace Model.Shell {
    public class AddressBarViewModel : Screen {
        readonly IEventAggregator eventAggregator;
        string url;

        public AddressBarViewModel(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;
        }

        public string Url {
            get { return url; }
            set {
                url = value;
                NotifyOfPropertyChange(() => Url);
            }
        }

        public void Go() {
            var message = new UrlChanged(Url);
            eventAggregator.Publish(message);
        }
    }
}