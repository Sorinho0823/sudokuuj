using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuuj
{
    class sudokufield : Button

    {
        private bool _active;

        public bool Active
        {
            get { return _active; }
            set
            {

                _active = value;
                if (_active)
                {
                    Font = new Font(FontFamily.GenericSerif, 12);
                }
                else
                {
                    Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                }

            }
        }

        private int _value;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (_value < 0) { _value = 9; }
                if (_value > 9) { _value = 0; }
                if (_value == 0) { Text = ""; }
                else { Text = _value.ToString(); }
            }
        }


        public sudokufield()
        {
            Height = 30;
            Width = 30;
            BackColor = Color.White;
            Value = 0;
            MouseDown += Sudokufield_MouseDown;


        }

        private void Sudokufield_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Active) return;

            if (e.Button == MouseButtons.Left)
            {
                Value++;
            }
            if (e.Button == MouseButtons.Right)
            {
                Value--;
            }
        }
    }
}
