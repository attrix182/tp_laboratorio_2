using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// inicializa los atributos
        /// </summary>
        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection(Properties.Settings.Default.conexion);
        }
        /// <summary>
        /// Inserta en la base de datos un paquete
        /// </summary>
        /// <param name="p">Paquete a insertar en la base de datos</param>
        /// <returns>Retorna TRUE si se pudo guardar, FALSE en caso contrario</returns>
        public static bool Insertar(Paquete p)
        {
            bool exito = false;
            StringBuilder sb = new StringBuilder();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                sb.AppendFormat("INSERT INTO Paquetes(direccionEntrega,trackingID,alumno) values('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Luciano.Sinisterra.2A");
                comando.CommandText = sb.ToString();

                comando.ExecuteNonQuery();
                exito = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Se a producido un error al agregar paquete a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

            return exito;
        }




    }
}