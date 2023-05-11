using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Code.Utils.Story
{
    internal class SwitchToYoutubeAccountByEmail: BaseScript
    {
        private readonly ADBUtils adb;
        private readonly string accountEmail;
        private readonly string youtube = "com.google.android.youtube";
        private bool isDone = false;

        private bool matchEmail(string email)
        {
            //accountEmail = accountEmail.Trim();

            return email.StartsWith(accountEmail)
                && ((email.Length == accountEmail.Length) 
                    || (email.Length > accountEmail.Length && email[accountEmail.Length] == '@'));
        }

        public SwitchToYoutubeAccountByEmail(ADBUtils adb, string accountEmail)
        {
            this.adb = adb;
            this.accountEmail = accountEmail;
        }

        protected override void Action()
        {
            var script = new BaseScriptComponent();
            var stopAcivity = new BaseScriptComponent()
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
            var startYoutube = new BaseScriptComponent()
            {
                action = () =>
                {
                    adb.startPackage(youtube);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(4000);
                }
            };
            var openMenu = WaitAndClick(matcher: (node) =>
            {
                return node.Attributes["resource-id"].InnerText == "com.google.android.youtube:id/menu_item_2";
            });
            var openAccount = WaitAndClick(matcher: (node) =>
            {
                return node.Attributes["resource-id"].InnerText == "com.google.android.youtube:id/account_container";
            });
            var takeAccount = ScrollAndChangeAccount();

            script.AddNext(
                stopAcivity.AddNext(
                    startYoutube.AddNext(
                        openMenu.AddNext(
                            openAccount.AddNext(
                                takeAccount)))));

            isDone = script.RunScript();
        }

        protected override bool IsCompleted()
        {
            return isDone;
        }

        private BaseScriptComponent WaitAndClick(Matcher matcher, int time = 10)
        {
            XmlNode node = null;
            DateTime startTime = DateTime.UtcNow;
            return new BaseScriptComponent(-1)
            {
                init = () =>
                {
                    Thread.Sleep(100);
                    startTime = DateTime.UtcNow;
                },
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, matcher);
                    node = needView.FirstOrDefault();
                    return node != null;
                },
                action = () =>
                {
                    var b = Bound.ofXMLNode(node);
                    var x = b.x + b.h / 2;
                    var y = b.y + b.w / 2;
                    adb.tap(x, y);
                },
                wait= () =>
                {
                    Thread.Sleep(500);
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    return t.TotalSeconds > time;
                },
                onCompleted = () =>
                {
                    Thread.Sleep(2000);
                }
            };
        }
        private BaseScriptComponent ScrollAndChangeAccount()
        {
            XmlNode node = null;
            int lastIndex = -2;
            int curIndex = -1;
            
            DateTime startTime = DateTime.UtcNow;
            Matcher matcher = (XmlNode n) =>
            {
                int ind = int.Parse(n.Attributes["index"].InnerText);
                bool isTrue = ind > 1;

                if (isTrue)
                {
                    var prev = n.PreviousSibling;
                    isTrue = matchEmail(prev.Attributes["text"].InnerText.Trim());
                }

                return isTrue;
            };

            Matcher accountList = (XmlNode n) =>
            {
                return n.Attributes["resource-id"].InnerText == "com.google.android.youtube:id/account_list";
            };

            return new BaseScriptComponent(-1)
            {
                init = () =>
                {
                    Thread.Sleep(3000);
                    startTime = DateTime.UtcNow;
                },
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    node = ViewUtils.findNode(screen, matcher).FirstOrDefault();
                    var n = ViewUtils.findNode(screen, accountList).FirstOrDefault();
                    if (n != null && node == null)
                    {
                        lastIndex = curIndex;
                        curIndex = int.Parse(
                            n.LastChild.Attributes["index"].InnerText
                            );
                    }
                    return node != null;
                },
                action = () =>
                {
                    var b = Bound.ofXMLNode(node);
                    var x = b.x + b.h / 2;
                    var y = b.y + b.w / 2;
                    adb.tap(x, y);
                },
                wait = () =>
                {
                    adb.swipe(500, 500, 500, 200);
                    Thread.Sleep(500);
                },
                isError = () =>
                {
                    return lastIndex == curIndex;
                },
                onCompleted = () =>
                {
                    Thread.Sleep(1000);
                }
            };
        }
    }
}
