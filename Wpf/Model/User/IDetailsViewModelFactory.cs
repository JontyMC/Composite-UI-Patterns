namespace Model.User {
    public interface IDetailsViewModelFactory {
        DetailsViewModel Create(int userId);
    }
}