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
        
        private readonly int _numAcc;
        private double _balance;
        private readonly type_acc _typeAcc;
        private static int _globalnum = 1;

        public Acc( double balance, type_acc typeAcc)
        {
            this._numAcc = this.generateNumAcc;
            this._balance = balance;
            this._typeAcc = typeAcc;
        }
        public Acc(double balance)
        {
            this._numAcc = this.generateNumAcc;
            this._balance = balance;
            this._typeAcc = type_acc.Кредит;
        }
        public Acc(type_acc typeAcc)
        {
            this._numAcc = this.generateNumAcc;
            this._balance = 0.0;
            this._typeAcc = typeAcc;
        }
        public Acc()
        {
            this._numAcc = this.generateNumAcc;
            this._balance = 0.0;
            this._typeAcc = type_acc.Кредит;
        }
        private int generateNumAcc => _globalnum++;
        public double Balance { get => _balance; set => _balance = value; }   
        public int NumAcc => _numAcc;
        public type_acc TypeAcc => _typeAcc;
        /// <summary>
        /// метод снятия средсв
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Возвращает -1 при неудаче и 1 при успехе</returns>
        public int TakeAcc(double value)
        {
            if (_balance < value)
            {
                return -1;
            }
            _balance -= value;
            return 1;
        }
        /// <summary>
        /// Метод внесения средств на счёт
        /// </summary>
        /// <param name="value"></param>
        public void DepositAcc(double value)
        {
            
            _balance += value;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="acc"> номер счёта с которого переводят деньги</param>
        /// <param name="value">сумма перевода</param>
        public void MoneyTransfer(Acc acc,double value)
        {
            if (acc.TakeAcc(value) == 1)
            {
                _balance += value;
            } 
        }
        
    }
}
