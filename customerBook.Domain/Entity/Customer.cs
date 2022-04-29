using customerBook.Domain.Common;

namespace customerBook.Domain.Entity
{
    public abstract class Customer : BaseEntity
    {
        public Location Loc { get; set; }

        public Customer()
        {
        }
        
        public virtual void View()
        {
            Loc.View();
        }

    }
}
