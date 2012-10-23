using System;
using Caliburn.Micro;

namespace Conductor.Files {
    public abstract class FileViewModelBase : Screen, IFileViewModel {
        bool isDirty;
        readonly ToolbarViewModel toolbar;

        protected FileViewModelBase(ToolbarViewModel toolbar) {
            this.toolbar = toolbar;
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
            callback(!IsDirty);
        }

        protected abstract IToolbarButtonViewModel[] Buttons();

        public void Save() {
            //TODO: Save

            IsDirty = false;
        }
    }
}