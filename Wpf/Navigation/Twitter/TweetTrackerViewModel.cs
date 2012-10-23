using Caliburn.Micro;

namespace Navigation.Twitter {
    public class TweetTrackerViewModel {
        public TweetTrackerViewModel(TwitterFeedViewModel feed) {
            Tweets = new BindableCollection<string>();

            feed.PropertyChanged += (_, args) => {
                if (args.PropertyName == "SelectedTweet") {
                    Tweets.Add(feed.SelectedTweet.Text);
                }
            };
        }

        public BindableCollection<string> Tweets { get; private set; }
    }
}