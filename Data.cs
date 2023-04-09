using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    public class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public override string ToString()
        {
            return dia + "/" + mes + "/" + ano;
        }

        public bool DataValida()
        {
            if (mes < 1 || mes > 12)
            {
                return false;
            }

            if (dia < 1 || dia > DiasNoMes())
            {
                return false;
            }

            return true;
        }

        private int DiasNoMes()
        {
            switch (mes)
            {
                case 2:
                    if (AnoBissexto())
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }

                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;

                default:
                    return 31;
            }
        }

        private bool AnoBissexto()
        {
            if (ano % 4 == 0)
            {
                if (ano % 100 == 0)
                {
                    if (ano % 400 == 0)
                    {
                        return true;
                    }

                    return false;
                }

                return true;
            }

            return false;
        }
        public int DiferencaDias()
        {
            DateTime dataAtual = DateTime.Today;
            DateTime dataArmazenada = new DateTime(this.ano, this.mes, this.dia);

            
            TimeSpan diferenca = dataArmazenada - dataAtual;

            
            return diferenca.Days;
        }
    }
}
