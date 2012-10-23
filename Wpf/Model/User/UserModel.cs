using Caliburn.Micro;
using Model.Events;

namespace Model.User {
    public class UserModel {
        public UserModel(int id, string firstname, string lastname) {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }

        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        public void UpdateDetails(IEventAggregator eventAggregator, string firstname, string lastname) {
            Firstname = firstname;
            Lastname = lastname;
            eventAggregator.Publish(new UserDetailsUpdated(Id));
        }
    }
}