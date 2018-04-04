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
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Singletons;
using Vueling.Common.Logic.Util;

namespace Vueling.Presentation.Winsite
{
    public partial class AlumnosShowForm : Form
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IAlumnoBL alumnoBL;
        private List<Alumno> listAlumnos;
        SingletonListaJson listaAlumnosJson;
        SingletonListaXml listaAlumnosXml;


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
                listAlumnos = alumnoBL.GetAlumnos();
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
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatTxt);
                listAlumnos = alumnoBL.GetAlumnos();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = listAlumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar Mostrar lista alumnos JSON: ");
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatJson);
                listaAlumnosJson = SingletonListaJson.Instance;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = listaAlumnosJson.ListaAlumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar Mostrar lista alumnos XML: ");
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatXml);
                listaAlumnosXml = SingletonListaXml.Instance;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = listaAlumnosXml.ListaAlumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar metodo Filtrar por campos");
            List<Alumno> listAl;
            var guid = textGuid.Text;
            var id = textId.Text != "" ? Convert.ToInt32(textId.Text) : 0;
            var Nombre = textNombre.Text;

            switch (EnumApp.getValorFormatAlumno())
            {
                case EnumApp.OpcTypeFile.Txt:
                    listAl = listAlumnos;
                    break;
                case EnumApp.OpcTypeFile.Json:
                    listaAlumnosJson = SingletonListaJson.Instance;
                    listAl = listaAlumnosJson.ListaAlumnos;
                    break;
                case EnumApp.OpcTypeFile.Xml:
                    listaAlumnosXml = SingletonListaXml.Instance;
                    listAl = listaAlumnosXml.ListaAlumnos;
                    break;
                default:
                    listAl = listAlumnos;
                    break;
            }

            var listFilter = from item in listAl
                            where item.Id == id || item.Guid == guid || item.Name == Nombre
                            select item;

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = listFilter.ToList<Alumno>();
            ResetFieldForm();
        }

        private void ResetFieldForm()
        {
            textGuid.Text = "";
            textId.Text = "";
            textNombre.Text = "";
        }
    }
}
