using AngleSharp.Dom;
using Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;

namespace Code.Utils.Story
{
    public delegate void OnMail(XmlNode node);
    public class NodeHolder
    {
        public XmlNode node;
    }


    public class TakeLatestEmail : BaseScript
    {
        protected readonly string gmail = "com.google.android.gm";

        protected static readonly Regex recentDate = new Regex("^[\\d]{1,2}:[\\d]{1,2} [ap]m$");
        protected static readonly string recentDateFormat = "h:m tt";
        protected static readonly string pastDateFormat = "MMM d";

        protected readonly ADBUtils adb;
        protected Matcher matcher;
        protected readonly NodeHolder holder;

        public TakeLatestEmail(string deviceId, NodeHolder holder = null, Matcher matcher = null) : base()
        {
            this.matcher = matcher;
            this.holder = holder;
            this.adb = new ADBUtils(deviceId);
        }
        protected override bool IsCompleted()
        {
            return holder.node != null;
        }
        protected override void Init()
        {
            var stopGmail = new BaseScriptComponent()
            {
                action = () =>
                {
                    adb.stopPackage(gmail);
                    Console.WriteLine("stop Gmail");
                },
                onCompleted = () =>
                {
                    Thread.Sleep(500);
                }
            };
            var startGmail = new BaseScriptComponent()
            {
                action = () =>
                {
                    this.adb.startPackage(gmail);
                    Console.WriteLine("start Gmail");
                },
                onCompleted = () =>
                {
                    Thread.Sleep(5000);
                }
            };
            var clickMenu = new BaseScriptComponent()
            {
                action = () =>
                {
                    this.adb.tap(50, 100);
                    Console.WriteLine("click Menu Gmail");
                },
                onCompleted = () =>
                {
                    Thread.Sleep(1000);
                }
            };
            var showAllMail = new BaseScriptComponent()
            {
                action = () =>
                {
                    this.adb.tap(200, 200);
                    Console.WriteLine("click show all Gmail");
                },
                onCompleted = () =>
                {
                    Thread.Sleep(1000);
                }
            };

            XmlNode node = null;

            var takeMail = new BaseScriptComponent(10)
            {
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, matcher);
                    node = needView.FirstOrDefault();
                    return needView.Count != 0;
                },
                onCompleted = () =>
                {
                    this.holder.node = node;
                    Thread.Sleep(500);
                },
                wait = () =>
                {
                    this.adb.swipe(200, 200, 200, 800);
                    Thread.Sleep(2000);
                },
            };

            this.AddNext(
                stopGmail.AddNext(
                    startGmail.AddNext(
                        clickMenu.AddNext(
                            showAllMail.AddNext(
                                takeMail)
                            )
                        )
                    )
                );
        }
    }
}
