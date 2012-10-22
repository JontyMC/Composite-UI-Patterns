namespace Navigation.Twitter {
    public class TweetViewModel {
        public TweetViewModel(string text) {
            Text = text;
        }

        public string Text { get; private set; }
    }
}