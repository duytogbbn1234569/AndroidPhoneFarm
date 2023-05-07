using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Code.Utils.Story
{
    public class DangKyKenhYoutubeScript : BaseScript
    {
        private readonly ADBUtils adb;
        private readonly string intent = "android.intent.action.VIEW";
        private readonly string youtube = "com.google.android.youtube";
        private readonly string url;
        public DangKyKenhYoutubeScript(string deviceId, string url) : base()
        {
            this.url = url;
            this.adb = new ADBUtils(deviceId);
        }
        public override bool RunScript()
        {
            XmlNode node = null;
            var script = new BaseScript();
            var stopAcivity = new BaseScript()
            {
                action = () =>
                {
                    adb.stopPackage(youtube);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(500);
                }
            };
            var startYoutubeChannel = new BaseScript()
            {
                action = () =>
                {
                    adb.startIntent(intent, url);
                    Thread.Sleep(5000);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(500);
                }
            };
            var startYoutube= new BaseScript()
            {
                action = () =>
                {
                    adb.startPackage(intent);
                    Thread.Sleep(500);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(500);
                }
            };
            var clickSubrice = new BaseScript()
            {
                canAction = () =>
                {
                    node = null;
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                    {
                        return n.Attributes["content-desc"].InnerText.IndexOf("Subscribe") != -1;
                    }));
                    node = needView.FirstOrDefault();
                    return needView.Count > 0;
                },
                action = () =>
                {
                    var b = Bound.ofXMLNode(node);
                    var x = b.x + b.h / 2;
                    var y = b.y + b.w / 2;
                    adb.tap(x, y);
                    Thread.Sleep(5000);
                }
            };
            var switchAccount = new BaseScript()
            {

            };
            script.AddNext(
                stopAcivity.AddNext(
                    startYoutubeChannel.AddNext(
                    clickSubrice
                        )
                    )
                );
            return script.RunScript();
        }
    }
}
