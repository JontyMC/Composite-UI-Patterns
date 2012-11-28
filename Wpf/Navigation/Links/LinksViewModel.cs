using Caliburn.Micro;
using Model.Shell;

namespace Navigation.Links {
    public class LinksViewModel : Screen {
        readonly INavigationService navigationService;

        public LinksViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
        }

        public void Go(string url) {
            navigationService.NavigateTo(url);
        }
    }
}