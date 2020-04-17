using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {

            if (operador.Equals("+") || operador.Equals("-") || operador.Equals("/") || operador.Equals("*"))
            {
                return operador;
            }
            else { return "+"; }

        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {

            string opValido;
            double resultado = 0;

            opValido = ValidarOperador(operador);

            switch (opValido)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;

            }

            return resultado;

        }
    }
}
