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

namespace Vueling.Presentation.Winsite
{
    public partial class AlumnoForm : Form
    {
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
            ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatTxt);
            LoadAlumnoData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatJson);
            LoadAlumnoData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfigUtils.SetValorVarEnvironment(Properties.Resources.FormatXml);
            LoadAlumnoData();
        }

        private void LoadAlumnoData()
        {
            alumno.Id = Convert.ToInt32(textId.Text);
            alumno.Name = textNombre.Text;
            alumno.Apellidos = textApellidos.Text;
            alumno.Dni = textDni.Text;
            var lfechaNac = textFechaNac.Text.Split('-');
            alumno.FechaNac = new DateTime(Convert.ToInt32(lfechaNac[2]), Convert.ToInt32(lfechaNac[1]), Convert.ToInt32(lfechaNac[0]));
            LogUtilSer.WriteInfoSerilog("Capa presentacion, " + alumno.ToString());
            LogUtil.WriteInfoLog("Prueba de log4net");
            alumnoBL.Add(alumno);
        }

    }
}
