using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerBook
{
    public class MenuActionService
    {
        public List<MenuAction> menuActions;

        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        public List<MenuAction> GetMenuActionByName(string name)
        {
            List<MenuAction> resoult = new List<MenuAction>();
            foreach (var menu in menuActions)
            {
                if (menu.Name == name)
                {
                    resoult.Add(menu);
                }
            }

            return resoult;
        }

        public void AddMenuAction(int id, string name, string text)
        {
            MenuAction menuAction = new MenuAction() { Id = id, Name= name, Text = text};
            menuActions.Add(menuAction);
        }
    }
}
