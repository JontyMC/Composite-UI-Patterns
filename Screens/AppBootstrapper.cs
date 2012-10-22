using System;
using System.Diagnostics;
using Caliburn.Micro;
using Screens.Shell;

namespace Screens {
    public class AppBootstrapper : Bootstrapper<ShellViewModel> {
        protected override void Configure() {
            LogManager.GetLog = x => new DebugLogger();
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