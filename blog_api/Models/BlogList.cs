using System.Collections;
using System.Linq;

namespace blog_api.Models
{
    public class BlogList<T> : IEnumerable<T>, IList where T : class, IBlog
    {
        private T?[] _items;
        private static readonly T[] _empty = new T[4];
        public BlogList()
        {
            _items = _empty;
            count = 0;
        }
        public BlogList(IEnumerable<T> collection)
        {
            _items = new T[collection.Count()];
            count = collection.Count();
            collection.ToArray().CopyTo(_items, 0);
        }
        public object? this[int index]
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _items[index];
            }
            set
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                _items[index] = (T?)value;
            }
        }
        private int count;
        public int Count => count;

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public int Add(object? value)
        {
            if (count == _items.Length)
            {
                Array.Resize(ref _items, count * 2);
            }
            _items[count++] = (T?)value;
            return count - 1;
        }

        public void Clear()
        {
            _items = new T[4];
            count = 0;
        }

        public bool Contains(object? value)
        {
            return IndexOf(value) != -1;
        }

        public void CopyTo(Array array, int index)
        {
            Array.Copy(_items, 0, array, index, count);
        }

        public int IndexOf(object? value)
        {
            for (int i = 0; i < count; i++)
            {
                if (object.Equals(_items[i], value))
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexById(string Id)
        {
            for (int i = 0; i < count; i++)
            {
                if ((_items[i] as Blog)?.BlogId == Id)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Insert(int index, object value)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (count == _items.Length)
            {
                Array.Resize(ref _items, count * 2);
            }
            Array.Copy(_items, index, _items, index + 1, count - index);
            _items[index] = (T)value;
            count++;
        }

        public void Remove(object value)
        {
            int index = IndexOf(value);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Array.Copy(_items, index + 1, _items, index, count - index - 1);
            count--;
            _items[count] = null;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return _items[i];
            }
        }
    }
}
