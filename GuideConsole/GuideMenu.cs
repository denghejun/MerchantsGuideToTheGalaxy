using dotNetExt;
using GuideConsole.GuideMenus;
using System;
using System.Linq;

namespace GuideConsole
{
    public abstract class GuideMenu
    {
        private static bool TryGetSelectedMenu(out GuideMenu selectedMenu)
        {
            var menus = new GuideMenu[] { new InputDataFromFileMenu(), new InputDataFromConsoleMenu(), new ExitMenu() };
            var contents = ToContents(menus);
            Console.WriteLine("--------------------- Guide To Galaxy ----------------------");
            Console.WriteLine(contents);
            Console.WriteLine("-------------------------------------------------------------");

            var input = Console.ReadLine();
            int id;
            selectedMenu = int.TryParse(input, out id) && id <= menus.Count() ? menus[id - 1] : null;
            if (selectedMenu == null)
            {
                Console.WriteLine("Please input valid menu number.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private static string ToContents(params GuideMenu[] menus)
        {
            if (menus.IsNullOrEmpty())
            {
                return string.Empty;
            }
            else
            {
                var contents = string.Empty;
                for (int i = 0; i < menus.Length; i++)
                {
                    menus[0].ID = i;
                    contents += $"{i + 1}. {menus[i].Content}{Environment.NewLine}";
                }

                return contents;
            }
        }

        private static void WaitAndClearScreen()
        {
            Console.WriteLine(Environment.NewLine + "Press any key to continue ...");
            Console.WriteLine(".............................................................");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Show()
        {
            while (true)
            {
                GuideMenu selectedMenu = null;
                if (!TryGetSelectedMenu(out selectedMenu))
                {
                    WaitAndClearScreen();
                    continue;
                }

                Console.Clear();
                Console.WriteLine(selectedMenu.Tips);
                Console.WriteLine("-------------------------------------------------------------");
                while (!selectedMenu.Do(Console.ReadLine()))
                {
                }

                WaitAndClearScreen();
            }
        }

        public int ID { get; set; }

        public virtual string Tips { get; }

        public abstract string Content { get; }

        public abstract bool Do(string input);
    }
}
