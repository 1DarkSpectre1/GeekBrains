using System;

namespace less_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int ret;
            // преданы баланс и тип
            Acc test_acc_balance_type = new(23.54, type_acc.Накопительный);
            Console.WriteLine("Название класса для теста test_acc_balance_type ");
            Console.WriteLine("Номер счёта: " + Convert.ToString(test_acc_balance_type.NumAcc)+"; Баланс: "+ Convert.ToString(test_acc_balance_type.Balance) + "; Тип счёта: " + Convert.ToString(test_acc_balance_type.TypeAcc)+".");
            ret = test_acc_balance_type.TakeAcc(30);
            if (ret == -1)
            {
                Console.WriteLine("На счёте недостаточно средств для выполнения операции");
                Console.WriteLine();
            }
            // предан тип
            Acc test_acc_type = new( type_acc.Накопительный);
            test_acc_type.DepositAcc(100);
            Console.WriteLine("Название класса для теста test_acc_type ");
            Console.WriteLine("Номер счёта: " + Convert.ToString(test_acc_type.NumAcc) + "; Баланс: " + Convert.ToString(test_acc_type.Balance) + "; Тип счёта: " + Convert.ToString(test_acc_type.TypeAcc) + ".");
            // предан баланс
            Acc test_acc_balance = new(23);
            Console.WriteLine("Название класса для теста test_acc_balance ");
            Console.WriteLine("Номер счёта: " + Convert.ToString(test_acc_balance.NumAcc) + "; Баланс: " + Convert.ToString(test_acc_balance.Balance) + "; Тип счёта: " + Convert.ToString(test_acc_balance.TypeAcc) + ".");
            // значения по умолчанию
            Acc test_acc_default = new();
            Console.WriteLine("Название класса для теста test_acc_default ");
            Console.WriteLine("Номер счёта: " + Convert.ToString(test_acc_default.NumAcc) + "; Баланс: " + Convert.ToString(test_acc_default.Balance) + "; Тип счёта: " + Convert.ToString(test_acc_default.TypeAcc) + ".");
        }
    }
}
