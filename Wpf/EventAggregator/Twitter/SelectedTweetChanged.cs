namespace EventAggregator.Twitter {
    public class SelectedTweetChanged {
        public TweetViewModel SelectedTweet { get; private set; }

        public SelectedTweetChanged(TweetViewModel selectedTweet) {
            SelectedTweet = selectedTweet;
        }
    }
}