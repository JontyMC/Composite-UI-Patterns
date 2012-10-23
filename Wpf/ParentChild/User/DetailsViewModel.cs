using Caliburn.Micro;

namespace ParentChild.User {
    public class DetailsViewModel : Screen {
        string firstname;
        string lastname;
        readonly IWindowManager windowManager;

        public DetailsViewModel(string firstname, string lastname) {
            this.firstname = firstname;
            this.lastname = lastname;
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
            var editViewModel = new EditViewModel(this);
            windowManager.ShowDialog(editViewModel);
        }
    }
}