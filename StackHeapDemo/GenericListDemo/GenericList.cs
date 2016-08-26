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
            return (IEnumerator)this;
        }

        public GenericList()
        {
            array = new T[16];
        }

        void IncreaseCapacity()
        {
            var tempArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            array = tempArray;
        }

        public void Add(T value)
        {
            if (count + 1 >= array.Length)
            {
                IncreaseCapacity();
            }
            array[count++] = value;
        }

        public void Remove(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                {
                    int index = i;
                    RemoveAt(index);

                    break;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();
            else
            {
                for (int i = index + 1; i <= Count; i++)
                {
                    array[i - 1] = array[i];
                }
                --count;
            }
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

        public int Count
        {
            get
            {
                return count;
            }
        }

        private int count;

        private T[] array;
    }
}
