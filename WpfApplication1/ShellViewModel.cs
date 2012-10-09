using System.Windows;
using Caliburn.Micro;

namespace WpfApplication1 {
    public class ShellViewModel : Conductor<object> {
        public ShellViewModel() {
            SwitchToWidget1();
        }

        public void SwitchToWidget1() {
            ActivateItem(new WhatsNewViewModel());
        }

        public void SwitchToWidget2() {
            ActivateItem(new TwitterFeedViewModel());
        }
    }

    public class TwitterFeedViewModel : Screen
    {
        protected override void OnActivate()
        {
            MessageBox.Show("Page Two Activated"); //Don't do this in a real VM.
            base.OnActivate();
        }
    }

    public class WhatsNewViewModel {}
}