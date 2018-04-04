using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Singletons;

namespace Vueling.Presentation.Winsite
{
    public partial class AlumnosShowForm : Form
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IAlumnoBL alumnoBL;
        SingletonListaJson listaAlumnosJson;

        public AlumnosShowForm()
        {
            log.Debug("Entrar AlumnosShowForm: ");
            InitializeComponent();
            alumnoBL = new AlumnoBL();
        }

        private void AlumnosShowForm_Load(object sender, EventArgs e)
        {
            try
            {
                log.Debug("Entrar AlumnosShowForm_Load: ");
                List<Alumno> listAlumnos = alumnoBL.GetAlumnos();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = listAlumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar Mostrar lista alumnos TXT: ");
            List<Alumno> listAlumnos = alumnoBL.GetAlumnos();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = listAlumnos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar Mostrar lista alumnos JSON: ");
            dataGridView1.ReadOnly = true;
            listaAlumnosJson = SingletonListaJson.Instance;
            dataGridView1.DataSource = listaAlumnosJson.ListaAlunmnos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = "";
        }
    }
}
