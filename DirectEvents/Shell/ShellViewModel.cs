using Caliburn.Micro;
using DirectEvents.Twitter;

namespace DirectEvents.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive {
        public ShellViewModel() {
            var feed = new TwitterFeedViewModel();
            var tracker = new TweetTrackerViewModel(feed);
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