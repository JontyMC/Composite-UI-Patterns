using System;
using Caliburn.Micro;

namespace WindowManager.Files {
    public abstract class FileViewModelBase : Screen, IFileViewModel {
        bool isDirty;
        readonly ToolbarViewModel toolbar;
        readonly IWindowManager windowManager;

        protected FileViewModelBase(ToolbarViewModel toolbar) {
            this.toolbar = toolbar; 
            windowManager = new Caliburn.Micro.WindowManager();
        }

        public bool IsDirty {
            get { return isDirty; }
            set {
                isDirty = value;
                NotifyOfPropertyChange(() => isDirty);
            }
        }

        protected override void OnActivate() {
            toolbar.SetButtons(Buttons());
        }

        public override void CanClose(Action<bool> callback) {
            if (IsDirty) {
                var dialog = new DialogViewModel("Are you sure you want to close?");
                windowManager.ShowDialog(dialog);

                callback(!dialog.IsCancelled);
            }
            else {
                callback(true);
            }
        }

        protected abstract IToolbarButtonViewModel[] Buttons();

        public void Save() {
            //TODO: Save

            IsDirty = false;
        }
    }
}