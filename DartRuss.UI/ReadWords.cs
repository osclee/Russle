using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DartRuss.UI
{
    public static class ReadWords
    {
        public static string[] ReadRussian()
        {
            var xml = XDocument.Load(@"words.xml");


            // Query the data and write out a subset of contacts
            // return xml.Descendants("word")
            //                .Select(element => (string)element.Attribute("russian")).ToArray();
            var query = from c in xml.Root.Descendants("word")
                        select c.Element("russian").Value;
            return query.ToArray();
        }
        public static string[] ReadEnglish()
        {
            var xml = XDocument.Load(@"words.xml");


            // Query the data and write out a subset of contacts
            // return xml.Descendants("word")
            //                .Select(element => (string)element.Attribute("russian")).ToArray();
            var query = from c in xml.Root.Descendants("word")
                        select c.Element("english").Value;
            return query.ToArray();
        }
    }
}
