namespace Navigation.Events {
    public class UrlChanged {
        public UrlChanged(string url) {
            Url = url;
        }

        public string Url { get; private set; }
    }
}