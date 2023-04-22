using Code.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Utils
{
    public class ADBUtils
    {
        public readonly static string path = @"C:\Users\duyto\AppData\Local\Android\Sdk\platform-tools\adb.exe";

        private readonly string deviceId;

        public ADBUtils(string deviceId)
        {
            this.deviceId = deviceId;
        }

        public static string RunAdbCommand(string cmd, bool needOutput = false)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = needOutput;
            startInfo.FileName = ADBUtils.path;
            startInfo.Arguments = cmd;
            startInfo.UseShellExecute = false;
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            string output = "";
            if (needOutput)
            {
                output = process.StandardOutput.ReadToEnd();
            }
            process.WaitForExit();

            return output;
        }

        public string runAdbCommand(string cmd, bool needOutput = false)
        {
            return RunAdbCommand(String.Format("-s {0} {1}", this.deviceId, cmd), needOutput);
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
        public static List<string> getListDevices()
        {
            var result = new List<string>();
            string[] lines = RunAdbCommand("devices", true).Split('\n');
            lines = lines.Skip(1).ToArray();
            foreach (var line in lines)
            {
                var l = line.Trim();
                if (l != "")
                {
                    var words = l.Split('\t');
                    result.Add(words[0]);
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
    }

}
