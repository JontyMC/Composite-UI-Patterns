using Conductor.Files.ToolbarButtons;

namespace Conductor.Files {
    public class ImageFileViewModel : FileViewModelBase {
        public ImageFileViewModel(string displayName, ToolbarViewModel toolbar) : base(toolbar) {
            DisplayName = displayName;
            Height = Width = 150;
        }

        int height;
        public int Height {
            get { return height; }
            set {
                height = value;
                NotifyOfPropertyChange(() => Height);
            }
        }

        int width;
        public int Width {
            get { return width; }
            set {
                width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }


        protected override IToolbarButtonViewModel[] Buttons() {
            return new IToolbarButtonViewModel[] {
                new SaveButtonViewModel(this),
                new DelegateButtonViewModel("Resize", Resize),
                new DelegateButtonViewModel("Crop", () => { }),
            };
        }

        public void Resize() {
            IsDirty = true;
            Height = Width = Height + 20;
        }
    }
}