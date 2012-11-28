namespace Model.Events {
    public class UserAdded {
        public UserAdded(int id) {
            Id = id;
        }

        public int Id { get; private set; }
    }
}