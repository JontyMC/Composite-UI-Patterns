namespace Navigation.Events {
    public class NavigationOccurred {
        public NavigationOccurred(string url, object viewModel) {
            Url = url;
            ViewModel = viewModel;
        }

        public string Url { get; private set; }
        public object ViewModel { get; private set; }
    }
}