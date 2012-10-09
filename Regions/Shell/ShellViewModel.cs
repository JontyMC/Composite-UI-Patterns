using Regions.Search;
using Regions.WhatsNew;
using Regions.Workspaces;

namespace Regions.Shell {
    public class ShellViewModel {
        public ShellViewModel() {
            Main = new WhatsNewViewModel();
            SideBar = new MyWorkspacesViewModel();
            Widget = new SearchViewModel();
        }

        public object SideBar { get; private set; }
        public object Main { get; private set; }
        public object Widget { get; private set; }
    }
}