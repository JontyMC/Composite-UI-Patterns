using System;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using Model.Shell;
using Navigation.Events;

namespace Navigation.Shell {
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

        static object ViewModelFromUrl(string url) {
            if (!string.IsNullOrEmpty(url)) {
                var viewModelTypes = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name.EndsWith("ViewModel"));
                var viewModelType = viewModelTypes.FirstOrDefault(x => x.Name.StartsWith(url, StringComparison.InvariantCultureIgnoreCase));
                if (viewModelType != null) {
                    return Activator.CreateInstance(viewModelType);
                }
            }
            return new NotFoundViewModel();
        }
    }
}