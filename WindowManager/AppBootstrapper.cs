using System;
using System.Diagnostics;
using Caliburn.Micro;
using WindowManager.Shell;

namespace WindowManager {
    public class AppBootstrapper : Bootstrapper<ShellViewModel> {
        protected override void Configure() {
            LogManager.GetLog = x => new DebugLogger();

            Conventions();
        }

        static void Conventions() {
            var defaultLocator = ViewLocator.LocateTypeForModelType;

            ViewLocator.LocateTypeForModelType = (modelType, displayLocation, context) => {
                var viewType = defaultLocator(modelType, displayLocation, context);

                if (viewType == null) {
                    var interfaces = modelType.GetInterfaces();
                    foreach (var @interface in interfaces) {
                        viewType = defaultLocator(@interface, displayLocation, context);
                        if (viewType != null)
                            return viewType;
                    }
                }
                return viewType;
            };
        }
    }

    public class DebugLogger : ILog {
        static string CreateLogMessage(string format, params object[] args) {
            return string.Format("[{0}] {1}", DateTime.Now.ToString("o"), string.Format(format, args));
        }

        public void Info(string format, params object[] args) {
            Debug.WriteLine(CreateLogMessage(format, args), "INFO");
        }

        public void Warn(string format, params object[] args) {
            Debug.WriteLine(CreateLogMessage(format, args), "WARN");
        }

        public void Error(Exception exception) {
            Debug.WriteLine(CreateLogMessage(exception.ToString()), "INFO");
        }
    }
}