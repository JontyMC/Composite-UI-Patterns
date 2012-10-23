namespace WindowManager.Files {
    public interface IToolbarButtonViewModel {
        string Title { get; }
        void Execute();
    }
}