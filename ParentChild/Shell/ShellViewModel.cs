using Caliburn.Micro;
using ParentChild.Search;
using ParentChild.User;
using ParentChild.Workspaces;

namespace ParentChild.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive {
        public ShellViewModel() {
            Items.Add(new DetailsViewModel("Gypsum", "Fantastic"));
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