using Caliburn.Micro;
using Model.DomainModel.User;
using Model.Framework;

namespace Model.User {
    public class EditViewModel : Screen {
        readonly IRepository<UserModel> userRepository;
        readonly int userId;
        string firstname;
        string lastname;
        UserModel user;

        public EditViewModel(IRepository<UserModel> userRepository, int userId) {
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

        public void Save() {
            user.UpdateDetails(Firstname, Lastname);
            TryClose();
        }
    }
}