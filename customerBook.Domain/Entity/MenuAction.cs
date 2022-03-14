using customerBook.Domain.Common;

namespace customerBook.Domain.Entity
{
    public class MenuAction : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public MenuAction(int id, string name, string text)
        {
            Id = id;
            Name = name;
            Text = text;
        }
    }
}
