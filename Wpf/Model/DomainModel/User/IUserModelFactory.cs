namespace Model.DomainModel.User {
    public interface IUserModelFactory {
        UserModel Create(int id, string firstname, string lastname);
    }
}