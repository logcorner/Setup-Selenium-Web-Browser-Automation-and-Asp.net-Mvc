using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Setup
{
    public abstract class IisRexpressServerStartup
    {
        private int _iisPort
        {
            get
            {
                if (int.TryParse(ConfigurationManager.AppSettings["webSitePort"], out var value))
                {
                    return value;
                }
                throw new InvalidOperationException("Port number incorrect");
            }
        }

        private readonly string _applicationName;
        private static Process _iisProcess;

        protected IisRexpressServerStartup(string applicationName)
        {
            _applicationName = applicationName;
        }

        protected void TestInitialize()
        {
            StartIis();
        }

        protected void TestCleanup()
        {
            if (_iisProcess.HasExited == false)
            {
                _iisProcess.Kill();
            }
        }

        public abstract void Initialize();

        public abstract void Cleanup();

        private void StartIis()
        {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + @"\IIS Express\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = $"/path:\"{applicationPath}\" /port:{_iisPort}";
            _iisProcess.Start();
        }

        private string GetApplicationPath(string applicationName)
        {
            var projectFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            var parent = Directory.GetParent(projectFolder);
            return Path.Combine(parent.FullName, applicationName);
        }

        public string GetAbsoluteUrl(string relativeUrl)
        {
            if (!relativeUrl.StartsWith("/"))
            {
                relativeUrl = "/" + relativeUrl;
            }
            return $"http://localhost:{_iisPort}/{relativeUrl}";
        }
    }
}