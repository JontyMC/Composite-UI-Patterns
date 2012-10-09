using Caliburn.Micro;

namespace Conductor.Files {
    public class FileEditorViewModel : Conductor<IFileViewModel>.Collection.OneActive {
        public FileEditorViewModel() {
            Items.Add(new TextFileViewModel("Some text file 1"));
            Items.Add(new TextFileViewModel("Some text file 2"));
        }
    }

    public class TextFileViewModel : Screen, IFileViewModel {
        public TextFileViewModel(string displayName) {
            DisplayName = displayName;
        }
    }

    public interface IFileViewModel : IHaveDisplayName {}
}