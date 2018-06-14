using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _05_Folders
{
    public class Folders
    {
        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            XDocument xmlDoc = XDocument.Parse(xml);
            var val = xmlDoc.Descendants("folder").ToList();
            var result = val.Where(p => p.FirstAttribute.Value.StartsWith(startingLetter.ToString()))
                .Select(p => p.FirstAttribute.Value);
            return result;
        }

        public static void Main(string[] args)
        {
            string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"uninstall information\" />" +
                    "</folder>" +
                "<folder name=\"users\" />" +
                "</folder>";

            foreach (string name in Folders.FolderNames(xml, 'u'))
                Console.WriteLine(name);
        }
    }
}