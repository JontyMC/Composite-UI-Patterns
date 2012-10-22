namespace Conductor.Files.ToolbarButtons {
    public class SaveButtonViewModel : IToolbarButtonViewModel {
        readonly ISavable savable;

        public SaveButtonViewModel(ISavable savable) {
            this.savable = savable;
        }

        public string Title {
            get { return "Save"; }
        }

        public void Execute() {
            savable.Save();
        }
    }
}