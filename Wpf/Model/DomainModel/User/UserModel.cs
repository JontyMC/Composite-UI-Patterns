using Caliburn.Micro;
using Model.DomainModel.Events;

namespace Model.DomainModel.User {
    public class UserModel {
        readonly IEventAggregator eventAggregator;

        public UserModel(IEventAggregator eventAggregator, int id, string firstname, string lastname) {
            this.eventAggregator = eventAggregator;
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }

        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        public void UpdateDetails(string firstname, string lastname) {
            Firstname = firstname;
            Lastname = lastname;
            eventAggregator.Publish(new UserDetailsUpdated(Id));
        }
    }
}