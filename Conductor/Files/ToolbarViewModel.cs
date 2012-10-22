using Caliburn.Micro;
using Conductor.Files.ToolbarButtons;

namespace Conductor.Files {
    public class ToolbarViewModel {
        readonly FileEditorViewModel fileEditor;

        public ToolbarViewModel(FileEditorViewModel fileEditor) {
            this.fileEditor = fileEditor;
            Buttons = new BindableCollection<IToolbarButtonViewModel>();
        }

        public BindableCollection<IToolbarButtonViewModel> Buttons { get; private set; }

        public void SetButtons(IToolbarButtonViewModel[] buttons) {
            Buttons.Clear();
            Buttons.Add(new DelegateButtonViewModel("Reset", () => fileEditor.LoadFiles()));
            Buttons.AddRange(buttons);
        }
    }
}