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
using System.Threading;
using System.Globalization;
using static Vueling.Common.Logic.Enumeraciones.Idioma;
using Vueling.Business.Logic.Interfaces;

namespace Vueling.Presentation.Winsite
{
    public partial class AlumnoForm : Form
    {
        private ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        private Alumno alumno;
        private IAlumnoBL alumnoBL;
        private ICrudBL alumnoBLCrud;
        SingletonListaJson listaAlumnosJson;
        SingletonListaXml listaAlumnosXml;

        public AlumnoForm()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
            alumnoBLCrud = new AlumnoBL();

            listaAlumnosJson = SingletonListaJson.Instance;
            listaAlumnosXml = SingletonListaXml.Instance;
            cargarDatosAlumnos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            LoadAlumnoData();
            Alumno alumnoRet;

            try
            {
                var formato = FormatoSeleccionadoCombo();
                switch (formato)
                {
                    case OpcTypeFile.Sql:
                        alumnoRet = alumnoBLCrud.Insert(alumno);
                        break;
                    default:
                        alumnoRet = alumnoBL.Add(alumno);
                        break;
                }
                ResetFieldForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Añadir Alumno", "Error Añadir Alumno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                var idAlumno = textId.Text == "" ? 0 : Convert.ToInt32(textId.Text);
                alumno.Id = idAlumno;
                Alumno alumnoSelect = alumnoBLCrud.SelectById(alumno);
                log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name + alumnoSelect.ToString());
                ResetFieldForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Select Alumno", "Error Select Alumno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                LoadAlumnoData();
                var alumnoRet = alumnoBLCrud.Update(alumno);
                ResetFieldForm();
                log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name + alumnoRet.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error Delete Alumno", "Error Delete Alumno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                var idAlumno = textId.Text == "" ? 0 : Convert.ToInt32(textId.Text);
                alumno.Id = idAlumno;
                var result = alumnoBLCrud.Delete(alumno);
                ResetFieldForm();
                log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name + result);
            }
            catch (Exception)
            {
                MessageBox.Show("Error Delete Alumno", "Error Delete Alumno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void LoadAlumnoData()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            alumno.Id = textId.Text == "" ? 0 : Convert.ToInt32(textId.Text);
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
                    this.ConfigViewFormNormal();
                    break;
                case OpcTypeFile.Json:
                    ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatJson);
                    this.ConfigViewFormNormal();
                    break;
                case OpcTypeFile.Xml:
                    ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatXml);
                    this.ConfigViewFormNormal();
                    break;
                case OpcTypeFile.Sql:
                    ConfigUtils.SetValorVarEnvironment(Properties.Resources.Formato, Properties.Resources.FormatSql);
                    this.ConfigViewFormCrud();
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
            var idioma = (OpcIdioma)Enum.Parse(typeof(OpcIdioma), (string)comboBox1.SelectedItem, true);

            switch (idioma)
            {
                case OpcIdioma.Catalan:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("CA-ES");
                    break;
                case OpcIdioma.Castellano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ES-ES");
                    break;
                case OpcIdioma.Ingles:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("EN-US");
                    break;
            }

            AsignarIdiomaForm();
        }

        private void AsignarIdiomaForm()
        {
            label1.Text = Resources.StringResources.label1;
            label2.Text = Resources.StringResources.label2;
            label3.Text = Resources.StringResources.label3;
            label4.Text = Resources.StringResources.label4;
            label5.Text = Resources.StringResources.label5;
            button1.Text = Resources.StringResources.button1;
            button2.Text = Resources.StringResources.button2;
            button3.Text = Resources.StringResources.button3;
            button4.Text = Resources.StringResources.button5;
            button5.Text = Resources.StringResources.button4;
            comboBox1.Text = Resources.StringResources.comboBox1;
            comboBox2.Text = Resources.StringResources.comboBox2;
            this.Text = Resources.StringResources.WindowTitle;
        }

        private void AlumnoForm_Load(object sender, EventArgs e)
        {
            AsignarIdiomaForm();
        }

        private void ConfigViewFormNormal()
        {
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
        }

        private void ConfigViewFormCrud()
        {
            button2.Visible = true;
            button3.Visible = true;
            button5.Visible = true;
        }
    }
}
