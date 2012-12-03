using System.Linq;
using Caliburn.Micro;
using Model.DomainModel.Events;
using Model.DomainModel.User;
using Model.Framework;
using Model.Shell;
using Model.User;

namespace Model.Links {
    public class LinksViewModel : Screen, IHandle<UserAdded> {
        readonly INavigationService navigationService;
        readonly IWindowManager windowManager;
        readonly IAddViewModelFactory addViewModelFactory;

        public LinksViewModel(IEventAggregator eventAggregator, IRepository<UserModel> userRepository, INavigationService navigationService, IWindowManager windowManager, IAddViewModelFactory addViewModelFactory) {
            eventAggregator.Subscribe(this);
            Links = new BindableCollection<string>(userRepository.GetAll().Select(x => "user/" + x.Id));
            this.navigationService = navigationService;
            this.windowManager = windowManager;
            this.addViewModelFactory = addViewModelFactory;
        }

        public BindableCollection<string> Links { get; set; }

        public void Go(string url) {
            navigationService.NavigateTo(url);
        }

        public void Add() {
            var addViewModel = addViewModelFactory.Create();
            windowManager.ShowDialog(addViewModel);
        }

        public void Handle(UserAdded message) {
            var url = navigationService.UrlFromViewModel<DetailsViewModel>(new { message.Id });
            Links.Add(url);
        }
    }
}