using Caliburn.Micro;
using Model.Framework;

namespace Model.User {
    public class AddViewModel : Screen {
        readonly IRepository<UserModel> userRepository;
        string firstname;
        string lastname;
        int id;

        public AddViewModel(IRepository<UserModel> userRepository) {
            this.userRepository = userRepository;
            DisplayName = "Edit";
        }

        public int Id {
            get { return id; }
            set {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
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

        public void Add() {
            var user = new UserModel(id, firstname, lastname);
            userRepository.Add(user);
            TryClose();
        }
    }
}