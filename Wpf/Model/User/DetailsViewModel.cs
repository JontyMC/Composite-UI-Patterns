using Caliburn.Micro;
using Model.Events;
using Model.Framework;

namespace Model.User {
    public class DetailsViewModel : Screen, IHandle<UserDetailsUpdated> {
        readonly IAddViewModelFactory addViewModelFactory;
        readonly IRepository<UserModel> userRepository;
        readonly IEditViewModelFactory editViewModelFactory;
        readonly int userId;
        string firstname;
        string lastname;
        readonly IWindowManager windowManager;

        public DetailsViewModel(IRepository<UserModel> userRepository, IEventAggregator eventAggregator, IAddViewModelFactory addViewModelFactory, IEditViewModelFactory editViewModelFactory, int userId) {
            this.addViewModelFactory = addViewModelFactory;
            this.userRepository = userRepository;
            this.editViewModelFactory = editViewModelFactory;
            this.userId = userId;
            eventAggregator.Subscribe(this);
            windowManager = new WindowManager();
        }

        public string Firstname {
            get { return firstname; }
            set {
                firstname = value;
                NotifyOfPropertyChange(() => Firstname);
            }
        }

        public string Lastname {
            get { return lastname; }
            set {
                lastname = value;
                NotifyOfPropertyChange(() => Lastname);
            }
        }

        public void Edit() {
            var editViewModel = editViewModelFactory.Create(userId);
            windowManager.ShowDialog(editViewModel);
        }

         public void Add() {
            var editViewModel = addViewModelFactory.Create(userId);
            windowManager.ShowDialog(editViewModel);
        }

        public void Handle(UserDetailsUpdated message) {
            RefreshUser();
        }

        protected override void OnActivate() {
            RefreshUser();
        }

        void RefreshUser() {
            var user = userRepository.Get(userId);
            Firstname = user.Firstname;
            Lastname = user.Lastname;
        }
    }
}