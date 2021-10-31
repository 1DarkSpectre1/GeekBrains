using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace less_2
{
    enum type_acc
    {
        Кредит,
        Накопительный
    }
    class Acc
    {
        
        private int _numAcc;
        private double _balance;
        private type_acc _typeAcc;

        public Acc(int numAcc, double balance, type_acc typeAcc)
        {
            this._numAcc = numAcc;
            this._balance = balance;
            this._typeAcc = typeAcc;
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                this._balance = value;
            }
        }
        public int NumAcc
        {
            get
            {
                return this._numAcc;
            }
        }
        public type_acc TypeAcc
        {
            get
            {
                return this._typeAcc;
            }
        }
    }
}
