namespace Model.DomainModel.Events {
    public class UserDetailsUpdated {
        public UserDetailsUpdated(int id) {
            Id = id;
        }

        public int Id { get; private set; }
    }
}