using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TreeBeard.Gui.Controls
{
    public partial class ConsoleControl : UserControl
    {
        TextWriter _writer;

        public ConsoleControl()
        {
            InitializeComponent();

            _writer = new TextBoxStreamWriter(txtConsole);
            Console.SetOut(_writer);
        }

        public void Clear()
        {
            txtConsole.Clear();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_writer != null) _writer.Dispose();
                if (components != null) components.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            if (_output.InvokeRequired)
            {
              _output.Invoke((MethodInvoker)(() => _output.AppendText(value.ToString())));
            }
            else
            {
               _output.AppendText(value.ToString());
            }
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
