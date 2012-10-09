using Caliburn.Micro;
using Conductor.Files;
using Conductor.Search;
using Conductor.Workspaces;

namespace Conductor.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive {
        public ShellViewModel() {
            Items.Add(new FileEditorViewModel());
            Items.Add(new MyWorkspacesViewModel());
            Items.Add(new SearchViewModel());
            Main = Items[0];
            SideBar = Items[1];
            Widget = Items[2];
        }

        public object SideBar { get; private set; }
        public object Main { get; private set; }
        public object Widget { get; private set; }
    }
}