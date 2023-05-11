using Code.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Utils
{
    public class ADBUtils
    {
        public readonly static string path = "adb.exe";

        private readonly string deviceId;

        private readonly bool throwExceptionOnError;

        public ADBUtils(string deviceId, bool throwExceptionOnError = false)
        {
            this.deviceId = deviceId;
            this.throwExceptionOnError = throwExceptionOnError;
        }

        public static string RunAdbCommand(string cmd, bool needOutput = false, bool throwExceptionOnError = false)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = needOutput;
            startInfo.RedirectStandardError = throwExceptionOnError;
            startInfo.FileName = ADBUtils.path;
            startInfo.Arguments = cmd;
            startInfo.UseShellExecute = false;
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            string output = "";
            string error = "";
            if (needOutput)
            {
                output = process.StandardOutput.ReadToEnd();
            }
            if (throwExceptionOnError)
            {
                error = process.StandardError.ReadToEnd();
            }
            process.WaitForExit();
            if (error != "")
            {
                throw new AdbException(cmd, error);
            }
            return output;
        }

        public string runAdbCommand(string cmd, bool needOutput = false)
        {
            return RunAdbCommand(String.Format("-s {0} {1}", this.deviceId, cmd), needOutput, this.throwExceptionOnError);
        }

        public string getCurrentView()
        {
            runAdbCommand("shell uiautomator dump /sdcard/view.xml");

            var output = runAdbCommand("shell cat /sdcard/view.xml", true);

            return output;
        }

        public void tap(int x, int y)
        {
            runAdbCommand(String.Format("shell input tap {0} {1}", x, y));
        }

        public void swipe(int fX, int fY, int tX, int tY)
        {
            runAdbCommand(String.Format("shell input swipe {0} {1} {2} {3}", fX, fY, tX, tY));
        }

        public void typeText(string text)
        {
            runAdbCommand(String.Format("shell input text {0}", text));
        }
        public void tabEvent()
        {
            runAdbCommand(String.Format("shell input keyevent 61"));
        } 
        public void enterEvent()
        {
            runAdbCommand(String.Format("shell input keyevent 66"));
        }
        public static List<Tuple<string, string>> getListDevices()
        {
            var result = new List<Tuple<string, string>>();
            string[] lines = RunAdbCommand("devices", true).Split('\n');
            lines = lines.Skip(1).ToArray();
            foreach (var line in lines)
            {
                var l = line.Trim();
                if (l != "")
                {
                    var words = l.Split('\t');
                    result.Add(new Tuple<string, string>(words[0], words[1]));
                }
            }
            return result;
        }

        public void startPackage(string package)
        {
            runAdbCommand(String.Format("shell am start {0}", package));
        }

        public void stopPackage(string package)
        {
            runAdbCommand(String.Format("shell am force-stop {0}", package));
        }
        public void startIntent(string intent, string url)
        {
            runAdbCommand(String.Format("shell am start -a {0} {1}", intent, url));
        }
    }

    class AdbException: Exception
    {
        private readonly string command;
        private readonly string errorMessage;

        public AdbException(string command, string errorOutput): base()
        {
            this.command = command;
            this.errorMessage = errorOutput;
        }

        public override string Message
        {
            get
            {
                return "ADB:ERROR:COMMAND = " + command + ", ERROR = " + errorMessage;
            }
        }
    }

}
