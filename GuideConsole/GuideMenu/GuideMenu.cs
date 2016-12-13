using dotNetExt;
using GuideToTheGalaxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GuideConsole.GuideMenu
{
    public abstract class GuideMenu
    {
        public int ID { get; set; }
        public virtual string Tips { get; }
        public abstract string Content { get; }
        public abstract bool Do(string input);

        private static bool TryGetSelectedMenu(out GuideMenu selectedMenu)
        {
            var menus = new GuideMenu[] { new InputDataFromFileMenu(), new InputDataFromConsoleMenu(), new ExitMenu() };
            var contents = ToContents(menus);
            Console.WriteLine(contents);
            var input = Console.ReadLine();
            int id;
            selectedMenu = int.TryParse(input, out id) && id <= menus.Count() ? menus[id - 1] : null;
            return selectedMenu != null;
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
        public static void Show()
        {
            while (true)
            {
                GuideMenu selectedMenu = null;
                if (!TryGetSelectedMenu(out selectedMenu))
                {
                    Console.WriteLine("Please input valid menu number.");
                    continue;
                }

                Console.WriteLine(selectedMenu.Tips);
                while (!selectedMenu.Do(Console.ReadLine()))
                {
                }

                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
