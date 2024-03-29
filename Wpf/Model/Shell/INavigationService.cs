namespace Model.Shell {
    public interface INavigationService {
        void NavigateTo(string url);
        object ViewModelFromUrl(string url);
        string UrlFromViewModel<TViewModel>(object args);
    }
}