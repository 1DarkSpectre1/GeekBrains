using System;

namespace Less_3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // преданы баланс и тип
            Building test_Building = new(75, 15, 150, 5);
            Console.WriteLine("Название класса для теста test_Building.");
            Console.WriteLine("Номер дома: " + test_Building.IdBuilding.ToString() + "; Количество квартир: " + test_Building.CountOfApartments.ToString() + "; Количество этажей: " + test_Building.CountOfFloors.ToString() + "; Количество подьездов: " + test_Building.EntrancesCount.ToString() + "; Высота этажа: " + test_Building.HeightFloors.ToString() + "; Высота этажа: " + test_Building.HeightFloors.ToString() + "; Количество квартир в подьезде: " + test_Building.CountOfApartmentsInEntrance.ToString() + "; Количество квартир на этаже: " + test_Building.CountOfApartmentsInFloors.ToString() + ".");
          
        }
    }
}
