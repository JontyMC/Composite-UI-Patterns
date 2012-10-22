using Caliburn.Micro;
using EventAggregator.Twitter;

namespace EventAggregator.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive {
        public ShellViewModel() {
            var eventAggregator = new Caliburn.Micro.EventAggregator();
            var feed = new TwitterFeedViewModel(eventAggregator);
            var tracker = new TweetTrackerViewModel(eventAggregator);
            Items.Add(feed);
            Items.Add(tracker);
            Main = Items[0];
            SideBar = Items[1];
        }

        public object SideBar { get; private set; }
        public object Main { get; private set; }
        public object Widget { get; private set; }
    }
}