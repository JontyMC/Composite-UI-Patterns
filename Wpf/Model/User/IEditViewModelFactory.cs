namespace Model.User {
    public interface IEditViewModelFactory {
        EditViewModel Create(int userId);
    }
}