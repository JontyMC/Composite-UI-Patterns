using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Model.DomainModel.Events;
using Model.Framework;

namespace Model.DomainModel.User {
    public class InMemoryUserRepository : IRepository<UserModel> {
        readonly ICollection<UserModel> users;
        readonly IEventAggregator eventAggregator;

        public InMemoryUserRepository(ICollection<UserModel> users, IEventAggregator eventAggregator) {
            this.users = users;
            this.eventAggregator = eventAggregator;
        }

        public UserModel Get(int id) {
            return users.Single(x => x.Id == id);
        }

        public IEnumerable<UserModel> GetAll() {
            return users;
        }

        public void Add(UserModel entity) {
            users.Add(entity);
            eventAggregator.Publish(new UserAdded(entity.Id));
        }
    }
}