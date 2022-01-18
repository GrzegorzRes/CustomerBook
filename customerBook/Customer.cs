using System;


namespace customerBook
{
    public abstract class Customer
    {
        
        public int Id { get; set; }
        public Location Loc { get; set; }
        public virtual void View()
        {
            Loc.View();
        }
    }
}
