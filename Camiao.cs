using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico.auxClass;


namespace TrabalhoPratico
{
    class Camiao : Veiculo
    {
        // Variables

        private int _weightMax;

        // Encapsolation
        public int WeightMax { 
            get => _weightMax; 
            set { 
                if(ValidateData.valData(value))
                    _weightMax = value;
                else
                    Message.Error($"Peso inválido!");
            }
        }

        // Constructs
        public Camiao(string brand, string color, string fuel, double priceDay, int weight) : base(brand, color, fuel, priceDay)
        {
            WeightMax = weight;
        }
        public Camiao(Camiao c) : base(c)
        {
            WeightMax = c.WeightMax;
        }

        // Overrides ToString, Equals, GetHashCode
        public override string ToString()
        {
            return base.ToString() + $"; Peso Máximo: {WeightMax}";
        }
        public override bool Equals(object obj)
        {
            Camiao c = obj as Camiao;
            if (base.Equals(obj) && c.WeightMax == WeightMax)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
