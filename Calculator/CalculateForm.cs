using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class CalculateForm : Form
    {
        private Model _model;
        
        public CalculateForm(Model model)
        {
            InitializeComponent();
            this._model = model;
        }

        // click number button
        private void ClickNumberButton(object sender, EventArgs e)
        {
            string number = ((Button)sender).Text;
            _model.ChangeDisplayNumber(number);
            _inputBox1.Text = _model.GetDisplayNumber();
        }

        // click add button
        private void ClickAddButton(object sender, EventArgs e)
        {
            string number = _inputBox1.Text;
            _model.Calculate(number, Operation.Add);
            _inputBox1.Text = _model.GetDisplayNumber();
        }

        // click substract button
        private void ClickSubstractButton(object sender, EventArgs e)
        {
            string number = _inputBox1.Text;
            _model.Calculate(number, Operation.Substract);
            _inputBox1.Text = _model.GetDisplayNumber();
        }

        // click multiply button
        private void ClickMultiplyButton(object sender, EventArgs e)
        {
            string number = _inputBox1.Text;
            _model.Calculate(number, Operation.Multiply);
            _inputBox1.Text = _model.GetDisplayNumber();
        }

        // click divide button
        private void ClickDivideButton(object sender, EventArgs e)
        {
            string number = _inputBox1.Text;
            _model.Calculate(number, Operation.Divide);
            UpdateDisplayNumber();
        }

        // click clear button
        private void ClickClearButton(object sender, EventArgs e)
        {
            _model.Initialize();
            _inputBox1.Text = _model.GetDisplayNumber();
            UpdateDisplayNumber();
        }

        // click equal
        private void ClickEqualButton(object sender, EventArgs e)
        {
            _model.EqualOperation();
            UpdateDisplayNumber();
        }

        // click clear entry
        private void ClickClearEntryButton(object sender, EventArgs e)
        {
            _model.ClearInput();
            UpdateDisplayNumber();
        }

        // click dot button
        private void ClickDotButton(object sender, EventArgs e)
        {
            _model.SetIsDot(true);
            UpdateDisplayNumber();
        }

        // update display number
        private void UpdateDisplayNumber()
        {
            _inputBox1.Text = _model.GetDisplayNumber();
        }
    }
}
