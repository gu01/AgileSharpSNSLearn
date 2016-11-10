﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AgileSharp.SNS.Infrastructure.Files
{
    public static class FileWatcherManager
    {
        private static Dictionary<string, FileSystemWatcher> watcherContainer = new Dictionary<string, FileSystemWatcher>();

        public static FileSystemWatcher CreateWatcherFor(string path, string filter)
        {
            FileSystemWatcher result = null;
            string key = path + "\\" + filter;
            if (watcherContainer.ContainsKey(key))
            {
                result = watcherContainer[key];
            }
            else
            {
                result = new FileSystemWatcher(path);
                result.Filter = filter;
                result.EnableRaisingEvents=true;
                result.NotifyFilter = NotifyFilters.LastWrite;
                watcherContainer.Add(key, result);
            }
            return result;
        }
    }
}
