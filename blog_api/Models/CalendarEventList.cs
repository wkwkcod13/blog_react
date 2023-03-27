using System.Collections;
using System.Collections.Generic;

namespace blog_api.Models
{
    public class CalendarEventList : IList<ICalendarEvent>
    {
        public ICalendarEvent this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private int count;
        public int Count => count;
        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(ICalendarEvent item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ICalendarEvent item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ICalendarEvent[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ICalendarEvent> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(ICalendarEvent item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, ICalendarEvent item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ICalendarEvent item)
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
