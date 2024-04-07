using DocumentFormat.OpenXml.Spreadsheet;

namespace DemographicManagement
{
    class Program
    {
        static void Main()
        {
            CountyXml.Create(Csv.Read());
            List<County> list = Csv.Read();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(Const.Menu);

                Console.Write(Const.Select);

                string input = Console.ReadLine();

                Console.Clear();

                bool correct = false;
                dynamic result = "";
                string path = "";
                switch (input)
                {
                    case "1":
                        Console.WriteLine(Const.MinHab);
                        if (int.TryParse(Console.ReadLine(), out int population))
                        {
                            Console.WriteLine(Const.InputMinhab,population);
                            result = County.BiggerThan(list, population);
                            foreach (var item in result)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            correct = true;
                            path = Const.PathA;

                            goto default;
                        }
                        Console.WriteLine(Const.Error);
                        Console.ReadKey();

                        break;
                    case "2":
                        Console.WriteLine(Const.AverageConsumption);
                        result = County.AvgConsumption(list);
                        foreach (var item in result)
                            Console.WriteLine(Const.DictionariOutPut,item.Key,item.Value);
                        Console.WriteLine();
                        correct = true;
                        path = Const.PathB;

                        goto default;
                    case "3":
                        Console.WriteLine(Const.MostConsumption);
                        result = County.SortedAverage(list, false);
                        foreach (var item in result)
                            Console.WriteLine(Const.DictionariOutPut, item.Key, item.Value);

                        Console.WriteLine();

                        correct = true;
                        path = Const.PathC;


                        goto default;
                    case "4":
                        Console.WriteLine(Const.LessConsumption);
                        result = County.SortedAverage(list, false);
                        foreach (var item in result)
                            Console.WriteLine(Const.DictionariOutPut, item.Key, item.Value);

                        Console.WriteLine();

                        correct = true;
                        path = Const.PathD;


                        goto default;

                    case "5":
                        Console.WriteLine(Const.CodeName);
                        input = Console.ReadLine() ?? "";
                        if (int.TryParse(input, out int codi))
                        {
                            result = County.Filter(list, codi);
                            path = Const.PathE;

                        }
                        else
                        {
                            result = County.Filter(list, input);
                            path = Const.PathF;

                        }
                        foreach (var item in result)
                            Console.WriteLine(item.ToString());

                        if (result.Count == 0)
                        {
                            Console.WriteLine(Const.NotFound);
                            Console.WriteLine(Const.Continue);
                            Console.ReadKey();
                            break;
                        }
                        correct = true;
                        goto default;
                    case "0":
                        Console.WriteLine(Const.Exit);
                        exit = true;
                        break;
                    default:
                        if (correct)
                        {
                            Console.WriteLine(Const.Save);
                            Console.WriteLine(Const.AnyElse);
                            if (Console.ReadLine() == "1")
                            {
                                CountyXml.Create(result, path);
                                Console.WriteLine(Const.Continue);
                                Console.ReadKey();
                            }

                        }
                        else
                        {
                            Console.WriteLine(Const.NotValid);
                            Console.WriteLine(Const.Continue);
                            Console.ReadKey();

                        }
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
