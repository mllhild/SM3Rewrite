using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SM3Rewrite
{
    public class EventParser
    {

        public string xmlText;
        public List<string> dialogTextBlocks;

        public void Parser(string xml) {
            XDocument doc = XDocument.Parse(xml);

            XElement root = doc.Element("FirstNode");

            foreach (XElement element in root.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "ClearImages":
                        HandleClearImages();
                        break;

                    case "AddImage":
                        HandleAddImage(element);
                        break;

                    case "SetText":
                        HandleSetText(element);
                        break;

                    case "AddText":
                        HandleAddText(element);
                        break;
                }
            }
        }
        public void HandleClearImages()
        {
            Console.WriteLine("Clearing images");
        }

        public void HandleAddImage(XElement element)
        {
            string id = (string)element.Attribute("imageID");
            int x = (int)element.Attribute("x");
            int y = (int)element.Attribute("y");
            int layer = (int)element.Attribute("layer");
            int rotation = (int)element.Attribute("rotation");

            Console.WriteLine($"AddImage: {id}, ({x},{y}), layer={layer}, rot={rotation}");
        }

        public void HandleSetText(XElement element)
        {
            foreach (var node in element.Nodes())
            {
                if (node is XText text)
                {
                    Console.Write(text.Value);
                }
                else if (node is XElement child && child.Name == "if")
                {
                    ProcessIf(child);
                }
            }

            Console.WriteLine();
        }

        public void ProcessIf(XElement ifElement)
        {
            string condition = (string)ifElement.Attribute("friendsCount");

            bool conditionMet = EvaluateCondition(condition);

            if (conditionMet)
            {
                // first text node inside <if>
                Console.Write(ifElement.Nodes().OfType<XText>().FirstOrDefault()?.Value);
            }
            else
            {
                XElement elseNode = ifElement.Element("else");
                if (elseNode != null)
                {
                    Console.Write(elseNode.Value);
                }
            }
        }

        public bool EvaluateCondition(string condition)
        {
            // Example: "2+"
            int friendsCount = 3; // your runtime value

            if (condition.EndsWith("+"))
            {
                int min = int.Parse(condition.TrimEnd('+'));
                return friendsCount >= min;
            }

            return false;
        }

        public void HandleAddText(XElement element)
        {
            Console.WriteLine("AddText: " + element.Value);
        }
    }


    // look at https://chatgpt.com/c/69e7689c-f60c-83eb-952e-f6f3021699f8
    public class EventParserV2 { }

    // look at https://gemini.google.com/app/2c3bd9fd4b7f211c
    public class EventParserV3 { }
    public static class ConditionParser
    {
        // var1 > 2
        // var1 > var2
        // var1 > var2 + var3

    }
}
