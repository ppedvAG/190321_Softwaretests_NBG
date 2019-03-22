using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messen
{
    class Test
    {
        public Test(params Action[] methodsToTest)
        {
            this.methodsToTest = methodsToTest;
            stopwatch = new Stopwatch();
            log = new StringBuilder();
            AppDomain.MonitoringIsEnabled = true;
        }
        private readonly Action[] methodsToTest;
        private readonly Stopwatch stopwatch;
        private readonly StringBuilder log;

        public string RunTestForAllMethods()
        {
            log.Clear();
            foreach (Action method in methodsToTest)
            {
                GC.Collect();
                GC.WaitForFullGCComplete();

                stopwatch.Restart();
                method?.Invoke();
                stopwatch.Stop();
                log.AppendLine("----------------------------------------------------------------------");
                log.AppendLine($"[{method.Method.Name}]: Time: {stopwatch.ElapsedMilliseconds}ms");
                log.AppendLine($"[{method.Method.Name}]: Allocated: {AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize / 1024:#,#} kb");
                log.AppendLine($"[{method.Method.Name}]: Peak Working Set: {Process.GetCurrentProcess().PeakWorkingSet64 / 1024:#,#} kb");
                log.AppendLine($"[{method.Method.Name}]: GC total memory: {GC.GetTotalMemory(false)} bytes");
                log.AppendLine($"[{method.Method.Name}]: GC collections in Gen 0: {GC.CollectionCount(0)}");
                log.AppendLine($"[{method.Method.Name}]: GC collections in Gen 1: {GC.CollectionCount(1)}");
                log.AppendLine($"[{method.Method.Name}]: GC collections in Gen 2: {GC.CollectionCount(2)}");
            }
            return log.ToString();
        }
    }
}
