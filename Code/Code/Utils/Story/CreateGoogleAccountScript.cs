using Code.Models;
using Code.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    public class CreateGoogleAccountScript: BaseScript
    {
        private readonly string setting = "com.android.settings";
        private readonly string createAccount = "com.google.android.gms";
        private readonly TaiKhoanGoogle account;
        private readonly ADBUtils adb;

        public CreateGoogleAccountScript(string deviceId, TaiKhoanGoogle account):base()
        {
            this.account = account;
            this.account.IDThietBi = deviceId;
            this.adb = new ADBUtils(deviceId);
        }

        protected override void OnCompleted()
        {
            account.TrangThai = AccountStatus.CREATED;
            DataProvider.Ins.db.TaiKhoanGoogles.AddOrUpdate(this.account);
            DataProvider.Ins.db.SaveChanges();
        }

        protected override void Init()
        {
            account.TrangThai = AccountStatus.CREATING;
            DataProvider.Ins.db.TaiKhoanGoogles.AddOrUpdate(this.account);
            DataProvider.Ins.db.SaveChanges();
        }

        protected override void OnFailed()
        {
            account.TrangThai = AccountStatus.FAILED;
            DataProvider.Ins.db.TaiKhoanGoogles.AddOrUpdate(this.account);
            DataProvider.Ins.db.SaveChanges();
        }

        protected override bool IsCompleted()
        {
            var script = new BaseScriptComponent();
            var stopAcivity = new BaseScriptComponent()
            {
                action = () =>
                {
                    adb.stopPackage(createAccount);
                    adb.stopPackage(setting);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(500);
                }
            };
            var startSetting = new BaseScriptComponent()
            {
                action = () =>
                {
                    this.adb.startPackage(setting);
                },
                onCompleted = () =>
                {
                    Thread.Sleep(500);
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
            var clickPhoneNumber = clickSkipOrException();
            var scrollClickSkip = scrollNotWaitAndClick(new Matcher((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Skip";
            }));
          
            var clickNext = waitAndClick((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "Next";
            }, 10);
            var clickAgree = scrollNotWaitAndClick(new Matcher((XmlNode n) =>
            {
                return n.Attributes["text"].InnerText == "I agree";
            }));
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
                                                            clickPhoneNumber.AddNext(
                                                                scrollClickSkip.AddNext(
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
                    )
                );

            return script.RunScript();
        }
        private BaseScriptComponent scrollNotWaitAndClick(Matcher matcher)
        {
            XmlNode node = null;
            DateTime startTime = DateTime.UtcNow;
            return new BaseScriptComponent(-1)
            {
                init = () =>
                {
                    Thread.Sleep(1000);
                    startTime = DateTime.UtcNow;
                },
                canAction = () =>
                {
                    this.adb.swipe(100, 1400, 100, 100);
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, matcher);
                    node = needView.FirstOrDefault();
                    return node != null;
                },
                action = () =>
                {
                    if (node != null)
                    {
                        var b = Bound.ofXMLNode(node);
                        var x = b.x + b.h / 2;
                        var y = b.y + b.w / 2;
                        adb.tap(x, y);
                    }
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    return t.TotalSeconds > 30;
                }
            };
        }

        private BaseScriptComponent clickSkipOrException()
        {
            DateTime startTime = DateTime.UtcNow;
            XmlNode node = null;
            return new BaseScriptComponent(-1)
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                    startTime = DateTime.UtcNow;
                },
                wait = () =>
                {
                    Thread.Sleep(1000);
                },
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                    {
                        return n.Attributes["text"].InnerText == "Next";
                    }));
                    node = needView.FirstOrDefault();
                    return node != null;
                }
                ,
                action = () =>
                {
                    var b = Bound.ofXMLNode(node);
                    var x = b.x + b.h / 2;
                    var y = b.y + b.w / 2;
                    adb.tap(x, y);
                    Thread.Sleep(5000);
                },
                isError = () =>
                {
                    var t = System.DateTime.UtcNow - startTime;
                    Console.WriteLine(t.TotalSeconds);
                    return t.TotalSeconds > 30;
                }
            };
        }

        private BaseScriptComponent importPasswordAndClick()
        {
            DateTime startTime = DateTime.UtcNow;
            return new BaseScriptComponent(-1)
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                    startTime = DateTime.UtcNow;
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
        private BaseScriptComponent importUserNameAndClick(Matcher matcher)
        {
            DateTime startTime = DateTime.UtcNow;
            XmlNode node= null;
            return new BaseScriptComponent(-1)
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                    startTime = DateTime.UtcNow;
                },
                canAction = () =>
                {
                    var screen = this.adb.getCurrentView();
                    var needView = ViewUtils.findNode(screen, matcher);
                    node = needView.FirstOrDefault();
                    if (needView.Count() <= 0)
                    {
                        needView = ViewUtils.findNode(screen, new Matcher((XmlNode n) =>
                        {
                            return n.Attributes["text"].InnerText.Contains("How you");
                        }));
                    }
                    return needView.Count() != 0;
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
                        var x = 50;
                        var y = b.y + b.w / 2;
                        adb.tap(x, y);
                        Thread.Sleep(1000);
                    }
                    adb.typeText(account.TenDangNhap.ToString());
                    Thread.Sleep(1000);
                    adb.tabEvent();
                    Thread.Sleep(1000);
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
        private BaseScriptComponent importInforAndClick()
        {
            DateTime startTime = DateTime.UtcNow;
            return new BaseScriptComponent(-1)
            {
                init = () =>
                {
                    Thread.Sleep(2000);
                    startTime = DateTime.UtcNow;
                },
                wait = () =>
                {
                    Thread.Sleep(1000);
                },
                action = () =>
                {
                    adb.tabEvent();
                    Thread.Sleep(1000);
                    adb.enterEvent();
                    int tabNum = account.ThangSinh;
                    for (int i = 1; i < tabNum; i++)
                    {
                        adb.tabEvent();
                        Thread.Sleep(200);
                    }
                    adb.enterEvent();
                    Thread.Sleep(1000);
                    adb.tabEvent();
                    Thread.Sleep(1000);
                    adb.typeText(account.NgaySinh.ToString());
                    adb.tabEvent();
                    Thread.Sleep(1000);
                    adb.typeText(account.NamSinh.ToString());
                    adb.tabEvent();
                    Thread.Sleep(1000);
                    adb.enterEvent();
                    Thread.Sleep(1000);
                    tabNum = account.GioiTinh;
                    for (int i = 0; i < tabNum; i++)
                    {
                        adb.tabEvent();
                        Thread.Sleep(500);
                    }
                    adb.enterEvent();
                    Thread.Sleep(1000);
                    adb.tabEvent();
                    Thread.Sleep(1000);
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
        private BaseScriptComponent importNameAndClick()
        {
            DateTime startTime = DateTime.UtcNow;
            return new BaseScriptComponent(-1)
            {
               
                init = () =>
                {
                    Thread.Sleep(2000);
                    startTime = DateTime.UtcNow;
                },
                wait = () =>
                {
                    Thread.Sleep(2000);
                },
                action = () =>
                {
                    adb.tabEvent();
                    Thread.Sleep(1000);
                    adb.typeText(account.Ho.ToString());
                    Thread.Sleep(1000);
                    adb.tabEvent();
                    Thread.Sleep(1000);
                    adb.typeText(account.Ten.ToString());
                    Thread.Sleep(1000);
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

        private BaseScriptComponent scrollAndClick(Matcher matcher, int maxTry)
        {
            XmlNode node = null;
            return new BaseScriptComponent(maxTry)
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
                    this.adb.swipe(100, 1000, 100, 100);
                    maxTry--;
                },
                action = () =>
                {
                    var b = Bound.ofXMLNode(node);
                    var x = b.x + b.h/ 2;
                    var y = b.y + b.w / 2;
                    adb.tap(x, y);
                },
                isError = () =>
                {
                    return maxTry <= 0;
                }
            };
        }

        private BaseScriptComponent waitAndClick(Matcher matcher, double maxWait, int clickNumber = 1)
        {
            DateTime startTime = DateTime.UtcNow;
            XmlNode node = null;
            return new BaseScriptComponent(-1)
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
