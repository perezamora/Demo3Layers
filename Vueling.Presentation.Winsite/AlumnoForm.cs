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
using Vueling.Common.Logic.Util;

namespace Vueling.Presentation.Winsite
{
    public partial class AlumnoForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Alumno alumno;
        private IAlumnoBL alumnoBL;

        public AlumnoForm()
        {
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
            cargarDatosAlumnos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar button1_Click");
            ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatTxt);
            LoadAlumnoData();
            ResetFieldForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar button2_Click");
            ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatJson);
            LoadAlumnoData();
            ResetFieldForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar button2_Click");
            ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatXml);
            LoadAlumnoData();
            ResetFieldForm();
        }

        private void LoadAlumnoData()
        {
            log.Debug("Entrar LoadAlumnoData: ");
            alumno.Id = Convert.ToInt32(textId.Text);
            alumno.Name = textNombre.Text;
            alumno.Apellidos = textApellidos.Text;
            alumno.Dni = textDni.Text;
            var lfechaNac = textFechaNac.Text.Split('-');
            alumno.FechaNac = new DateTime(Convert.ToInt32(lfechaNac[2]), Convert.ToInt32(lfechaNac[1]), Convert.ToInt32(lfechaNac[0]));
            alumnoBL.Add(alumno);
            log.Debug("Salir LoadAlumnoData: " + alumno.ToString());
        }

        private void ResetFieldForm()
        {
            textId.Text = "";
            textNombre.Text = "";
            textApellidos.Text = "";
            textDni.Text = "";
            textFechaNac.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            log.Debug("Entrar button4_Click");
        }

        private void cargarDatosAlumnos()
        {
            log.Debug("Entrar cargarDatosAlumnos");
            List<Alumno> listAlumnos = alumnoBL.GetAlumnos();
            log.Debug(listAlumnos);
        }
    }
}
