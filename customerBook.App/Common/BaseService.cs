using customerBook.App.Abstract;
using customerBook.Domain.Common;


namespace customerBook.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int AddItem(T item)
        {
            item.Id = GetLastId() + 1;
            Items.Add(item);
            return item.Id;
        }

        public int EditItem(T beforeEditItem, T afterEditItem)
        {
            RemoveItem(beforeEditItem);
            AddItem(afterEditItem);

            return afterEditItem.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public int GetLastId()
        {
            if (Items.Count == 0)
            {
                return 0;
            }

            int LastId = Items.Last().Id;
            return LastId;
        }
    }
}
