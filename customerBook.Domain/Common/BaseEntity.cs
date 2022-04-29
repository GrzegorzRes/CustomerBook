

namespace customerBook.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity()
        {
            Id = 0;
        }
        public BaseEntity(int id)
        {
            Id = id;
        }

    }
}
