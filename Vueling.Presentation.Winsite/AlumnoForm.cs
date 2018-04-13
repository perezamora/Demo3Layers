using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Singletons;
using Vueling.Common.Logic.Util;
using Vueling.Common.Logic;
using static Vueling.Common.Logic.TypeFileEnum;
using static Vueling.Common.Logic.Enumeraciones.Accion;

namespace Vueling.Presentation.Winsite
{
    public partial class AlumnoForm : Form
    {
        private ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        private Alumno alumno;
        private IAlumnoBL alumnoBL;
        SingletonListaJson listaAlumnosJson;
        SingletonListaXml listaAlumnosXml;

        public AlumnoForm()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
            listaAlumnosJson = SingletonListaJson.Instance;
            listaAlumnosXml = SingletonListaXml.Instance;
            cargarDatosAlumnos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            LoadAlumnoData();
            Alumno alumnoRet = alumnoBL.Add(alumno);
            ResetFieldForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatTxt);
            AlumnosShowForm formShow = new AlumnosShowForm();
            formShow.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void LoadAlumnoData()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            alumno.Id = Convert.ToInt32(textId.Text);
            alumno.Name = textNombre.Text;
            alumno.Apellidos = textApellidos.Text;
            alumno.Dni = textDni.Text;
            alumno.FechaNac = textFechaNac.Value;
        }

        private void ResetFieldForm()
        {
            textId.Text = "";
            textNombre.Text = "";
            textApellidos.Text = "";
            textDni.Text = "";
            textFechaNac.Text = "";
        }

        private void cargarDatosAlumnos()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            CargarDatosAlumnosJson();
            CargarDatosAlumnosXml();
        }

        private void CargarDatosAlumnosJson()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatJson);
                listaAlumnosJson.ListaAlumnos = alumnoBL.GetAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error cargar datos alumnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosAlumnosXml()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatXml);
                listaAlumnosXml.ListaAlumnos = alumnoBL.GetAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargar datos alumnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var formato = FormatoSeleccionadoCombo();
            switch (formato)
            {
                case OpcTypeFile.Txt:
                    ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatTxt);
                    break;
                case OpcTypeFile.Json:
                    ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatJson);
                    break;
                case OpcTypeFile.Xml:
                    ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatXml);
                    break;
                case OpcTypeFile.Sql:
                    ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatSql);
                    break;
            }
        }

        private OpcTypeFile FormatoSeleccionadoCombo()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var index = comboBox2.SelectedIndex;
            var formato = comboBox2.Items[index].ToString() ?? ConfigUtils.GetValorVarEnvironment(Properties.Resources.Formato);
            return (OpcTypeFile)Enum.Parse(typeof(OpcTypeFile), formato.ToString(), true);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var idioma = IdiomaSeleccionadoCombo();
            log.Debug(idioma);
        }

        private string IdiomaSeleccionadoCombo() => (string)comboBox1.SelectedValue ?? Resources.ConfigRes.castellano;

    }
}
