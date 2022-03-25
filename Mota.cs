using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico.auxClass;

namespace TrabalhoPratico
{
    class Mota : Veiculo
    {
        // Variables
        private int _power;
        private static readonly int[] _powerPossible = new int[] {50,125,300};

        // Encapsolation
        public int Power
        {
            get => _power;
            set
            {
                if (ValidateData.valData(value, _powerPossible))
                    _power = value;
                else
                    Message.Error("Ciclidrada de mota não encontrada!");
            }
        }

        public static int[] PowerPossible => _powerPossible;

        // Construct
        public Mota(string brand, string color, string fuel, double priceDay, int power) : base(brand, color, fuel, priceDay)
        {
            Power = power;
        }

        public Mota(Mota m) : base(m)
        {
            Power = m.Power;
        }

        // Overrides ToString, Equals, GetHashCode
        public override string ToString()
        {
            return base.ToString() + $"; Cilindrada: {Power}";
        }
        public override bool Equals(object obj)
        {
            Mota mota = obj as Mota;
            if(base.Equals(obj) && mota.Power == Power)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
