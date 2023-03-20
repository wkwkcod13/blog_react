using System.Collections;

namespace blog_api.Models
{
    public class ComentList : IList<IComent>
    {
        private IComent?[] _items;
        private static readonly IComent[] _empty = new IComent[4];
        public ComentList()
        {
            _items = _empty;
            count = 0;
        }
        public ComentList(IEnumerable<IComent> items)
        {
            _items = new IComent[items.Count()];
            count = items.Count();
            items.ToArray().CopyTo(_items, 0);
        }
        public IComent? this[int index]
        {
            get
            {
                if (index > count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _items[index];
            }
            set
            {
                if (index > count)
                {
                    throw new IndexOutOfRangeException();
                }
                _items[index] = value;
            }
        }
        private int count;
        public int Count => count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(IComent item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IComent item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IComent[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IComent> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(IComent item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IComent item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IComent item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
