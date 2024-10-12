using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    public enum LogLevel
    {
        INFO, WARNING, ERROR
    }

    public class Logger
    {
        private static Logger _instance;
        private static readonly object lockObject = new object();
        private string _logFilePath = "C:\\Users\\bauir\\OneDrive\\Рабочий стол\\log.txt";
        private LogLevel _logLevel = LogLevel.INFO;

        private Logger() { }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }
            return _instance;
        }

        public void Log(string message, LogLevel level)
        {
            if(_logLevel <= level)
            {
                lock (lockObject)
                {
                    if (_logLevel == level)
                        File.AppendAllText(_logFilePath, level + " | " + message + Environment.NewLine);
                }
            }
        }

        public void SetLogLevel(LogLevel level)
        {
            _logLevel = level;
        }

        public void SetLogFilePath(string path)
        {
            _logFilePath = path;
        }

        public void ReadLogs()
        {
            if (File.Exists(_logFilePath))
            {
                Console.WriteLine("Logs from file:");
                foreach (string line in File.ReadAllLines(_logFilePath))
                    Console.WriteLine(line);
            }
            else
                Console.WriteLine("Log file doesnt exist.");
        }
    }
}
