using System;
using System.Text.RegularExpressions;
using Caliburn.Micro;
using Model.User;

namespace Model.Shell {
    public class NavigationService : INavigationService {
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