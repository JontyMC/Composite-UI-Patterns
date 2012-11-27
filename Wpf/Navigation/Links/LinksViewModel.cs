using Caliburn.Micro;
using Navigation.Events;

namespace Navigation.Links {
    public class LinksViewModel : Screen {
        readonly IEventAggregator eventAggregator;

        public LinksViewModel(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;
        }

        public void Go1(string url) {
            var message = new UrlChanged(url);
            eventAggregator.Publish(message);
        }
    }
}