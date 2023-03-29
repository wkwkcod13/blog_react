using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections;
using System.Text.Json;
namespace blog_api.Models.Test
{
    public class MessageList : IList<IMessage>
    {
        private IMessage[] _items;
        private readonly IMessage[] _empty = new IMessage[4];
        public IMessage? this[int index]
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
                _items[index] = value;
            }
        }

        public MessageList()
        {
            _items = _empty;
            count = 0;
        }
        public MessageList(IEnumerable<IMessage> messages)
        {
            _items = new IMessage[messages.Count()];
            count = messages.Count();
            messages.ToArray().CopyTo(_items, 0);
        }

        private int count = 0;
        public int Count => count;

        public bool IsFixedSize => true;

        public bool IsReadOnly => false;

        public bool IsSynchronized => true;

        public object SyncRoot => true;

        public void Add(IMessage? message)
        {
            if (message is not IMessage)
            {
                throw new ArgumentException();
            }

            if (count == _items.Length)
            {
                Array.Resize(ref _items, count * 2);
            }
            _items[count++] = message;
        }

        public int IndexOf(IMessage item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IMessage item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IMessage item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IMessage[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IMessage item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<IMessage> IEnumerable<IMessage>.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return _items[i];
            }
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return _items[i];
            }
        }
    }
}
