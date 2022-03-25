using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico.auxClass;

namespace TrabalhoPratico
{
    abstract class Veiculo
    {
        // Variables 

        private string _brand;
        private string _color;
        private string _fuel;
        private double _priceDay;
        private string _state;
        private DateTime? _dataState = null;
        private static readonly string[] _fuelPossible = new string[] { "Gasolina", "Elétrico","Gasóleo", "Gás", "Híbrido" };
        private static readonly string[] _statePossible = new string[] { "Disponível", "Alugado", "Reservado", "Manutenção" };

        // Methods getters and setters
        public string Brand { get => _brand; set => _brand = value; }
        public string Color { get => _color; set => _color = value; }
        public string Fuel { get => _fuel; 
            set { 
                int pos = ValidateData.searchData(value, _fuelPossible);
                if (pos != -1)
                    if(this.GetType() == typeof(Mota) && pos > 1 || this.GetType() == typeof(Camioneta) && pos > 3 || this.GetType() == typeof(Camiao) && pos > 2)
                        Message.Error($"Tipo de combustível não é compativel para o veiculo {this.GetType().Name}!");
                    else
                        _fuel = _fuelPossible[pos];
                else
                    Message.Error($"Tipo de combustível não foi encontrado!");
            }
        }

        public double PriceDay { get => _priceDay; 
            set {
                if (ValidateData.valData(value))
                    _priceDay = value;
                else
                    Message.Error("Preço por dia não cumpre os requesitos, por favor verifique");
            }
        }
        public string State { get => _state; 
            set {
                int pos = ValidateData.searchData(value, _statePossible);
                if(pos != -1)
                    _state = _statePossible[pos];
                else
                    Message.Error("Estado do veiculo não encontrado, por favor tente novamente");
            } 
        }
        public DateTime? DataState {
            get
            {
                if (_dataState != null)
                {
                    return _dataState;
                }
                else
                {
                    Message.Error($"No estado {State} não é possivel consultar a data!");
                    return null;
                }
            }
            set {
                if (State != _statePossible[0])
                     _dataState = value;
                else
                    Message.Error($"No estado {State} não é possivel definir uma data!");
            }
        }

        // Static methods
        public static string[] StatePossible => _statePossible;
        public static string[] FuelPossible => _fuelPossible;

        // Construct
        public Veiculo(string brand, string color, string fuel, double priceDay)
        {
            Brand = brand;
            Color = color;
            Fuel = fuel;
            PriceDay = priceDay;
            State = _statePossible[0];
        }
        public Veiculo(Veiculo veiculo)
        {
            Brand = veiculo.Brand;
            Color = veiculo.Color;
            Fuel = veiculo.Fuel;
            PriceDay = veiculo.PriceDay;
            State = veiculo.State;
            DataState = veiculo.DataState;

        }

        // Overrides ToString, Equals, GetHashCode
        public override string ToString()
        {
            string txt = $"Marca: {Brand};Tipo: {this.GetType().Name}; Color: {Color}; Combustível: {Fuel}; Preço/Dia: {PriceDay}; Estado: {State}";
            txt = (State != _statePossible[0]) ? txt + $"; Data: {DataState.ToString().Substring(0, DataState.ToString().IndexOf(" "))}" : txt;
            return txt;
        }
        public override bool Equals(object obj)
        {
            Veiculo veiculo = obj as Veiculo;
            if(veiculo.Brand == Brand && veiculo.Color == Color && veiculo.Fuel == Fuel && veiculo.PriceDay == PriceDay && veiculo.State == State && veiculo.DataState == DataState)
                    return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
