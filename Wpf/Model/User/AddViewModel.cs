using Caliburn.Micro;
using Model.DomainModel.User;
using Model.Framework;

namespace Model.User {
    public class AddViewModel : Screen {
        readonly IRepository<UserModel> userRepository;
        readonly IUserModelFactory userFactory;
        string firstname;
        string lastname;
        int id;

        public AddViewModel(IRepository<UserModel> userRepository, IUserModelFactory userFactory) {
            this.userRepository = userRepository;
            this.userFactory = userFactory;
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
            var user = userFactory.Create(id, firstname, lastname);
            userRepository.Add(user);
            TryClose();
        }
    }
}