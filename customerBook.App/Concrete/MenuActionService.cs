using customerBook.App.Common;
using customerBook.Domain.Entity;

namespace customerBook.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionByName(string name)
        {
            List<MenuAction> resoult = new List<MenuAction>();
            foreach (MenuAction menu in Items)
            {
                if (menu.Name == name)
                {
                    resoult.Add(menu);
                }
            }

            return resoult;
        }

        public void ViewMenuByName(string name)
        {
            List<MenuAction> resoult = GetMenuActionByName(name);

            foreach (MenuAction menuItem in resoult)
            {
                Console.WriteLine($"{menuItem.Id}. {menuItem.Text}");
            }
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Main", "View all customers/person/company"));
            AddItem(new MenuAction(2, "Main", "View selected customer"));
            AddItem(new MenuAction(3, "Main", "Add customer"));
            AddItem(new MenuAction(4, "Main", "Delete customer"));
            AddItem(new MenuAction(5, "Main", "Exit"));

            AddItem(new MenuAction(1, "AddCustomer", "Company"));
            AddItem(new MenuAction(2, "AddCustomer", "Person"));

            AddItem(new MenuAction(1, "ViewCustomer", "Company"));
            AddItem(new MenuAction(2, "ViewCustomer", "Person"));
            AddItem(new MenuAction(3, "ViewCustomer", "All"));
        }
    }
}
