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
using Vueling.Common.Logic;
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
                this.mostrarGrid(listAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void buttonTxt_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar Mostrar lista alumnos TXT: ");
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatTxt);
                listAlumnos = alumnoBL.GetAlumnos();
                this.mostrarGrid(listAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar Mostrar lista alumnos JSON: ");
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatJson);
                listaAlumnosJson = SingletonListaJson.Instance;
                this.mostrarGrid(listaAlumnosJson.ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXml_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar Mostrar lista alumnos XML: ");
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatXml);
                listaAlumnosXml = SingletonListaXml.Instance;
                this.mostrarGrid(listaAlumnosXml.ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar metodo Filtrar por campos");

            try
            {
                List<Alumno> listAl;
                var guid = textGuid.Text;
                var id = textId.Text != "" ? Convert.ToInt32(textId.Text) : 0;
                var nombre = textNombre.Text;
                var apellidos = textApellidos.Text;
                var dni = textDni.Text;
                var FechaNac = textFecNac.Text != "" ? Convert.ToDateTime(textFecNac.Text) : new DateTime(1800, 1, 1);
                var Edad = textEdad.Text != "" ? Convert.ToInt32(textEdad.Text) : 0;

                switch (TypeFileEnum.getValorFormatAlumno())
                {
                    case TypeFileEnum.OpcTypeFile.Txt:
                        listAl = listAlumnos;
                        break;
                    case TypeFileEnum.OpcTypeFile.Json:
                        listaAlumnosJson = SingletonListaJson.Instance;
                        listAl = listaAlumnosJson.ListaAlumnos;
                        break;
                    case TypeFileEnum.OpcTypeFile.Xml:
                        listaAlumnosXml = SingletonListaXml.Instance;
                        listAl = listaAlumnosXml.ListaAlumnos;
                        break;
                    default:
                        listAl = listAlumnos;
                        break;
                }

                var listFilter = from item in listAl
                                 where item.Id == id || item.Guid == guid || item.Name == nombre || item.Apellidos == apellidos
                                 || item.Dni == dni || item.FechaNac == FechaNac || item.Edad == Edad
                                 select item;

                this.mostrarGrid(listFilter.ToList<Alumno>());
                ResetFieldForm();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.ToString(), "Error Search Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Search Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFieldForm()
        {
            textGuid.Text = "";
            textId.Text = "";
            textNombre.Text = "";
            textApellidos.Text = "";
            textDni.Text = "";
            textFecNac.Text = "";
            textEdad.Text = "";
        }

        private void mostrarGrid(List<Alumno> alumnos)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = alumnos;
        }

    }
}
