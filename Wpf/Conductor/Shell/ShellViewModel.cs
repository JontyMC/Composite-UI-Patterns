using Caliburn.Micro;
using Conductor.Files;
using Conductor.Search;
using Conductor.Workspaces;

namespace Conductor.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive {
        public ShellViewModel() {
            Main = new FileEditorViewModel();
            SideBar = new MyWorkspacesViewModel();
            Widget = new SearchViewModel();
        }

        protected override void OnActivate() {
            ActivateItem(Main);
            ActivateItem(SideBar);
            ActivateItem(Widget);
        }

        public object SideBar { get; private set; }
        public object Main { get; private set; }
        public object Widget { get; private set; }
    }
}