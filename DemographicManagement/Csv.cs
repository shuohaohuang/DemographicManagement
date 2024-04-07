using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace DemographicManagement
{
    public static class Csv
    {
        public static List<County> Read()
        {
            using var reader = new StreamReader(
                "Consum_d_aigua_a_Catalunya_per_comarques_20240402.csv"
            );
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<County>();

            return records.ToList();
        }
    }
}
