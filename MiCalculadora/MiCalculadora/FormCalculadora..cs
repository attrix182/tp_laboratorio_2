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

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string salida;
            double operacion;

            operacion = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);

            salida = operacion.ToString();

            this.lblResultado.Text = salida;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {


            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
        }


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
