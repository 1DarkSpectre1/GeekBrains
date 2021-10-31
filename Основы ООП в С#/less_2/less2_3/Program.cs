using System;

namespace less2_3
{
    
    class Program
    {
        public static int globalnum = 0;
        static void Main(string[] args)
        {
            Acc acc = new(23.54, type_acc.Кредит);
            Console.WriteLine("Номер счёта: " + Convert.ToString(acc.NumAcc) + "; Баланс: " + Convert.ToString(acc.Balance) + "; Тип счёта: " + Convert.ToString(acc.TypeAcc) + ".");
            Acc newacc = new( type_acc.Кредит);
            Console.WriteLine("Номер счёта: " + Convert.ToString(newacc.NumAcc) + "; Баланс: " + Convert.ToString(newacc.Balance) + "; Тип счёта: " + Convert.ToString(newacc.TypeAcc) + ".");
        }
        
    }
    enum type_acc
    {
        Кредит,
        Накопительный
    }


    class Acc
    {
        private static int _globalnum;
        private readonly int _numAcc;
        private double _balance;
        private readonly type_acc _typeAcc;
        

        public Acc(double balance, type_acc typeAcc)
        {
            this._numAcc = generateNumAcc();
            this._balance = balance;
            this._typeAcc = typeAcc;
        }
        public Acc(double balance)
        {
            this._numAcc = generateNumAcc();
            this._balance = balance;
            this._typeAcc = type_acc.Кредит;
        }
        public Acc(type_acc typeAcc)
        {
            this._numAcc = generateNumAcc();
            this._balance = 0.0;
            this._typeAcc = typeAcc;
        }
        //private int generateNumAcc => _globalnum++;
        public static int generateNumAcc()
        {
            Program.globalnum = Program.globalnum + 1;
            return Program.globalnum;
        }

        public double Balance { get => _balance; set => _balance = value; }

        public int NumAcc => _numAcc;

        public type_acc TypeAcc => _typeAcc;

    }
}
