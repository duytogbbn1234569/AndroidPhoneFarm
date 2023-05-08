using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
        XmlNode node = null;
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
                    adb.startPackage(youtube);
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
            var switchAccount = switchAccountGoogle();
            script.AddNext(
                stopAcivity.AddNext(
                    startYoutube.AddNext(
                        switchAccount
                        )
                    )
                );
            return script.RunScript();
        }

        private BaseScript switchAccountGoogle()
        {
            return new BaseScript()
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                },
                action = () =>
                {
                    int xAccount = 0, yAccount = 0, xAccountName = 0, yAccountName = 0;
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                    {
                        return n.Attributes["content-desc"].InnerText == "Account";
                    }));
                    node = needView.FirstOrDefault();
                    if (needView.Count > 0)
                    {
                        var b = Bound.ofXMLNode(node);
                        xAccount = b.x + b.h / 2;
                        yAccount = b.y + b.w / 2;
                        adb.tap(xAccount, yAccount);
                        Thread.Sleep(1000);
                    }

                    screen = this.adb.getCurrentView();
                    needView = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                    {
                        return n.Attributes["resource-id"].InnerText == "com.google.android.youtube:id/account_name";
                    }));
                    node = needView.FirstOrDefault();
                    if (needView.Count > 0)
                    {
                        var b = Bound.ofXMLNode(node);
                        xAccountName = b.x + b.h / 2;
                        yAccountName = b.y + b.w / 2;
                        adb.tap(xAccountName, yAccountName);
                        Thread.Sleep(1000);
                    }

                    screen = this.adb.getCurrentView();
                    var numberAcoounts = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                    {
                        return String.Compare(n.Attributes["resource-id"].InnerText, "com.google.android.youtube:id/account", true) == 0;
                    }));
                    int index = numberAcoounts.Count-1;
                    
                    while (index > 0)
                    {
                        screen = this.adb.getCurrentView();
                        numberAcoounts = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                        {
                            return String.Compare(n.Attributes["resource-id"].InnerText, "com.google.android.youtube:id/account", true) == 0;
                        }));
                        var nodeAccount = numberAcoounts[index];
                        var b = Bound.ofXMLNode(nodeAccount);
                        var x = b.x + b.h / 2;
                        var y = b.y + b.w / 2;
                        adb.tap(x, y);
                        Thread.Sleep(3000);
                        index--;

                        adb.startIntent(intent, url);
                        Thread.Sleep(1000);

                        screen = this.adb.getCurrentView();
                        needView = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                        {
                            return n.Attributes["content-desc"].InnerText.IndexOf("Subscribe") != -1;
                        }));
                        node = needView.FirstOrDefault();
                        if (needView.Count > 0)
                        {
                            b = Bound.ofXMLNode(node);
                            x = b.x + b.h / 2;
                            y = b.y + b.w / 2;
                            adb.tap(x, y);
                            Thread.Sleep(1000);
                        }

                        adb.stopPackage(youtube);
                        Thread.Sleep(1000);
                        adb.startPackage(youtube);
                        Thread.Sleep(3000);
                        adb.tap(xAccount, yAccount);
                        Thread.Sleep(1000);

                        adb.tap(xAccountName, yAccountName);
                        Thread.Sleep(1000);
                    }
                }
            };
        }
    }
}
