using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero = 0;
        public Numero() : this(0) { }
        public Numero(string strNumero) { this.SetNumero = strNumero; }
        public Numero(double numero) : this(numero.ToString()) { }



        private double ValidarNumero(string strNumero)
        {

            if (double.TryParse(strNumero, out double numero))
            {

                return numero;

            }

            return 0;

        }
        public static string BinarioDecimal(string binario)
        {
            double decimalOut;

            decimalOut = Convert.ToInt32(binario, 2);

            return decimalOut.ToString();
        }

        public static string DecimalBinario(double numero)
        {

            long num;
            string resultado = "Valor invalido";

            if (numero > 0)
            {

                num = (long)numero;
                resultado = "";
                while (num != 0)
                {
                    resultado = (num % 2).ToString() + resultado;
                    num /= 2;
                }
            }
            else if (numero == 0)
            {
                resultado = "0";
            }
            else if (numero < 0)
            {
                resultado = "Valor invalido";
                return resultado;
            }

            return resultado;
        }


        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            double aux;
            if (double.TryParse(numero, out aux))
            {
                retorno = DecimalBinario(double.Parse(numero));
            }
            return retorno;

        }

        public String SetNumero
        {

            set { this.numero = ValidarNumero(value); }

        }



        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {


            if (n2.numero == 0)
            {
                return 0;
            }

            return n1.numero / n2.numero;
        }

    }
}
