using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{


    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToParent();


        }

        /// <summary>
        /// Asigna el lblResultado con el resultado de la operacion retornada por el metodo Operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string salida;
            double operacion;

            operacion = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);

            salida = operacion.ToString();

            this.lblResultado.Text = salida;

        }

        /// <summary>
        /// Vacia el contenido de los TextBox, el ComboBox y el Label
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";

        }

        /// <summary>
        /// Cierra la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        /// <summary>
        /// Llama al método DecimalBinario de la clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }


        /// <summary>
        /// Llama al método BinarioDecimal de la clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);

        }


        /// <summary>
        /// Llama al metodo Operar de la clase calculadora para obtener un resultado de una operacion matematica pedida
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Signo que especifica la operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        private static double Operar(string num1, string num2, string operador)
        {

            Numero numero1 = new Numero(num1);
            Numero numero2 = new Numero(num2);

            double resultado;

            resultado = Calculadora.Operar(numero1, numero2, operador);

            return resultado;

        }

    }
}

