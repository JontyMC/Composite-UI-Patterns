using System;
using System.Collections.Generic;
using Caliburn.Micro;
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
            kernel.Bind<IRepository<UserModel>>()
                .ToMethod(_ => new InMemoryUserRepository(new List<UserModel> {
                    new UserModel(1, "Gypsum", "Fantastic"),
                    new UserModel(2, "Remedy", "Malahide"),
                    new UserModel(3, "Peter", "O'Hanrahanrahan"),
                    new UserModel(4, "Ted", "Maul")
                }))
                .InSingletonScope();
            kernel.Bind<INavigationService>().To<NavigationService>();
            kernel.Bind<IDetailsViewModelFactory>().ToFactory();
            kernel.Bind<IEditViewModelFactory>().ToFactory();
            kernel.Bind<IAddViewModelFactory>().ToFactory();

            LogManager.GetLog = x => new DebugLogger();
        }

        protected override object GetInstance(Type service, string key) {
            return kernel.Get(service, key);
        }
    }
}