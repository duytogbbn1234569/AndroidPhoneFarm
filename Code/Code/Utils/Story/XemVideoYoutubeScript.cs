using Code.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Code.Utils.Story
{
    public class XemVideoYoutubeScript : BaseScript
    {
        private readonly ADBUtils adb;
        private readonly string intent = "android.intent.action.VIEW";
        private readonly string youtube = "com.google.android.youtube";
        private readonly string url;
        private readonly int thoiGianXem;
        public XemVideoYoutubeScript(string deviceId, string url, int thoiGianXem) : base()
        {
            this.url = url;
            this.thoiGianXem = thoiGianXem;
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
            var startYoutube = new BaseScript()
            {
                action = () =>
                {
                    adb.startIntent(intent, url);
                    Thread.Sleep(500);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(500);
                }
            };
            var skipAdv = new BaseScript()
            {
                init = () =>
                {
                    Thread.Sleep(5000);
                },
                action = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                    {
                        return n.Attributes["text"].InnerText == "Skip ads";
                    }));
                    if (needView.Count > 0)
                    {
                        var time = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                        {
                            return n.Attributes["text"].InnerText.IndexOf("Ad") != -1;
                        }));
                        if (time.Count > 0)
                        {
                            var tmp = time.FirstOrDefault();
                            string txt = tmp.Attributes["text"].InnerText;
                            int vt = txt.IndexOf(":");
                            string txtPhut = txt.Substring(vt - 2, 2);
                            string txtGiay = txt.Substring(vt + 1, 2);
                            int minutes = int.Parse(txtPhut);
                            int seconds = int.Parse(txtGiay);
                            if (minutes > 0 || seconds > 10)
                            {
                                var node = needView.FirstOrDefault();
                                var b = Bound.ofXMLNode(node);
                                var x = b.x + b.h / 2;
                                var y = b.y + b.w / 2;
                                adb.tap(x, y);
                            }
                        }
                        
                    }
                }
            };
            var wait = new BaseScript()
            {
                init = () =>
                {
                    Thread.Sleep((thoiGianXem + 20) * 1000);
                }
            };
            script.AddNext(
                stopAcivity.AddNext(
                    startYoutube.AddNext(
                        skipAdv.AddNext(
                            skipAdv.AddNext(
                                wait
                                )
                            )
                        )
                    )
                );
            return script.RunScript();
        }
    }
}
