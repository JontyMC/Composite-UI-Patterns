using Caliburn.Micro;
using Screens.Twitter;
using Screens.WhatsNew;

namespace Screens.WidgetPicker {
    public class WidgetPickerViewModel : Conductor<object> {
        public WidgetPickerViewModel() {
            SwitchToWidget2();
        }

        public void SwitchToWidget1() {
            ActivateItem(new WhatsNewViewModel());
        }

        public void SwitchToWidget2() {
            ActivateItem(new TwitterFeedViewModel());
        }
    }
}