using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico.auxClass;

namespace TrabalhoPratico
{
    class Carro : Veiculo
    {
        // Variables

        private int _carDoors;
        private string _modeTransmission;
        private static readonly int[] _doorspossibles = new int[]{3,5};
        private static readonly string[] _transmissionPossible = new string[] {"Manual", "Automático"};

       // Encapsolation

        public int CarDoors
        {
            get => _carDoors;

            set {
                if (ValidateData.valData(value, _doorspossibles))
                    _carDoors = value;
                else
                    Message.Error("Nº de portas não válido");
            }
        }
        public string ModeTransmission { 
            
            get => _modeTransmission;

            set
            {
                int pos = ValidateData.searchData(value, _transmissionPossible);
                if (pos != -1)
                    _modeTransmission = _transmissionPossible[pos];
                else
                    Message.Error("Tipo de transmissão não reconhecida!");
            }
        }

        public static int[] Doorspossibles => _doorspossibles;

        public static string[] TransmissionPossible => _transmissionPossible;

        // Constructs
        public Carro(string brand, string color, string fuel, double priceDay, int nCarDoor, string transmission) : base(brand, color, fuel, priceDay)
        {
                CarDoors = nCarDoor;
                ModeTransmission = transmission;
        }
        public Carro(Carro c) : base(c)
        {
                CarDoors = c.CarDoors;
                ModeTransmission = c.ModeTransmission;
        }

        // Overrides ToString, Equals, GetHashCode
        public override string ToString()
        {
            return base.ToString() + $"; Portas: {CarDoors}; Transmissão: {ModeTransmission}";
        }
        public override bool Equals(object obj)
        {
            Carro carro = obj as Carro;
            if (base.Equals(obj) && carro.CarDoors == CarDoors && carro.ModeTransmission == ModeTransmission)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
