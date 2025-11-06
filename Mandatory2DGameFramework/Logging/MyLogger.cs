using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Logging
{
    public class MyLogger
    {

        private static readonly MyLogger _instance = new MyLogger();
        private TraceSource _traceSource;

        private MyLogger() {
            _traceSource = new TraceSource("GameTracer", SourceLevels.All);
            _traceSource.Switch = new SourceSwitch("GameSwitch", "All");

            TraceListener traceListener = new ConsoleTraceListener();
            _traceSource.Listeners.Add(traceListener);
            _traceSource.Flush();
        }
        public static MyLogger Instance { get { return _instance; } }
        public void LogInfo(string message) {
            _traceSource.TraceEvent(TraceEventType.Information, 1, message);
            _traceSource.Flush();
        }
        public void LogWarning(string message) {
            _traceSource.TraceEvent(TraceEventType.Warning, 1, message);
            _traceSource.Flush();
        }
        public void AddListener(TraceListener listener) {
            _traceSource.Listeners.Add(listener);
        }
        public void RemoveListener(TraceListener listener) {
            _traceSource.Listeners.Remove(listener);
        }
    }
}
