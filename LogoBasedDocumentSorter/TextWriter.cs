using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace LogoBasedDocumentSorter
{
    public class ControlWriter : TextWriter
    {


        private Control textbox;
        public ControlWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            textbox.BeginInvoke(new Action(()=> { ((TextBox)textbox).AppendText(value.ToString()); }));
        }

        public override void Write(string value)
        {
            textbox.BeginInvoke(new Action(() => { ((TextBox)textbox).AppendText(value); }));
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
