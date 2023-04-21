using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Code.Utils
{
    public delegate bool Matcher(XmlNode node);
    public class ViewUtils
    {
        public static List<XmlNode> findNode(string str, Matcher matcher)
        {
            var result = new List<XmlNode>();
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(str);
                var root = doc.DocumentElement.FirstChild;
                var stack = new Stack<XmlNode>();
                stack.Push(root);
                while (stack.Count != 0)
                {
                    var e = stack.Pop();
                    if (matcher.Invoke(e))
                    {
                        result.Add(e);
                    }
                    foreach (XmlNode node in e.ChildNodes)
                    {
                        stack.Push((XmlNode)node);
                    }
                }
            }
            catch(Exception ex)
            {
                result.Clear();
            }

            return result;
        }
    }
    public class Bound
    {
        public int x;
        public int y;
        public int w;
        public int h;

        public Bound(int x = 0, int y = 0, int w = 0, int h = 0)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public static Bound ofXMLNode(XmlNode node)
        {
            var b = new Bound();
            var bound = node.Attributes["bounds"].InnerText;

            int i = 1;
            b.x = 0;
            while (bound[i] != ',')
            {
                b.x *= 10;
                b.x += bound[i++] - '0';
            }
            ++i;
            b.y = 0;
            while (bound[i] != ']')
            {
                b.y *= 10;
                b.y += bound[i++] - '0';
            }
            i += 2;
            b.h = 0;
            while (bound[i] != ',')
            {
                b.h *= 10;
                b.h += bound[i++] - '0';
            }
            b.h -= b.x;
            ++i;
            b.w = 0;
            while (bound[i] != ']')
            {
                b.w *= 10;
                b.w += bound[i++] - '0';
            }
            b.w -= b.y;

            return b;
        }
    }
}
