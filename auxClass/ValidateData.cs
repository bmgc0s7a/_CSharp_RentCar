using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico.auxClass
{
    class ValidateData
    {
        // Join all value the array of strings in string
        public static string showContent(string[] values, int pos, string op = "|")
        {
            string text = "";
            for(int i = 0; i < pos; i++)
            {
                text += i != pos - 1 ? values[i] + ";" : values[i];
            }
            return text;
        }

        // Return array values diferent the posf
        public static string[] showContentReturnArray(string[] values, int pos, string posf = "")
        {
            string[] newArray = new string[values.Length-1];
            int count = newArray.Length;
            for (int i = 0; i < pos; i++)
            {
                if (values[i] != posf)
                {
                    newArray[newArray.Length - count] = values[i];
                    count--;
                }
            }
            return newArray;

        }

        // Join all value the array of int in string
        public static string showContent(int[] values, int pos, string  op = "|")
        {
            string text = "";
            for (int i = 0; i < pos; i++)
            {
                text += i != pos - 1 ? values[i].ToString() + op : values[i].ToString();
            }
            return text;
        }

        // Print data in the list veiculos, header and content
        public static void showAllCOntent(List<Veiculo> values, int ipos = 0, int fpos = 0, bool printType = false)
        {
            values = verif(values);
            List<String> typeVeiculo = new List<string>(); 
            values.ForEach(
                delegate (Veiculo item)
                {
                    if (item.State != Veiculo.StatePossible[0] && !valData(item.GetType().Name, typeVeiculo.ToArray()))
                    {
                        typeVeiculo.Add(item.GetType().Name);
                    }
                });
            for (int i = ipos; i < fpos; i++)
            {
                bool FlagsAttribute = false;
                if (i > 0 && values[i].GetType() != values[i - 1].GetType() && printType || i == 0 && printType)
                {
                    Table.dataLine($"\n\n -> {values[i].GetType().Name}\n", redColor:true);
                    FlagsAttribute = true;
                }
                // Cabecalho
                string[] dados = values[i].ToString().Split(';');
                
                for (int j = 0; j < dados.Length; j++) {
                    string[] cabec = dados[j].ToString().Split(':');
                    if (FlagsAttribute)
                    {
                        if (j == 0) Table.td("ID", 10, true);
                        if (j == 6 && valData(values[i].GetType().Name, typeVeiculo.ToArray())) 
                            Table.td("Data", 20, true);
                        if (cabec[0].Contains("Data")) continue;
                        Table.td(cabec[0], (cabec[0].Length < 20) ? 20 : cabec[0].Length * 2, true);
                        if (j == dados.Length - 1) Console.WriteLine("\n");

                    }
                    
                }
                Table.tr();
                // Dados
                for (int j = 0; j < dados.Length; j++)
                {
                    string[] cabec = dados[j].ToString().Split(':');
                    if (j == 0) Table.td((i+1).ToString(), 10);
                    if (j == 6 && valData(values[i].GetType().Name.ToString(), typeVeiculo.ToArray())) 
                        if(!values[i].ToString().Contains("Data"))
                            Table.td("-", 20);
                    Table.td(cabec[1], (cabec[0].Length < 20) ? 20 : cabec[0].Length * 2);
                }
            }
            Table.tr();
            Table.tr();
        }

        // Verify date state is out and correct state and data
        public static List<Veiculo> verif(List<Veiculo> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if(values[i].State != Veiculo.StatePossible[0] && values[i].DataState < Program.dateProgram && values[i].DataState != null)
                {
                    values[i].DataState = null;
                    values[i].State = Veiculo.StatePossible[0];
                }
            }
            return values;
        }

        // Return list of var type
        public static List<Veiculo> newListState(List<Veiculo> values, string state, Type var)
        {
            values = verif(values);
            List<Veiculo> newList = new List<Veiculo>();
            for(int i = 0; i < values.Count; i++)
            {
                if(lowerWithoutSpecialString(values[i].State) == lowerWithoutSpecialString(state) && values[i].GetType() == var)
                {
                    newList.Add(values[i]);
                }
            }
            if (newList.Count == 0) Message.Error($"Não existe nenhum {var.Name} {state}!", true, false);
            return newList;
        }

        // Return list of state and display message error or not
        public static List<Veiculo> newListState(List<Veiculo> values, string state, bool mes = true)
        {
            values = verif(values);
            List<Veiculo> newList = new List<Veiculo>();
            for (int i = 0; i < values.Count; i++)
            {
                if (lowerWithoutSpecialString(values[i].State) == lowerWithoutSpecialString(state))
                {
                    newList.Add(values[i]);
                }
            }
            if (mes && newList.Count == 0) Message.Error($"Não existe nenhum veiculo em {state}!", true, false);
            return newList;
        }

        // Generate new list of id auto
        public static List<int> newListId(List<Veiculo> values, string state)
        {
            values = verif(values);
            List<int> newList = new List<int>();
            for (int i = 0; i < values.Count; i++)
            {
                if (lowerWithoutSpecialString(values[i].State) == lowerWithoutSpecialString(state))
                {
                    newList.Add(i);
                }
            }
            return newList;
        }

        // Replace the special caracter normal caracter
        private static string lowerWithoutSpecialString(string value)
        {
            string[] specialCaract = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] withoutSpecialCaract = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < specialCaract.Length; i++)
            {
                value = value.Replace(specialCaract[i], withoutSpecialCaract[i]);
            }
            return value.ToLower();
        }

        // Verify the int value high 0 or higher min and lower max
        public static bool valData(int value, int min=1, int max=1)
        {
            if (min == max && value > min) 
                return true;
            else if (value >= min && value <= max)
                return true;
            return false;
        }

        // Verify the int value in array
        public static bool valData(int value, int[] arrayValue)
        {
            for(int i = 0; i < arrayValue.Length; i++)
            {
                if (value == arrayValue[i]) return true;
            }
            return false;
        }

        // Verify the double value in array
        public static bool valData(double value, double[] arrayValue)
        {
            for (int i = 0; i < arrayValue.Length; i++)
            {
                if (value == arrayValue[i]) return true;
            }
            return false;
        }

        // Verify the double value in array int
        public static bool valData(double value, int[] arrayValue)
        {
            for (int i = 0; i < arrayValue.Length; i++)
            {
                if (value == arrayValue[i]) return true;
            }
            return false;
        }

        // Verify the double value high 0 or higher min and lower max
        public static bool valData(double value, int min = 0, int max = 0)
        {
            if (min == max && value >= min)
                return true;
            else if (value > min && value < max)
                return true;
            return false;
        }

        // Verify the value includes in array
        public static bool valData(string value, string[] array)
        {
            value = lowerWithoutSpecialString(value);
            for (int i = 0; i < array.Length; i++)
            {
                if (value == lowerWithoutSpecialString(array[i])) return true;
            }
            return false;
        }

        // Search Data and return pos in the data in array if not in array return -1
        public static int searchData(string value, string[] array)
        {
            value = lowerWithoutSpecialString(value);
            for (int i = 0; i < array.Length; i++)
            {
                if (value == lowerWithoutSpecialString(array[i])) return i;
            }
            return -1;
        }

        // Search Data limit pos and return pos in the data in array if not in array return -1
        public static int searchData(string value, string[] array, int pos)
        {
            value = lowerWithoutSpecialString(value);
            for (int i = 0; i < pos; i++)
            {
                if (value == lowerWithoutSpecialString(array[i])) return i;
            }
            return -1;
        }

        // The user insert value type string and return 
        public static string insData(string nome)
        {
            string data;
            do
            {
                Console.Write($"{nome}: ");
                data = Console.ReadLine();
            } while (data.Length == 0);
            return data;
        }

        // The user insert value type double and return 
        public static double insDData(string nome)
        {
            double data;
            bool dataValue;
            do
            {
                Console.Write($"{nome}: ");
                data = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                dataValue = valData(data);
                if (!dataValue) Message.Error($"Valor Inválido", false, false);
            } while (!dataValue);
            return data;
        }

        // The user insert value type int and return 
        public static int insIData(string nome)
        {
            int data;
            bool dataValue;
            do
            {
                Console.Write($"{nome}: ");
                data = int.Parse(Console.ReadLine());
                dataValue = valData(data);
                if(!dataValue) Message.Error($"Valor Inválido", false, false);
            } while (!valData(data));
            return data;
        }

        // Verify data exists in array, on pos if not return message error
        public static string insData(string name, string[] arrayValues, int pos, bool subString = false)
        {
            string data;
            int posData;
            string txt = "";
            do
            {
                data = insData(name);
                posData = searchData(data, arrayValues, pos);
                if (posData == -1)
                {
                    if (subString) txt = name.Substring(0, name.IndexOf(" "));
                    Message.Error($"{txt} {data} não encontrado", false, false);
                }
            } while (posData == -1);
            return arrayValues[posData];
           
        }

        // Verify data exists in array int, on pos if not return message error
        public static int insIData(string name, int[] arrayValues, bool subString = false)
        {
            int data;
            bool posData;
            string txt = "";
            do
            {
                data = insIData(name);
                posData = valData(data, arrayValues);

                if (!posData)
                {
                    if (subString) txt = name.Substring(0, name.IndexOf(" "));
                    Message.Error($"{txt} {data} não encontrado", false, false);
                }
            } while (!posData);
            return data;
        }

        // Return total days betwen date1 and date2
        public static int daysTotal(DateTime data1, DateTime data2)
        {
            return ((int)(data2 - data1).TotalDays + 1);
        }
    }
}
