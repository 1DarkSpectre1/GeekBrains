using System;

namespace less_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Acc acc = new(13, 23.54, type_acc.Кредит);
            Console.WriteLine("Номер счёта: "+Convert.ToString(acc.NumAcc)+"; Баланс: "+ Convert.ToString(acc.Balance) + "; Тип счёта: " + Convert.ToString(acc.TypeAcc)+".");
        }
    }
}
