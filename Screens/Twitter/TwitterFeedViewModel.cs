using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Caliburn.Micro;

namespace Screens.Twitter {
    public class TwitterFeedViewModel : Screen {
        public TwitterFeedViewModel() {
            Tweets = new BindableCollection<TweetViewModel>();
        }

        public BindableCollection<TweetViewModel> Tweets { get; private set; }

        bool isBusy;
        public bool IsBusy {
            get { return isBusy; }
            set {
                isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        protected override void OnActivate() {
            IsBusy = true;
            RefreshTweets();
        }

        public void RefreshTweets() {
            new WebClient()
                .DownloadStringTaskAsync("http://search.twitter.com/search.json?q=huddle")
                .ContinueWith(MapTweets);
        }

        void MapTweets(Task<string> x) {
            Thread.Sleep(2000);
            var json = new JavaScriptSerializer().Deserialize<dynamic>(x.Result);
            Tweets.Clear();
            foreach (var result in json["results"]) {
                Tweets.Add(new TweetViewModel(result["text"]));
            }
            IsBusy = false;
        }
    }
}