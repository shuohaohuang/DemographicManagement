using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemographicManagement
{
    public class Const
    {
        public const string Menu =
                "Menú:\n"
                + "1. Comarques amb més de x habitants\n"
                + "2. Calcular el consum domèstic mitjà per comarca\n"
                + "3. Mostrar les comarques amb el consum domèstic per càpita més alt 3\n"
                + "4. Mostrar les comarques amb el consum domèstic per càpita més baix 4\n"
                + "5. Filtrar les comarques per nom o codi 5\n"
                + "0. Sortir\n",
            Select = "Seleccioneu una opció: ",
            MinHab = "introdueix el minim d'habitants",
            InputMinhab = "Comarques amb més de {0} habitants:",
            Error = "error, tornat al menu",
            AverageConsumption = "Consum domèstic mitjà per comarca:",
            DictionariOutPut = "{0}: {1}",
            MostConsumption = "Comarques amb el consum domèstic per càpita més alt",
            LessConsumption = "Comarques amb el consum domèstic per càpita més Baix",
            CodeName = "Introdueix un codi o nom de comarca",
            NotFound = "Comarac no trobada",
            Continue = "Pulsa per continuar",
            Exit = "Sortint del programa...",
            Save = "1. Guardar",
            AnyElse = "Qualsevol altre per descartar",
            NotValid = "Opció no vàlida. Torneu-ho a provar.",
            PathA = "FiltrePerHabitant.xml",
            PathB = "ConsumDomecticMitja.xml",
            PathC = "MesConsumPerCapita.xml",
            PathD = "MenysConsumPerCapita.xml",
            PathE = "FiltratPerCodi.xml",
            PathF = "FiltratPerNom.xml";
    }
}
