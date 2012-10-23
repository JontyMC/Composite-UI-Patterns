namespace Model.User {
    public interface IAddViewModelFactory {
        AddViewModel Create(int userId);
    }
}