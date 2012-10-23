using Caliburn.Micro;

namespace WindowManager.Files {
    public class FileEditorViewModel : Conductor<IFileViewModel>.Collection.OneActive {
        public FileEditorViewModel() {
            Toolbar = new ToolbarViewModel(this);
            LoadFiles();
        }

        public ToolbarViewModel Toolbar { get; private set; }

        public void LoadFiles()
        {
            Items.Clear();
            Items.Add(new TextFileViewModel("Some text file 1", Toolbar));
            Items.Add(new TextFileViewModel("Some text file 2", Toolbar));
            Items.Add(new ImageFileViewModel("An image", Toolbar));
        }
    }
}