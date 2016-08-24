using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListDemo
{
    public class GenericList<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public GenericList()
        {
            array = new T[0];
        }

        public void Add(T value)
        {
            var tempArray = new T[Count + 1];
            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[Count] = value;
            array = tempArray;
        }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();
                else
                {
                    return (T)array[index];
                }
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();
                else
                {
                    array[index] = value;
                }
            }
        }

        public int Count {
            get
            {
                if (array == null)
                    throw new NullReferenceException("internal array has not instantiated.");
                else
                {
                    return array.Length;
                }
            }
        }

        private T[] array;
    }
}
