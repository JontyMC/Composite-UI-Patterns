using System.Collections.Generic;
using System.Linq;
using Model.Framework;

namespace Model.User {
    public class InMemoryUserRepository : IRepository<UserModel> {
        readonly ICollection<UserModel> users;

        public InMemoryUserRepository(ICollection<UserModel> users) {
            this.users = users;
        }

        public UserModel Get(int id) {
            return users.Single(x => x.Id == id);
        }

        public void Add(UserModel entity) {
            users.Add(entity);
        }

        public void Remove(UserModel entity) {
            users.Remove(entity);
        }
    }
}