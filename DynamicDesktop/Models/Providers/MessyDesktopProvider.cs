using DynamicDesktop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicDesktop.Models.Providers
{
    public class MessyDesktopProvider : IProvider
    {
        public TimeSpan Delay => TimeSpan.Zero;

        public string Name => "Messy Desktop";

        public string Description => "Display the current messy state of your desktop (based on how many files there are)";

        private readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public async Task<string> GenerateTextAsync()
        {
            Console.WriteLine($"Watching {Path}");

            string text = null;
            FileSystemEventHandler handler = null;
            try
            {
                using (var watcher = new FileSystemWatcher())
                {
                    using (var cts = new CancellationTokenSource())
                    {
                        handler = new FileSystemEventHandler((object sender, FileSystemEventArgs ev) =>
                        {
                            watcher.Changed -= handler;

                            var desktopFileCount = Directory.GetFiles(Path).Length;

                            if (desktopFileCount > 25)
                                text = "Messy";
                            else if (desktopFileCount > 10)
                                text = "Okay";
                            else if (desktopFileCount > 5)
                                text = "Clean";
                            else
                                text = "Exceptional";

                            cts.Cancel();
                        });
                        watcher.Path = Path;
                        watcher.NotifyFilter = NotifyFilters.LastWrite;
                        watcher.Filter = "*.*";
                        watcher.Changed += handler;
                        watcher.EnableRaisingEvents = true;

                        await Task.Delay(-1, cts.Token);
                    }
                }
            }
            catch (TaskCanceledException) { }

            return text;
        }
    }
}
