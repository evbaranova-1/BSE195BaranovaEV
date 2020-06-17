using BookstoreLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BSE195BaranovaEV
{
    [DataContract]
    [KnownType(typeof(Product)), KnownType(typeof(Book))]
    public class Bookstore<T> : IEnumerable<T> where T : Product
    {
        [DataMember]
        private List<T> items;
        public Bookstore()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }
        public void Remove()
        {
            items.RemoveAt(items.Count -1);
        }


        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
