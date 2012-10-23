using Caliburn.Micro;
using Model.Framework;

namespace Model.User {
    public class EditViewModel : Screen {
        readonly IEventAggregator eventAggregator;
        readonly IRepository<UserModel> userRepository;
        readonly int userId;
        string firstname;
        string lastname;
        UserModel user;

        public EditViewModel(IEventAggregator eventAggregator, IRepository<UserModel> userRepository, int userId) {
            this.eventAggregator = eventAggregator;
            this.userRepository = userRepository;
            this.userId = userId;
            DisplayName = "Edit";
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

        protected override void OnActivate() {
            user = userRepository.Get(userId);
            Firstname = user.Firstname;
            Lastname = user.Lastname;
        }

        public void Edit() {
            user.UpdateDetails(eventAggregator, Firstname, Lastname);
            TryClose();
        }
    }
}