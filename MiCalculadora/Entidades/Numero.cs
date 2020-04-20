using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero = 0;

        /// <summary>
        /// Constructor por defecto. Asigna el valor 0 al atributo numero
        /// </summary>
        public Numero() : this(0) { }

        /// <summary>
        /// Constructor parametrizado. Asignana el valor recibido por parametro, verificando que sea un numero, si no lo es, le asigna el valor 0
        /// </summary>
        /// <param name="strNumero">Es el valor a asignar en el nuevo objeto</param>
        public Numero(string strNumero) { this.SetNumero = strNumero; }

        /// <summary>
        ///  Constructor parametrizado. Asignana al obejto numero el valor recibido por parametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) : this(numero.ToString()) { }


        /// <summary>
        ///  Metodo estatico y privado. Verifica que un string pasado por parametro
        /// sea parseable. De ser parseable retorna el valor del string, de no serlo retorna 0.
        /// </summary>
        /// <param name="strNumero">String conteniendo la cadena a validar</param>
        /// <returns>Retorna el numero validado. En caso de ser invalido 0</returns>
        private static double ValidarNumero(string strNumero)
        {

            if (double.TryParse(strNumero, out double numero))
            {

                return numero;

            }

            return 0;

        }

        /// <summary>
        /// Convierte a decimal el resultado de la operacion previa, validando que sea binario
        /// </summary>
        /// <param name="resultado">Numero a convertir</param>
        /// <returns>Retorna el valor en decimal, o un mensaje de error si el valor a convertir es invalido</returns>
        public static string BinarioDecimal(string resultado)
        {
            double decimalOut;

            if (EsBinario(resultado))
            {
                decimalOut = Convert.ToInt32(resultado, 2);
                return decimalOut.ToString();
            }
            else { return "No es binario"; }

        }

        /// <summary>
        /// Convierte a Binario el resultado de la operacion previa
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el valor convertido. En caso de no poder hacerlo "Valor invalido"</returns>
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


        /// <summary>
        ///Convierte un string representando un valor decimal a un
        /// string representando un valor binario. No convierte numeros 
        /// negativos.
        /// </summary>
        /// <param name="numero">Valor a convertir</param>
        /// <returns>Si pudo retorna un string con la conversion, caso contrario
        ///  retorna "Valor Invalido"</returns>
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

        /// <summary>
        ///  Setter privado. Pasa el valor a setear por el metodo privado 
        /// </summary>
        public String SetNumero
        {

            set { this.numero = ValidarNumero(value); }

        }


        /// <summary>
        ///  Sobrecarga de operador para operar con Objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">Objeto Numero en primer posicon</param>
        /// <param name="n2">>Objeto Numero en segunda posicion</param>
        /// <returns>Resultado de la operacion Suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador para operar con Objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">Objeto Numero en primer poscicon</param>
        /// <param name="n2">Objeto Numero en segunda posicion</param>
        /// <returns>Resultado de la operacion Resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador para operar con Objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">Objeto Numero en primer poscicon</param>
        /// <param name="n2">Objeto Numero en segunda posicion</param>
        /// <returns>Resultado de la operacion Multiplicar</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        ///  Sobrecarga de operador para operar con Objetos de tipo Numero.
        ///  No divide por 0
        /// </summary>
        /// <param name="n1">Objeto Numero en primer poscicon</param>
        /// <param name="n2">Objeto Numero en segunda posicion</param>
        /// <returns>Resultado de la operacion Dividir</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return 0;
            }

            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Verifica si un valor es binario para poder convertirlo a decimal
        /// </summary>
        /// <param name="resultado">valor a verificar</param>
        /// <returns>Retorna true si es binario, de lo contrario false</returns>
        public static bool EsBinario(string resultado)
        {

            bool retorno = true;

            foreach (char a in resultado)
            {

                if (!(a.Equals('1') || a.Equals('0')))
                {
                    retorno = false;
                }

            }
            return retorno;
        }



    }

}

