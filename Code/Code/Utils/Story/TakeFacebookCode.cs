using AngleSharp.Dom;
using Code.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class TakeFacebookCode : TakeLatestEmail
    {
        private static readonly Regex facebookConfirmCode = new Regex("^[\\d]+ is your Facebook confirmation code$");
        private readonly DateTime now;

        public TakeFacebookCode(string deviceId, NodeHolder holder) : base(deviceId, holder: holder)
        {
            this.matcher = MatchFacebookVerifyMail;
            now = DateTime.Now.AddMinutes(-1);
        }

        public static string GetCode(XmlNode node)
        {
            var text = node.ChildNodes[3].Attributes["text"].InnerText;
            return text.Split(' ')[0];
        }

        private bool MatchFacebookVerifyMail(XmlNode node)
        {
            var isTrue = node.HasChildNodes && node.ChildNodes.Count == 6;

            if (isTrue)
            {
                isTrue = node.ChildNodes[1].Attributes["text"].InnerText == "Facebook";
            }

            string text = "";

            if (isTrue)
            {
                text = node.ChildNodes[2].Attributes["text"].InnerText;
                isTrue = recentDate.IsMatch(text);
            }

            if (isTrue)
            {
                var time = DateTime.ParseExact(text, recentDateFormat, CultureInfo.CurrentCulture);
                isTrue = time >= now;
            }

            if (isTrue)
            {
                text = node.ChildNodes[3].Attributes["text"].InnerText;
                isTrue = facebookConfirmCode.IsMatch(text);
            }

            return isTrue;
        }

    }
}
