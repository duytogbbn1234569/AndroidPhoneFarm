using Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Code.Utils.Story
{
    public class CreateGoogleAccountScript
    {
        private readonly string setting = "com.android.settings";
        private readonly string createAccount = "com.google.android.gms";
        private readonly TaiKhoanGoogle account;
        private readonly Stack<String> stack = new Stack<String>();
        private readonly ADBUtils adb;

        public CreateGoogleAccountScript(string deviceId, TaiKhoanGoogle account)
        {
            this.account = account;
            this.account.IDThietBi = deviceId;
            this.adb = new ADBUtils(deviceId);
        }

        public void Run()
        {
            var script = new BaseScript();
            var stopAcivity = new BaseScript()
            {
                action = () =>
                {
                    adb.stopPackage(createAccount);
                    adb.stopPackage(setting);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(2000);
                }
            };
            var startSetting = new BaseScript()
            {
                action = () =>
                {
                    this.adb.startPackage(setting);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(2000);
                }
            };

            var clickAccountSettings = scrollAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Accounts & sync";
            }, 4);

            var clickAddAccount = scrollAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Add account";
            }, 4);
            
            var clickAddGooleAccount = scrollAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Google";
            }, 4);

            var waitAndChooseCreateAccount = waitAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Create account";
            }, 10);

            var waitAndChooseCreateAccountForMyself = waitAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "For myself";
            }, 10);

            var importNameAndChooseNext = importNameAndClick();
            var importInforAndChooseNext = importInforAndClick();
            var importUserNameAndChooseNext = importUserNameAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Create your own Gmail address";
            });
            var importPasswordAndChooseNext = importPasswordAndClick();
            var clickSkip = scrollAndClick ((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Skip";
            }
            , 2);
            var clickNext = waitAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Next";
            }, 10);
            var clickAgree = scrollAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "I agree";
            },2);
            script.AddNext(
                stopAcivity.AddNext(
                    startSetting.AddNext(
                        clickAccountSettings.AddNext(
                            clickAddAccount.AddNext(
                                clickAddGooleAccount.AddNext(
                                    waitAndChooseCreateAccount.AddNext(
                                        waitAndChooseCreateAccountForMyself.AddNext(
                                            importNameAndChooseNext.AddNext(
                                                importInforAndChooseNext.AddNext(
                                                    importUserNameAndChooseNext.AddNext(
                                                        importPasswordAndChooseNext.AddNext(
                                                            clickSkip.AddNext(
                                                                clickNext.AddNext(
                                                                    clickAgree
                                                                    )
                                                                )
                                                            )
                                                        )
                                                    )
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    )
                );
            if (script.RunScript())
            {
                Console.WriteLine("Thành công");
            }
            else
            {
                Console.WriteLine("Thất bại");
            }
        }
        private BaseScript importPasswordAndClick()
        {
            DateTime startTime = DateTime.UtcNow;
            return new BaseScript(-1)
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                },
                wait = () =>
                {
                    Thread.Sleep(1000);
                },
                action = () =>
                {
                    adb.typeText(account.MatKhau.ToString());
                    Thread.Sleep(500);
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.enterEvent();
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    Console.WriteLine(t.TotalSeconds);
                    return t.TotalSeconds > 10;
                }
            };
        }
        private BaseScript importUserNameAndClick(Matcher matcher)
        {
            DateTime startTime = DateTime.UtcNow;
            XmlNode node= null;
            return new BaseScript(-1)
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                },
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, matcher);
                    node = needView.FirstOrDefault();
                    return true;
                },
                wait = () =>
                {
                    Thread.Sleep(1000);
                },
                action = () =>
                {
                    if (node != null)
                    {
                        var b = Bound.ofXMLNode(node);
                        var x = b.x + b.h / 2;
                        var y = b.y + b.w / 2;
                        adb.tap(x, y);
                        Thread.Sleep(500);
                        adb.tabEvent();
                    }
                    adb.typeText(account.TenDangNhap.ToString());
                    Thread.Sleep(1500);
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.enterEvent();
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    Console.WriteLine(t.TotalSeconds);
                    return t.TotalSeconds > 10;
                }
            };
        }
        private BaseScript importInforAndClick()
        {
            DateTime startTime = DateTime.UtcNow;
            return new BaseScript(-1)
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                },
                wait = () =>
                {
                    Thread.Sleep(1000);
                },
                action = () =>
                {
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.enterEvent();
                    int tabNum = account.ThangSinh;
                    for (int i = 0; i < tabNum; i++)
                    {
                        adb.tabEvent();
                        Thread.Sleep(200);
                    }
                    adb.enterEvent();
                    Thread.Sleep(500);
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.typeText(account.NgaySinh.ToString());
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.typeText(account.NamSinh.ToString());
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.enterEvent();
                    Thread.Sleep(500);
                    tabNum = account.GioiTinh;
                    for (int i = 0; i < tabNum; i++)
                    {
                        adb.tabEvent();
                        Thread.Sleep(500);
                    }
                    adb.enterEvent();
                    Thread.Sleep(500);
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.enterEvent();
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    Console.WriteLine(t.TotalSeconds);
                    return t.TotalSeconds > 10;
                }
            };
        }
        private BaseScript importNameAndClick()
        {
            DateTime startTime = DateTime.UtcNow;
            return new BaseScript(-1)
            {
               
                init = () =>
                {
                    Thread.Sleep(2000);
                },
                wait = () =>
                {
                    Thread.Sleep(2000);
                },
                action = () =>
                {
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.typeText(account.Ho.ToString());
                    Thread.Sleep(500);
                    adb.tabEvent();
                    Thread.Sleep(500);
                    adb.typeText(account.Ten.ToString());
                    Thread.Sleep(500);
                    adb.enterEvent();
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    Console.WriteLine(t.TotalSeconds);
                    return t.TotalSeconds > 10;
                }
            };
        }

        private BaseScript scrollAndClick(Matcher matcher, int maxTry)
        {
            XmlNode node = null;
            return new BaseScript(maxTry)
            {
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, matcher);
                    node = needView.FirstOrDefault();
                    return needView.Count != 0;
                },
                wait = () =>
                {
                    this.adb.swipe(100, 800, 100, 100);
                },
                action = () =>
                {
                    var b = Bound.ofXMLNode(node);
                    var x = b.x + b.h / 2;
                    var y = b.y + b.w / 2;
                    adb.tap(x, y);
                },
            };
        }

        private BaseScript waitAndClick(Matcher matcher, double maxWait, int clickNumber = 1)
        {
            DateTime startTime = DateTime.UtcNow;
            XmlNode node = null;
            return new BaseScript(-1)
            {
                init = () =>
                {
                    Thread.Sleep(1000);
                    startTime = DateTime.UtcNow;
                },
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, matcher);
                    node = needView.FirstOrDefault();
                    return needView.Count != 0;
                },
                wait = () =>
                {
                    Thread.Sleep(200);
                },
                action = () =>
                {
                    var b = Bound.ofXMLNode(node);
                    var x = b.x + b.h / 2;
                    var y = b.y + b.w / 2;
                    while (clickNumber-- != 0)
                    {
                        adb.tap(x, y);
                        Thread.Sleep(200);
                    }
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    Console.WriteLine(t.TotalSeconds);
                    return t.TotalSeconds > maxWait;
                }
            };
        }
    }
}
