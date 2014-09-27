using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TreeBeard.Gui.Controls
{
    public partial class ConsoleControl : UserControl
    {
        TextWriter _writer = null;

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
