using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public enum Operation // add, substract, multiply, divide
    {
        Add,
        Substract,
        Multiply,
        Divide
    }

    public enum State // number, calculate, add equal
    {
        AddNumber,
        AddCalculate,
        AddEqual
    }
    public class Model
    {
        // constant
        public const Char DOT = '.';
        public const string ZERO = "0.";
        public const int MAX_LENGTH = 2;
        public const int MIDDLE_LENGTH = 1;

        // variable
        private State _state;
        Stack<double> _numberStack = new Stack<double>();
        private bool _isDot = false;
        private string _displayNumber;
        Operation _operation;

        public Model()
        {
            Initialize();
        }

        // Init
        public void Initialize()
        {
            _state = State.AddNumber;
            _operation = Operation.Add;
            _numberStack.Clear();
            _isDot = false;
            _displayNumber = ZERO;
        }

        // Set number
        public void SetNumber()
        {
            _numberStack.Push(double.Parse(_displayNumber));
        }

        // Add
        public double GetSum()
        {
            if (_numberStack.Count == MAX_LENGTH)
            {
                _numberStack.Push(_numberStack.Pop() + _numberStack.Pop());
            }
            return _numberStack.Peek();
        }

        // Substract
        public double GetDifference()
        {
            if (_numberStack.Count == MAX_LENGTH)
            {
                _numberStack.Push(-_numberStack.Pop() + _numberStack.Pop());
            }
            return _numberStack.Peek();
        }

        // Multiply
        public double GetProduct()
        {
            if (_numberStack.Count == MAX_LENGTH)
            {
                _numberStack.Push(_numberStack.Pop() * _numberStack.Pop());
            }
            return _numberStack.Peek();
        }

        // Divide
        public double GetDivisionResult()
        {
            if (_numberStack.Count == MAX_LENGTH)
            {
                _numberStack.Push(1 / _numberStack.Pop() * _numberStack.Pop());
            }
            return _numberStack.Peek();
        }

        // Calculate
        public double GetResult()
        {
            _state = State.AddCalculate;
            switch (_operation)
            {
                case Operation.Add:
                    return GetSum();
                case Operation.Substract:
                    return GetDifference();
                case Operation.Multiply:
                    return GetProduct();
                case Operation.Divide:
                    return GetDivisionResult();
            }
            return 0;
        }

        // Equal calculate
        public void EqualOperation()
        {
            if (_numberStack.Count == MIDDLE_LENGTH)
            {
                SetNumber();
            }
            if (_numberStack.Count == MAX_LENGTH) 
            {
                double top = _numberStack.Peek();
                double result = GetResult();
                _displayNumber = result.ToString();
                CheckDisplayNumberHaveDot();
                _numberStack.Push(top);
            }
            else
            {
                _state = State.AddEqual;
            }
        }

        // change display number
        public void ChangeDisplayNumber(string number)
        {
            if (_numberStack.Count == MAX_LENGTH)
            {
                _numberStack.Clear();
            }
            _displayNumber = _state != State.AddNumber ? ZERO : _displayNumber;
            _state = State.AddNumber;
            AddNumberOnDisplayNumber(number);
        }

        // check add number on displaynumber
        public void AddNumberOnDisplayNumber(string number)
        {
            if (_isDot)
            {
                _displayNumber += number;
            }
            else
            {
                if (_displayNumber == ZERO)
                {
                    _displayNumber = number + DOT;
                }
                else
                {
                    _displayNumber = _displayNumber.Substring(0, _displayNumber.Length - 1) + number + DOT;
                }
            }
        }

        // get display number
        public string GetDisplayNumber()
        {
            return _displayNumber;
        }

        // next calculate
        public void Calculate(string number, Operation operation)
        {
            _isDot = false;
            if (_numberStack.Count == MAX_LENGTH)
            {
                _numberStack.Pop();
            }
            else if (_state != State.AddCalculate)
            {
                SetNumber();
                _displayNumber = GetResult().ToString();
                CheckDisplayNumberHaveDot();
            }
            _operation = operation;
        }

        // clear input operation
        public void ClearInput()
        {
            SetIsDot(false);
            _displayNumber = ZERO;
        }

        // check display number have dot
        private void CheckDisplayNumberHaveDot()
        {
            if (!_displayNumber.Contains(DOT))
            {
                _displayNumber += DOT;
            }
        }

        // set isdot
        public void SetIsDot(bool isDot)
        {
            _isDot = isDot;
            _displayNumber = _state != State.AddNumber ? ZERO : _displayNumber;
        }
    }
}
