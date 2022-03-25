using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico.auxClass;

namespace TrabalhoPratico
{
    class Program
    {
        public static DateTime dateProgram;
        static bool dataConvert;
        static string dateString;
        // Constant
        private static string nameCompany = $"Automobile";
        
        // Lists objects
        private static List<Veiculo> veiculoList = new List<Veiculo>();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Table.title(nameCompany);
                dateString = ValidateData.insData($"\nData a iniciar o programa");
                dataConvert = DateTime.TryParse(dateString, out dateProgram);
                if (!dataConvert)
                {
                    Message.Error("Não é possivel converter a data", false, false);
                }
                else if (dateProgram < DateTime.Now.Date)
                {
                    Message.Error("Data incorreta", false, false);
                }
            } while (!dataConvert || dateProgram < DateTime.Now.Date);
            nameCompany += $" (Data Atual:  {dateProgram.ToShortDateString()})";
            inserVeiculoDefault();



            int op, tamTable = 40;

            do
            {
                nameCompany = nameCompany.Replace(nameCompany.Substring(nameCompany.LastIndexOf(' '), nameCompany.Length - nameCompany.LastIndexOf(' ')-1), " " + dateProgram.ToShortDateString());
                Console.Clear();
                Table.title(nameCompany, tamTable);
                Table.line(tamTable);
                Table.dataLine("1. Inserir um veiculo", tamTable);
                Table.dataLine("2. Alterar o estado de um veiculo", tamTable);
                Table.dataLine("3. Ver veiculos disponiveis para alugar", tamTable);
                Table.dataLine("4. Ver veiculos em manutenção", tamTable);
                Table.dataLine("5. Calcular preço da reserva e alugar", tamTable);
                Table.dataLine("6. Exportar informações veiculos HTML", tamTable);
                Table.dataLine("7. Fechar dia", tamTable);
                Table.dataLine("8. Calcular lucro entre 2 datas");
                Table.dataLine("0. Sair", tamTable);
                Table.line(tamTable);
                Console.Write("Opção: ");
                if (int.TryParse(Console.ReadLine(), out op)) processOp(op);

            } while (op != 0);
            //Console.ReadKey();
        }

        // Insert Veiculos por default
        static void inserVeiculoDefault()
        {
            veiculoList.Add(new Carro("AudiA1", "Cinza", "Gasóleo", 20, 5, "Manual"));
            veiculoList.Add(new Carro("AudiA1", "Preto", "Gasóleo", 20, 5, "Manual"));
            veiculoList.Add(new Carro("AudiA1", "Branco", "Gasóleo", 20, 5, "Manual"));
            veiculoList.Add(new Carro("BMW Serie 1", "Cinza", "Gasolina", 22, 5, "Manual"));
            veiculoList.Add(new Carro("BMW Serie 1", "Preto", "Gasolina", 22, 5, "Manual"));
            veiculoList.Add(new Carro("BMW Serie 2", "Cinza", "Gasolina", 24, 5, "Manual"));
            veiculoList.Add(new Carro("BMW Serie 2", "Preto", "Gasolina", 24, 5, "Manual"));
            veiculoList.Add(new Carro("BMW Serie 2", "Preto", "Gasolina", 24, 5, "Manual"));
            veiculoList.Add(new Carro("Mazda CX-3", "Vermelho", "Gasóleo", 18, 5, "Manual"));
            veiculoList.Add(new Carro("Mazda CX-3", "Vermelho", "Gasóleo", 18, 5, "Manual"));
            veiculoList.Add(new Carro("Mazda CX-3", "Azul", "Gasóleo", 18, 5, "Manual"));
            veiculoList.Add(new Carro("Mazda CX-3", "Azul", "Gasóleo", 18, 5, "Manual"));
            veiculoList.Add(new Carro("Mazda CX-5", "Vermelho", "Gasóleo", 20, 5, "Manual"));
            veiculoList.Add(new Carro("Mazda CX-5", "Vermelho", "Gasóleo", 20, 5, "Manual"));
            veiculoList.Add(new Carro("Mazda CX-5", "Azul", "Gasóleo", 20, 5, "Manual"));
            veiculoList.Add(new Carro("Porsche 911", "Cinza", "Gasóleo", 40, 3, "Automático"));
            veiculoList.Add(new Carro("Renault Clio", "Branco", "Gasóleo", 12, 3, "Manual"));
            veiculoList.Add(new Carro("Renault Clio", "Branco", "Gasóleo", 12, 3, "Manual"));
            veiculoList.Add(new Carro("Renault Clio", "Preto", "Gasolina", 10, 5, "Manual"));
            veiculoList.Add(new Carro("Renault Clio", "Preto", "Gasolina", 10, 5, "Manual"));
            veiculoList.Add(new Carro("Renault Megane", "Preto", "Gasolina", 16, 5, "Manual"));
            veiculoList.Add(new Carro("Renault Megane", "Vermelho", "Gasolina", 16, 5, "Manual"));
            veiculoList.Add(new Carro("Renault Megane", "Azul", "Gasolina", 16, 5, "Manual"));
            veiculoList.Add(new Carro("Renault Megane", "Cinza", "Gasolina", 16, 5, "Manual"));
            veiculoList.Add(new Carro("Renault Zoe", "Branco", "Elétrico", 25, 3, "Automático"));
            veiculoList.Add(new Carro("Renault Zoe", "Branco", "Elétrico", 25, 3, "Automático"));
            veiculoList.Add(new Carro("Renault Zoe", "Branco", "Elétrico", 25, 3, "Automático"));
            veiculoList.Add(new Carro("Toyota CH-R", "Preto", "Híbrido", 27, 5, "Automático"));
            veiculoList.Add(new Carro("Toyota CH-R", "Cinza", "Híbrido", 27, 5, "Automático"));
            veiculoList.Add(new Carro("Toyota Prius", "Vermelho", "Híbrido", 25, 5, "Automático"));
            veiculoList.Add(new Carro("Toyota Prius", "Vermelho", "Híbrido", 25, 5, "Automático"));
            veiculoList.Add(new Carro("Toyota Prius", "Azul", "Híbrido", 25, 5, "Automático"));
            veiculoList.Add(new Carro("Toyota Corolla", "Preto", "Gasolina", 15, 5, "Manual"));
            veiculoList.Add(new Carro("Seat Leon", "Preto", "Gasóleo", 17, 3, "Manual"));
            veiculoList.Add(new Mota("Honda CBR", "Amarelo", "Gasolina", 10, 125));
            veiculoList.Add(new Mota("Honda CBR", "Amarelo", "Gasolina", 10, 125));
            veiculoList.Add(new Mota("Kawasaki ZRX", "Vermelho", "Gasolina", 10, 300));
            veiculoList.Add(new Mota("Kawasaki ZRX", "Vermelho", "Gasolina", 10, 300));
            veiculoList.Add(new Camioneta("Irizar PB", "Preto", "Gasóleo", 100, 3, 150));
            veiculoList.Add(new Camiao("MAN", "Preto", "Gasóleo", 120, 2000));
            veiculoList.Add(new Camiao("Mercedes", "Preto", "Gasóleo", 180, 2500));
            veiculoList.Add(new Camiao("Scania", "Preto", "Gasóleo", 160, 1750));
        }

        // Verify option selected and call function
        static void processOp(int op)
        {
            switch (op)
            {
                case 1:
                    insertVeiculo();
                    break;
                case 2:
                    updateState();
                    break;
                case 3:
                    viewVeiculos(Veiculo.StatePossible[0]);
                    break;
                case 4:
                    viewVeiculos(Veiculo.StatePossible[3]);
                    break;
                case 5:
                    caclPrice();
                    break;
                case 6:
                    exportHTML();
                    break;
                case 7:
                    closeDay();
                    break;
                case 8:
                    lucroDays();
                    break;
            }
        }

        // Caculate how much money in two dates
        private static void lucroDays()
        {
            Console.Clear();
            Table.title(nameCompany);
            Table.line();
            DateTime dateI, dateF;
            string dataState;
            bool dataConvert;
            do
            {
                dataState = ValidateData.insData($"Data Inicial");
                dataConvert = DateTime.TryParse(dataState, out dateI);
                if (!dataConvert)
                {
                    Message.Error("Não é possivel converter a data", false, false);
                }
                else if (dateI < dateProgram)
                {
                    Message.Error("Data incorreta", false, false);
                }
            } while (!dataConvert || dateI < dateProgram);
            do
            {
                dataState = ValidateData.insData($"Data Final");
                dataConvert = DateTime.TryParse(dataState, out dateF);
                if (!dataConvert)
                {
                    Message.Error("Não é possivel converter a data", false, false);
                }
                else if (dateF < dateProgram || dateF < dateI)
                {
                    Message.Error("Data incorreta", false, false);
                }
            } while (!dataConvert || dateF < dateProgram || dateF < dateI);

            List<Veiculo> veiculosAlugados = ValidateData.newListState(veiculoList, Veiculo.StatePossible[1]);
            if (veiculosAlugados.Count == 0)
            {
                return;
            }
            double total = 0;
            for(int i=0; i < veiculosAlugados.Count; i++)
            {
                if(dateI <= veiculosAlugados[i].DataState)
                {
                    if(dateF >= veiculosAlugados[i].DataState)
                    {
                        total += veiculosAlugados[i].PriceDay * (((DateTime)veiculosAlugados[i].DataState - dateI).Days + 1);
                    } else
                    {
                        total += veiculosAlugados[i].PriceDay * ((dateF - dateI).Days + 1);
                    }

                }
            }
            Table.dataLine($"Total de faturação entre {dateI.ToShortDateString()} e {dateF.ToShortDateString()}: {total} EUR");
            Console.ReadKey();

        }

        // Add +1 day
        private static void closeDay()
        {
            dateProgram = dateProgram.AddDays(1);
            avaria();
        }

        // Select what auto insert
        private static void insertVeiculo()
        {
            int op;
            bool valOp;
            do
            {
                Console.Clear();
                Table.title(nameCompany);
                Table.line();
                Table.dataLine("Escolha o veiculo a inserir:");
                Table.dataLine("\n1. Carro");
                Table.dataLine("2. Mota");
                Table.dataLine("3. Camião");
                Table.dataLine("4. Camioneta");
                Table.dataLine("5. Sair");
                Table.line();
                Console.Write("Opção: ");
                valOp = int.TryParse(Console.ReadLine(), out op);
                if (!valOp || op < 1 || op > 5)
                {
                    if (valOp) valOp = !valOp;
                    Message.Error("Opção não valida", false, false);
                }
                if (op == 5) return;
            } while (!valOp);
            Type typVeiculo = typeof(Carro);
            switch (op)
            {
                case 1: typVeiculo = typeof(Carro); break;
                case 2: typVeiculo = typeof(Mota); break;
                case 3: typVeiculo = typeof(Camiao); break;
                case 4: typVeiculo = typeof(Camioneta); break;
            }
            callObj(typVeiculo);
            Console.ReadKey();

        }

        // Fill the values necessary for add auto
        private static void callObj(Type typVeiculo)
        {
            Console.Clear();
            Table.title(nameCompany);
            Table.line();
            Table.dataLine($"Adicionar {typVeiculo.Name}\n");
            //ConstructorInfo ctor = typVeiculo.GetConstructor(new[] { typVeiculo });
            if (typVeiculo == typeof(Carro))
                veiculoList.Add(new Carro(
                    ValidateData.insData("Marca"),
                    ValidateData.insData("Cor"),
                    ValidateData.insData($"Combustivel ({ValidateData.showContent(Veiculo.FuelPossible, Veiculo.FuelPossible.Length)})", Veiculo.FuelPossible, Veiculo.FuelPossible.Length, true),
                    ValidateData.insDData("Preço / Dia"),
                    ValidateData.insIData($"NºPortas ({ValidateData.showContent(Carro.Doorspossibles, Carro.Doorspossibles.Length)})", Carro.Doorspossibles, true),
                    ValidateData.insData($"Transmissão ({ValidateData.showContent(Carro.TransmissionPossible, Carro.TransmissionPossible.Length, "ou")})", Carro.TransmissionPossible, Carro.TransmissionPossible.Length, true)
                    )
                 );
            else if (typVeiculo == typeof(Mota))
                veiculoList.Add(new Mota(
                    ValidateData.insData("Marca"),
                    ValidateData.insData("Cor"),
                    ValidateData.insData($"Combustivel ({ValidateData.showContent(Veiculo.FuelPossible, 2)})", Veiculo.FuelPossible, 2, true),
                    ValidateData.insDData("Preço / Dia"),
                    ValidateData.insIData($"Ciclindrada ({ValidateData.showContent(Mota.PowerPossible, Mota.PowerPossible.Length)})", Mota.PowerPossible, true)
                    )
                 );

            else if (typVeiculo == typeof(Camiao))
                veiculoList.Add(new Camiao(
                    ValidateData.insData("Marca"),
                    ValidateData.insData("Cor"),
                    ValidateData.insData($"Combustivel ({ValidateData.showContent(Veiculo.FuelPossible, 3)})", Veiculo.FuelPossible, 3, true),
                    ValidateData.insDData("Preço / Dia"),
                    ValidateData.insIData($"Peso de Carga Total")
                    )
                 );

            else if (typVeiculo == typeof(Camioneta))
                veiculoList.Add(new Camioneta(
                    ValidateData.insData("Marca"),
                    ValidateData.insData("Cor"),
                    ValidateData.insData($"Combustivel ({ValidateData.showContent(Veiculo.FuelPossible, 4)})", Veiculo.FuelPossible, 4, true),
                    ValidateData.insDData("Preço / Dia"),
                    ValidateData.insIData($"Nº de Eixos", Camioneta.NEixosPossible),
                    ValidateData.insIData($"Nº de Passageiros")
                    )
                 );

            else
                Message.Error("Objeto não configurado");
            Message.Sucess($"{typVeiculo.Name} adicionado com sucesso");
            veiculoList = veiculoList.OrderBy(p => p.GetType().Name).ToList();
        }

        // Select auto and state
        private static void updateState()
        {
            int op;
            bool opVer;
            if (veiculoList.Count == 0)
            {
                Message.Error("Não existem veiculos", true, false);
                return;
            }
            do
            {
                Console.Clear();
                Table.title(nameCompany);
                Table.line();
                ValidateData.showAllCOntent(veiculoList, 0, veiculoList.Count, true);
                Table.dataLine("\n0. Sair");
                Table.line();
                Console.Write("\nOpcao: ");
                opVer = int.TryParse(Console.ReadLine(), out op);
                if (op == 0) return;
                if (!opVer || !ValidateData.valData(op, 1, veiculoList.Count) || op > veiculoList.Count)
                {
                    if (opVer) opVer = !opVer;
                    Message.Error("Opção inválida", false, false);
                }
            } while ((!opVer || op > veiculoList.Count));
            alterState(op);
            Console.ReadKey();
        }

        // Change state auto
        private static void alterState(int op)
        {
            string newEstado;
            Console.Clear();
            Table.title(nameCompany);
            Table.line();
            Table.dataLine($"Alterar estado da Viatura {op}");
            Table.dataLine($"\nEstado Atual: {veiculoList[op - 1].State}");
            if (veiculoList[op - 1].State != Veiculo.StatePossible[0])
                Table.dataLine($"Data: {veiculoList[op - 1].DataState.ToString().Substring(0, veiculoList[op - 1].DataState.ToString().IndexOf(" "))}");
            Table.line();
            string[] statePossible = ValidateData.showContentReturnArray(Veiculo.StatePossible, Veiculo.StatePossible.Length, veiculoList[op - 1].State);
            bool stateUser;
            do
            {
                newEstado = ValidateData.insData($"Novo ({ValidateData.showContent(statePossible, statePossible.Length)})");
                stateUser = ValidateData.valData(newEstado, statePossible);
                if (!stateUser)
                {
                    if(ValidateData.valData(newEstado, new string[] { veiculoList[op - 1].State }))
                        Message.Error($"Estado atual, insira um novo", false, false);
                    else
                        Message.Error($"Estado não encontrado", false, false);
                }
            } while (!stateUser);
            string dataState;
            bool dataConvert;
            DateTime date;
            if(ValidateData.searchData(newEstado, Veiculo.StatePossible, Veiculo.StatePossible.Length) != 0)
            {
                do
                {
                    dataState = ValidateData.insData($"Data");
                    dataConvert = DateTime.TryParse(dataState, out date);
                    if (!dataConvert)
                    {
                        Message.Error("Não é possivel converter a data", false, false);
                    } else if (date < dateProgram)
                    {
                        Message.Error("Data incorreta", false,false);
                    }
                } while(!dataConvert || date < dateProgram);
                veiculoList[op - 1].State = newEstado;
                veiculoList[op - 1].DataState = date;
            }
            else
            {
                veiculoList[op - 1].DataState = null;
                veiculoList[op - 1].State = newEstado;
            }
            Message.Sucess("Estado alterado com sucesso!");
        }

        // View auto search by state
        private static List<Veiculo> viewVeiculos(string v = "", bool readKey = true)
        {
            Console.Clear();
            Table.title(nameCompany);
            Table.line();
            List<Veiculo> newList;
            if (v == Veiculo.StatePossible[0])
            {
                int op;
                bool valOp;
                do
                {
                    Console.Clear();
                    Table.title(nameCompany);
                    Table.line();
                    Table.dataLine("Tipo de veiculo:");
                    Table.dataLine("\n1. Carro");
                    Table.dataLine("2. Mota");
                    Table.dataLine("3. Camião");
                    Table.dataLine("4. Camioneta");
                    Table.dataLine("5. Sair");
                    Table.line();
                    Console.Write("Opção: ");
                    valOp = int.TryParse(Console.ReadLine(), out op);
                    if (!valOp || op < 1 || op > 5)
                    {
                        if (valOp) valOp = !valOp;
                        Message.Error("Opção não valida", false, false);
                    }
                    if (op == 5) return null;
                } while (!valOp);
                Console.Clear();
                Table.title(nameCompany);
                Table.line();
                Type typObjData = typeof(Carro);
                switch (op)
                {
                    case 1: typObjData = typeof(Carro); break;
                    case 2: typObjData = typeof(Mota); break;
                    case 3: typObjData = typeof(Camiao); break;
                    case 4: typObjData = typeof(Camioneta); break;
                }
                newList = ValidateData.newListState(veiculoList, v,  typObjData);

            } else
            {
                newList = ValidateData.newListState(veiculoList, v);
            }
                ValidateData.showAllCOntent(newList, 0, newList.Count, true);
                if(readKey && newList.Count != 0) Console.ReadKey();
            return newList;
        }

        // Calc price for example reservation
        private static void caclPrice()
        {
            List<Veiculo> newList = viewVeiculos(Veiculo.StatePossible[0], false);
            if (newList.Count == 0)
            {
                return;
            }
            int idVeiculo;
            do {
                Console.Write("\nId do veiculo: ");
                idVeiculo = int.Parse(Console.ReadLine());
                if (idVeiculo < 1 || idVeiculo > newList.Count) Message.Error("Viatura não encontrada!", false, false);
            } while (idVeiculo < 1 || idVeiculo > newList.Count);
            DateTime dateI, dateF;
            string dataState;
            bool dataConvert;
            do
            {
                dataState = ValidateData.insData($"Data Inicial");
                dataConvert = DateTime.TryParse(dataState, out dateI);
                if (!dataConvert)
                {
                    Message.Error("Não é possivel converter a data", false, false);
                }
                else if (dateI < dateProgram)
                {
                    Message.Error("Data incorreta", false, false);
                }
            } while (!dataConvert || dateI < dateProgram);
            do
            {
                dataState = ValidateData.insData($"Data Final");
                dataConvert = DateTime.TryParse(dataState, out dateF);
                if (!dataConvert)
                {
                    Message.Error("Não é possivel converter a data", false, false);
                }
                else if (dateF < dateProgram || dateF < dateI)
                {
                    Message.Error("Data incorreta", false, false);
                }
            } while (!dataConvert || dateF < dateProgram || dateF < dateI);
            Table.dataLine($"Valor Total: {(newList[idVeiculo - 1].PriceDay * ValidateData.daysTotal(dateI, dateF)).ToString()} EUR");
            int opReserva;
            bool opReservaValue;
            do {
                Table.dataLine($"Deseja efetivar a reserva? 1 - Sim / 2 - Não");
                Console.Write("Op: ");
                opReservaValue = int.TryParse(Console.ReadLine(), out opReserva);
                if (opReservaValue && opReserva != 1 && opReserva != 2) opReservaValue = !opReservaValue;
            } while (!opReservaValue);
            Console.WriteLine(opReserva);
            if(opReserva == 1)
            {
                newList[idVeiculo - 1].State = Veiculo.StatePossible[2];
                newList[idVeiculo - 1].DataState = dateF;
            }
            Console.ReadKey();

        }

        // Export HTML
        private static void exportHTML()
        {
            try
            {
                string tdStyle = "padding:10px;text-align:center;background:#333;color:#fff;";
                string tdStyle2 = "padding:10px;text-align:center;border-bottom:1px dashed grey";
                ExportHtml Viaturas = new ExportHtml($"Veiculos_{dateProgram.ToString("yyyyMMdd")}");

                ValidateData.verif(veiculoList);
                List<String> typeVeiculo = new List<string>();
                veiculoList.ForEach(
                    delegate (Veiculo item)
                    {
                        if (item.State != Veiculo.StatePossible[0] && !ValidateData.valData(item.GetType().Name, typeVeiculo.ToArray()))
                        {
                            typeVeiculo.Add(item.GetType().Name);
                        }
                    });
                for (int i = 0; i < veiculoList.Count; i++)
                {
                    bool FlagsAttribute = false;
                    if (i > 0 && veiculoList[i].GetType() != veiculoList[i - 1].GetType() || i == 0)
                    {
                        if(i!=0) Viaturas.elemSingle("table", "", true);
                        Viaturas.elem("h2", veiculoList[i].GetType().Name, tdStyle);
                        Viaturas.elemSingle("table", "display:flex; justify-content:center");
                        Viaturas.elemSingle("tr", "padding:10px;");
                        FlagsAttribute = true;
                    }
                    // Cabecalho
                    string[] dados = veiculoList[i].ToString().Split(';');

                    for (int j = 0; j < dados.Length; j++)
                    {
                        string[] cabec = dados[j].ToString().Split(':');
                        if (FlagsAttribute)
                        {
                            if (j == 0) Viaturas.elem("td", "ID", tdStyle);
                            if (j == 6 && ValidateData.valData(veiculoList[i].GetType().Name, typeVeiculo.ToArray()))
                                Viaturas.elem("td", "Data", tdStyle);
                            if (cabec[0].Contains("Data")) continue;
                            Viaturas.elem("td", cabec[0], tdStyle);
                            if (j == dados.Length - 1) Viaturas.elemSingle("tr", "", true);
                        }

                    }

                    // Dados
                    Viaturas.elemSingle("tr", "padding:10px;");
                    for (int j = 0; j < dados.Length; j++)
                    {
                        string[] cabec = dados[j].ToString().Split(':');
                        if (j == 0) Viaturas.elem("td",(i + 1).ToString(), tdStyle2);
                        if (j == 6 && ValidateData.valData(veiculoList[i].GetType().Name.ToString(), typeVeiculo.ToArray()))
                            if (!veiculoList[i].ToString().Contains("Data"))
                                Viaturas.elem("td", "-", tdStyle2);
                        Viaturas.elem("td", cabec[1],tdStyle2);
                    }
                    Viaturas.elemSingle("tr", "", true);
                    //if (FlagsAttribute) Viaturas.elemSingle("table", "", true);
                }






                //Viaturas.elem("h1", "Listagem de Veiculos", "text-align:center");

                //Viaturas.elem("td", "Marca", tdStyle);
                //Viaturas.elem("td", "Tipo de Veiculo", tdStyle);
                //Viaturas.elem("td", "Cor", tdStyle);
                //Viaturas.elem("td", "Combustivel", tdStyle);
                //Viaturas.elem("td", "Preço / Dia", tdStyle);
                //Viaturas.elem("td", "Estado", tdStyle);
                //Viaturas.elem("td colspan=5", "Outros atributos", tdStyle);
                //Viaturas.elemSingle("tr", "", true);
                //for (int i = 0; i < veiculoList.Count; i++)
                //{
                //    String[] words = veiculoList[i].ToString().Split(';');
                //    Viaturas.elemSingle("tr", "padding:10px;");
                //    for (int j = 0; j < words.Length; j++)
                //    {
                //        if(j < 6)
                //            Viaturas.elem("td", words[j].Substring(words[j].LastIndexOf(' '), words[j].Length - words[j].LastIndexOf(' ')), tdStyle2);
                //        else
                //            Viaturas.elem("td", words[j], tdStyle2);
                //    }
                //    Viaturas.elemSingle("tr", "", true);
                //}
                //Viaturas.elemSingle("table", "", true);
                Viaturas.closeFile();
                Message.Sucess("Ficheiro HTML exportado");
            } catch (Exception ex)
            {
                Message.Error(ex.Message);
            }
            Console.ReadKey();
        }
    
        // Random Number
        private static int gerNumber(int limit)
        {
            return new Random().Next(limit + 1);
        }
       
        // Parts Auto
        private static string partsCar(int num)
        {
            if (num == 0)
                return "Parachoques Partido";
            else if (num == 1)
                return "Vidro Frontal Partido";
            else if (num == 2)
                return "Pintura estragada";
            else if (num == 3)
                return "Problemas de motor";
            else if (num == 4)
                return "Pneus sem piso";
            else if (num == 5)
                return "Escape roto";
            else if (num == 6)
                return "Motor Danificado";
            else if (num == 7)
                return "Chassi Partido";
            return "";
        }
        
        // Generate problem with auto only call in close day method
        private static void avaria()
        {
            if (gerNumber(1) == 0)
            {
                int problem = gerNumber(7);
                string txtProblem = partsCar(problem);
                int viatura;
                List<int> veiculoNotDisponivel = ValidateData.newListId(veiculoList, Veiculo.StatePossible[0]);
                //List<Veiculo> veiculoNotDisponivel = ValidateData.newListState(veiculoList, Veiculo.StatePossible[0], false);
                if (veiculoNotDisponivel.Count == 0) return;
                viatura = veiculoNotDisponivel[gerNumber(veiculoList.Count - 1)];
                veiculoList[viatura].State = Veiculo.StatePossible[Veiculo.StatePossible.Length - 1];
                veiculoList[viatura].DataState = dateProgram.AddDays(problem);
                Table.line();
                Message.Warming($"{veiculoList[viatura].GetType().Name} com a marca {veiculoList[viatura].Brand} e cor {veiculoList[viatura].Color} tem {txtProblem} e está para Manutenção até { dateProgram.AddDays(problem).ToShortDateString()}", false, false);
            }
        }
    }
}
