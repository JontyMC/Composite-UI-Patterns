using WindowManager.Files.ToolbarButtons;

namespace WindowManager.Files {
    public class TextFileViewModel : FileViewModelBase {
        public TextFileViewModel(string displayName, ToolbarViewModel toolbar) : base(toolbar) {
            DisplayName = displayName;
        }

        protected override IToolbarButtonViewModel[] Buttons() {
            return new IToolbarButtonViewModel[] {
                new SaveButtonViewModel(this)
            };
        }

        public void MarkAsDirty() {
            IsDirty = true;
        }
    }
}