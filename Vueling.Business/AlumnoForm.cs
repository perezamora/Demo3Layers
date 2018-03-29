using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;

namespace Vueling.Business
{
    public partial class AlumnoForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Alumno alumno;
        private IAlumnoBL alumnoBL;

        public AlumnoForm()
        {
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("Button formato txt");
            GuardarVarEnv(Properties.Resources.FormatTxt);
            LoadAlumnoData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuardarVarEnv(Properties.Resources.FormatJson);
            LoadAlumnoData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GuardarVarEnv(Properties.Resources.FormatXml);
            LoadAlumnoData();
        }

        private void LoadAlumnoData()
        {
            log.Info("Guardar datos alumno");
            alumno.Id = Convert.ToInt32(textId.Text);
            alumno.Name = textNombre.Text;
            alumno.Apellidos = textApellidos.Text;
            alumno.Dni = textDni.Text;
            alumno.FechaNac = textFechaNac.Text;
            alumnoBL.Add(alumno);
        }

        private void GuardarVarEnv(string format)
        {
            log.Info("Guardar variable entorno");
            ConfigUtils.SetValorVarEnvironment(format);
        }
    }
}
