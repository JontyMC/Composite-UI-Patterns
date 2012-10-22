using Caliburn.Micro;

namespace WindowManager.Files {
    public class DialogViewModel : Screen {
        public bool IsCancelled { get; private set; }
        public string Message { get; private set; }

        public DialogViewModel(string message) {
            Message = message;
            IsCancelled = true;
        }

        public void Ok() {
            IsCancelled = false;
            TryClose();
        }

        public void Cancel() {
            TryClose();
        }
    }
}