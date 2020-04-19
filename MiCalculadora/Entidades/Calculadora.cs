using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el string ingresado sea un operador valido, caso contrario retorna "+"
        /// </summary>
        /// <param name="operador">String ingresado</param>
        /// <returns>Retorna el operador validado</returns>
        private static string ValidarOperador(string operador)
        {

            if (operador.Equals("+") || operador.Equals("-") || operador.Equals("/") || operador.Equals("*"))
            {
                return operador;
            }
            else { return "+"; }

        }

        /// <summary>
        /// Realiza una operacion matematica basica entre los parametros recibidos
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Signo que especifica la operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion solicitada</returns>
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
