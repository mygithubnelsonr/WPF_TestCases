using System.Collections;

namespace UsingCollectionBase
{
    public class Addresses : CollectionBase, IEnumerable
    {
        public void Add(Address item)
        {
            this.Add(item);
        }

        public void AddRange(Address[] items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Insert(int index, Address item)
        {
            this.Insert(index, item);
        }

        public void Remove(Address item)
        {
            this.Remove(item);
        }

        //public override void Clear()
        //{
        //    MyBase.Clear();
        //}

        public int IndexOf(Address item)
        {
            return this.IndexOf(item);
        }
    }
}
