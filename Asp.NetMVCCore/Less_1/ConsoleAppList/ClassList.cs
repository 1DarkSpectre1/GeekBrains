using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppList
{
    class ClassList<T>:List<T>
    {
        public T _value { get; set; }
        public List<T> list = new List<T>();
        public new void Add(T item)
        {
            lock(list)
                list.Add(item);
        }
        public new void Remove(T item)
        {
            lock (list)
                list.Remove(item);
        }

    }
}
