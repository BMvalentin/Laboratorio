using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection conexion = new SqlConnection("Data Source=Rocio;Initial Catalog=master; Integrated Security=true");

        public void CargarPacientes()
        {
            string consulta = "SELECT Paciente.id_paciente AS ID, Paciente.nombrePaciente AS Nombre, Paciente.apellidoPaciente AS Apellido, " +
                "Paciente.fechaNacimiento AS 'Fecha Nacimiento', Paciente.dni AS DNI,\r\nPaciente.email AS Email, Paciente.telefono AS Telefono, " +
                "Localidad.nombreLocalidad AS Localidad, Paciente.direccionCalle AS 'Dirección Calle', Paciente.dirrecionNumero AS 'Dirección Número'," +
                "\r\nPaciente.piso AS Piso, Paciente.departamento AS Departamento FROM Paciente INNER JOIN Localidad ON Paciente.fk_localidad = Localidad.id_localidad;";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridPacientes.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            txtNombre.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
