using System.Collections;

namespace blog_api.Models
{
    public class CommentList : IList<IComment>
    {
        private IComment?[] _items;
        private static readonly IComment[] _empty = new IComment[4];
        public CommentList()
        {
            _items = _empty;
            count = 0;
        }
        public CommentList(IEnumerable<IComment> items)
        {
            _items = new IComment[items.Count()];
            count = items.Count();
            items.ToArray().CopyTo(_items, 0);
        }
        public IComment? this[int index]
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

        public void Add(IComment item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IComment item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IComment[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IComment> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(IComment item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IComment item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IComment item)
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
