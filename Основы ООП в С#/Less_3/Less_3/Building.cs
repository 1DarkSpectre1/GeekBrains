using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_3
{
    class Building
    {
        private int _ID_Building;
        private double _height_Building;
        private int _count_of_floors;
        private int _count_of_apartments;
        private int _entrances_count;
        private static int _globalnum = 1;

        public Building(double height_Building, int count_of_floors, int count_of_apartments, int entrances_count)
        {
            if (!IsFloorsCountValid(count_of_floors))
                throw new ArgumentException("Некорректное число этажей.");
            if (!IsApartmentsCountValid(count_of_apartments))
                throw new ArgumentException("Некорректное число квартир.");
            if (!IsEntrancesCountValid(entrances_count))
                throw new ArgumentException("Некорректное число подьездов.");
            if (!IsBuildingValueValid(count_of_floors, count_of_apartments, entrances_count))
                throw new ArgumentException("Некорректные значения для квартир, подьездов, этажей. На каждом этаже и в каждом подьезде равное количество квартир.");

            this._ID_Building = this.generateIdBuilding;
            this._height_Building = height_Building;
            this._count_of_floors = count_of_floors;
            this._count_of_apartments = count_of_apartments;
            this._entrances_count = entrances_count;
        }
        private bool IsBuildingValueValid(int count_of_floors, int count_of_apartments, int entrances_count)
        {
            if (count_of_apartments % count_of_floors == 0 && count_of_apartments % entrances_count == 0)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsFloorsCountValid(int count_of_floors)
        {
            if (count_of_floors.GetTypeCode() == TypeCode.Int32 && count_of_floors > 0 && count_of_floors < 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsApartmentsCountValid(int count_of_apartments)
        {
            if (count_of_apartments.GetTypeCode() == TypeCode.Int32 && count_of_apartments > 0 && count_of_apartments < 2000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsEntrancesCountValid(int entrances_count)
        {
            if (entrances_count.GetTypeCode() == TypeCode.Int32 && entrances_count > 0 && entrances_count < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         
        private int generateIdBuilding => _globalnum++;
        public double Height  => _height_Building;
        public int IdBuilding => _ID_Building;
        public int CountOfFloors => _count_of_floors;
        public int CountOfApartments => _count_of_apartments;
        public int EntrancesCount => _entrances_count;
        public double HeightFloors => _height_Building / _count_of_floors;
        public int CountOfApartmentsInEntrance => _count_of_apartments/_entrances_count;
        public int CountOfApartmentsInFloors => _count_of_apartments / _count_of_floors;
    }
}
