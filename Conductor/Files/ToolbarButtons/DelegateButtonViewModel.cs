using System;

namespace Conductor.Files.ToolbarButtons {
    public class DelegateButtonViewModel : IToolbarButtonViewModel {
        readonly Action action;

        public DelegateButtonViewModel(string title, Action action) {
            Title = title;
            this.action = action;
        }

        public string Title { get; private set; }
        public void Execute() {
            action();
        }
    }
}