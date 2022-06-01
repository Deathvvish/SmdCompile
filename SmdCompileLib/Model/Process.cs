using System;
using System.Diagnostics;

namespace SmdCompileLib.Model
{
    public class Process // Долбаеб 228
    {
        //public Action<string> OutputDataReceived;
        public DataReceivedEventHandler EventDataReceivedHandler;
        System.Diagnostics.Process process;
        public string FileName
        {
            get; set;
        }
        public string Args
        {
            get; set;
        } = "";
        public void Start()
        {
            process = System.Diagnostics.Process.Start(new ProcessStartInfo()
            { 
                   FileName = FileName,
                   Arguments = Args,
                   UseShellExecute = false,
                   CreateNoWindow = true,
                   RedirectStandardOutput = true,
            });
            process.BeginOutputReadLine();
            process.OutputDataReceived += EventDataReceivedHandler;
          
            process.Start();
        }
        public void Close()
        {
            process?.Close();
            process.Dispose();
        }
         
    }
}
