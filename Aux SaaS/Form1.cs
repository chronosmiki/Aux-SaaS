using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Aux_SaaS
{
    public partial class auxsaas : Form
    {
        public auxsaas()
        {
            InitializeComponent();
        }

        private void btnRodar_Click(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create("C:/ProgramData/TARGIT/ANTServer/VFS/Personal/SYS/Settings/Preferences.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element
                && reader.Name == "startup")
                {
                    MessageBox.Show("document = " + reader.GetAttribute(0));
                }
            }
        }

        private void btnEscrever_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.Load("C:/ProgramData/TARGIT/ANTServer/VFS/Personal/SYS/Settings/Preferences.xml");

            XmlNode xnode = xdoc.SelectSingleNode("/userpreferences/startup");

            MessageBox.Show(xnode.Value);

            xnode.Attributes[0].Value = "vfs://Global/Analysis Examples/1.1 Sales Performance.xview";

            xdoc.Save("C:/ProgramData/TARGIT/ANTServer/VFS/Personal/SYS/Settings/Preferences.xml");
        }
    }
}



