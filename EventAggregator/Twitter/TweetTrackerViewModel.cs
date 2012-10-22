using Caliburn.Micro;

namespace EventAggregator.Twitter {
    public class TweetTrackerViewModel : IHandle<SelectedTweetChanged> {
        public TweetTrackerViewModel(IEventAggregator eventAggregator) {
            Tweets = new BindableCollection<string>();

            eventAggregator.Subscribe(this);
        }

        public BindableCollection<string> Tweets { get; private set; }

        public void Handle(SelectedTweetChanged message) {
            Tweets.Add(message.SelectedTweet.Text);
        }
    }
}