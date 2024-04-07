using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemographicManagement
{
    public class County
    {
        public County(
            int Any,
            int Codi_comarca,
            string Comarca,
            int Població,
            int Domèstic_xarxa,
            int Activitats_econòmiques_i_fonts_pròpies,
            int Total,
            decimal Consum_domèstic_per_càpita
        )
        {
            this.Any = Any;
            this.Codi_comarca = Codi_comarca;
            this.Comarca = Comarca;
            this.Població = Població;
            this.Domèstic_xarxa = Domèstic_xarxa;
            this.Activitats_econòmiques_i_fonts_pròpies = Activitats_econòmiques_i_fonts_pròpies;
            this.Total = Total;
            this.Consum_domèstic_per_càpita = Consum_domèstic_per_càpita;
        }

        public int Any { get; set; }
        public int Codi_comarca { get; set; }
        public string Comarca { get; set; }
        public int Població { get; set; }
        public int Domèstic_xarxa { get; set; }
        public int Activitats_econòmiques_i_fonts_pròpies { get; set; }
        public int Total { get; set; }
        public decimal Consum_domèstic_per_càpita { get; set; }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Any: {this.Any}");
            sb.AppendLine($"Codi comarca: {this.Codi_comarca}");
            sb.AppendLine($"Comarca: {this.Comarca}");
            sb.AppendLine($"Codi Població: {this.Població}");
            sb.AppendLine($"Codi Domèstic xarxa: {this.Domèstic_xarxa}");
            sb.AppendLine($"Total: {this.Total}");
            sb.AppendLine($"Consum domèstic per càpita: {this.Consum_domèstic_per_càpita}");
            return sb.ToString();
        }
        public static List<County> BiggerThan(List<County> list, int population)
        {
            return list.Where(x => x.Població > population).ToList();
        }

        public static Dictionary<string, double> AvgConsumption(List<County> list)
        {
            var county = list.GroupBy(x => x.Comarca)
               .ToDictionary(
                   comarca => comarca.Key,
                   consumoPromedio =>
                       Math.Round(consumoPromedio.Average(consumo => consumo.Domèstic_xarxa), 2)
               );
            return county;
        }

        public static Dictionary<string, double> SortedAverage(List<County> list,bool ascending)
        {
            var result = list.GroupBy(x => x.Comarca)
                .OrderBy(x => Math.Round(x.Average(y => y.Domèstic_xarxa), 2)).Take(5)
                .ToDictionary(
                    comarca => comarca.Key,
                    consumoPromedio =>
                        Math.Round(consumoPromedio.Average(consumo => consumo.Domèstic_xarxa), 2)
                );

            if (!ascending)
                result =result.Reverse().ToDictionary();
            return result;
        }
        public static List<County> Filter(List<County> list,string name)
        {
            return list.Where(x => x.Comarca == name).OrderBy(x=>x.Any).ToList();
        }
        public static List<County> Filter(List<County> list, int id)
        {
            return list.Where(x => x.Codi_comarca == id).OrderBy(x => x.Any).ToList();
        }
        
    }
}
