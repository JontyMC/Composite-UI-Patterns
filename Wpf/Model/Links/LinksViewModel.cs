using System.Linq;
using Caliburn.Micro;
using Model.Events;
using Model.Framework;
using Model.Shell;
using Model.User;

namespace Model.Links {
    public class LinksViewModel : Screen, IHandle<UserAdded> {
        readonly INavigationService navigationService;

        public LinksViewModel(IEventAggregator eventAggregator, IRepository<UserModel> userRepository, INavigationService navigationService) {
            eventAggregator.Subscribe(this);
            Links = new BindableCollection<string>(userRepository.GetAll().Select(x => "user/" + x.Id));
            this.navigationService = navigationService;
        }

        public BindableCollection<string> Links { get; set; }

        public void Go(string url) {
            navigationService.NavigateTo(url);
        }

        public void Handle(UserAdded message) {
            var url = navigationService.UrlFromViewModel<DetailsViewModel>(new { message.Id });
            Links.Add(url);
        }
    }
}