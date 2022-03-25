using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico.auxClass;

namespace TrabalhoPratico
{
    class Camioneta : Veiculo
    {
        // Variables

        private int _nEixos;
        private int _nPeople;

        private static readonly int[] nEixos = new int[]{2,3};

        public static int[] NEixosPossible => nEixos;

        // Encapsolation
        public int NEixos
        {
            get => _nEixos;
            set
            {
                if (ValidateData.valData(value, NEixosPossible))
                    _nEixos = value;
                else
                    Message.Error("Nº de Eixos inválidos!");
            }
        }
        public int NPeople
        {
            get => _nPeople;
            set
            {
                if (ValidateData.valData(value))
                    _nPeople = value;
                else
                    Message.Error("Nº de passgeiros inválido!");
            }
        }


        // Construct
        public Camioneta(string brand, string color, string fuel, double priceDay, int nEixos, int nPeople) : base(brand, color, fuel, priceDay)
        {
            NEixos = nEixos;
            NPeople = nPeople;
        }
        public Camioneta(Camioneta C) : base(C)
        {
            NEixos = C.NEixos;
            NPeople = C.NPeople;
        }

        // Overrides ToString, Equals, GetHashCode
        public override string ToString()
        {
            return base.ToString() + $"; Nº de Eixos: {NEixos}; Nº de Pessoas: {NPeople}";
        }
        public override bool Equals(object obj)
        {
            Camioneta camioneta = obj as Camioneta;
            if (base.Equals(obj) && camioneta.NEixos == NEixos && camioneta.NPeople == NPeople)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
