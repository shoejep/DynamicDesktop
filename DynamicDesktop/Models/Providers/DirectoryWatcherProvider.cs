﻿using DynamicDesktop.Models.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicDesktop.Models.Providers
{
    public class ErrorEmailProvider : IProvider
    {
        public TimeSpan Delay => TimeSpan.Zero;

        private readonly string Path = "C://tmp//";

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
                            text = ev.Name;
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
