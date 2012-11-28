using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Caliburn.Micro;
using Model.Events;
using Model.User;

namespace Model.Shell {
    public class NavigationService : INavigationService {
        readonly IEventAggregator eventAggregator;

        public NavigationService(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;
        }

        public void NavigateTo(string url) {
            var viewModel = ViewModelFromUrl(url);
            var message = new NavigationOccurred(url, viewModel);
            eventAggregator.Publish(message);
        }

        public string UrlFromViewModel<TViewModel>(object args) {
            var type = typeof (TViewModel);
            var argDictionary = args.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(property => property.CanRead).ToDictionary(property => property.Name, property => property.GetValue(args, null));

            if (type == typeof (DetailsViewModel)) {
                return "user/" + argDictionary["Id"];
            }

            return string.Empty;
        }

        public object ViewModelFromUrl(string url) {
            var regex = new Regex("(.*)/(.*)");
            var route = regex.Match(url);

            if (route.Success) {
                if (route.Groups[1].Value.ToLowerInvariant() == "user") {
                    var id = Convert.ToInt32(route.Groups[2].Value);
                    var factory = IoC.Get<IDetailsViewModelFactory>();
                    return factory.Create(id);
                }
            }
            return new NotFoundViewModel();
        }
    }
}