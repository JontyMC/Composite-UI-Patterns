using Caliburn.Micro;
using ParentChild.User;

namespace ParentChild.Shell {
    public class ShellViewModel : Conductor<object>.Collection.AllActive {
        public ShellViewModel() {
            Items.Add(new DetailsViewModel("Gypsum", "Fantastic"));
            Main = Items[0];
        }

        public object SideBar { get; private set; }
        public object Main { get; private set; }
        public object Widget { get; private set; }
    }
}