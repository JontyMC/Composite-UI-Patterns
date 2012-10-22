using Caliburn.Micro;

namespace ParentChild.User {
    public class EditViewModel : Screen {
        readonly DetailsViewModel detailsViewModel;
        string firstname;
        string lastname;

        public EditViewModel(DetailsViewModel detailsViewModel) {
            this.detailsViewModel = detailsViewModel;
            firstname = detailsViewModel.Firstname;
            lastname = detailsViewModel.Lastname;
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

        public void Edit() {
            detailsViewModel.Firstname = Firstname;
            detailsViewModel.Lastname = Lastname;
            TryClose();
        }
    }
}