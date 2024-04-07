using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemographicManagement
{
    public class CountyXml
    {
        const string Path = "Comarcas.xml";

        public static void Create(List<County> county,string path=Path)
        {
            XDocument newXml = new XDocument(
                    new XElement(
                        "Comarcas",
                        from comarca in county
                        select new XElement(
                            new XElement(
                                "CComarca",
                                new XElement("Any", comarca.Any),
                                new XElement("Codi_comarca", comarca.Codi_comarca),
                                new XElement("Comarca", comarca.Comarca),
                                new XElement("Població", comarca.Població),
                                new XElement("Domèstic_xarxa", comarca.Domèstic_xarxa),
                                new XElement(
                                    "Activitats_econòmiques_i_fonts_pròpies",
                                    comarca.Activitats_econòmiques_i_fonts_pròpies
                                ),
                                new XElement("Total", comarca.Total),
                                new XElement(
                                    "Consum_domèstic_per_càpita",
                                    comarca.Consum_domèstic_per_càpita
                                )
                            )
                        )
                    )
                );
            using (StreamWriter sw = new StreamWriter(Path))
            {
                
            }
            newXml.Save(path);

            Console.WriteLine("Xml creado");
        }
        public static void Create(Dictionary<string,double> county,string path)
        {
            XDocument newXml = new XDocument(
                    new XElement(
                        "Comarcas",
                        from comarca in county
                        select new XElement(
                            new XElement(
                                "CComarca",
                                new XElement("Comarca", comarca.Key),
                                new XElement(
                                    "Quantitat",
                                    comarca.Value
                                )
                            )
                        )
                    )
                );
            using (StreamWriter sw = new StreamWriter(Path))
            {

            }
            newXml.Save(path);

            Console.WriteLine("Xml creado");
        }

    }
}
