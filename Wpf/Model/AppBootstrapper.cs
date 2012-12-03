using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Model.DomainModel.User;
using Model.Framework;
using Model.Shell;
using Model.User;
using Ninject;
using Ninject.Extensions.Factory;

namespace Model {
    public class AppBootstrapper : Bootstrapper<ShellViewModel> {
        StandardKernel kernel;

        protected override void Configure() {
            kernel = new StandardKernel();
            kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            kernel.Bind<IUserModelFactory>().ToFactory();
            kernel.Bind<INavigationService>().To<NavigationService>();
            kernel.Bind<IDetailsViewModelFactory>().ToFactory();
            kernel.Bind<IEditViewModelFactory>().ToFactory();
            kernel.Bind<IAddViewModelFactory>().ToFactory();
            kernel.Bind<IRepository<UserModel>>()
                .ToMethod(x => {
                    var factory = x.Kernel.Get<IUserModelFactory>();
                    var eventAggregator = x.Kernel.Get<IEventAggregator>();
                    var userList = new List<UserModel> {
                        factory.Create(1, "Gypsum", "Fantastic"),
                        factory.Create(2, "Remedy", "Malahide"),
                        factory.Create(3, "Peter", "O'Hanrahanrahan"),
                        factory.Create(4, "Ted", "Maul")
                    };
                    return new InMemoryUserRepository(userList, eventAggregator);
                });

            LogManager.GetLog = x => new DebugLogger();
        }

        protected override object GetInstance(Type service, string key) {
            return kernel.Get(service, key);
        }
    }
}