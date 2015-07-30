using System.Text;
using VitalFew.Transdev.Australasia.DataPublisher.Navigation.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Navigation
{
    public class NavigationScriptManager : INavigationScriptManager
    {
        private readonly INavigationManager _userNavigationManager;

        public NavigationScriptManager(INavigationManager userNavigationManager)
        {
            _userNavigationManager = userNavigationManager;
        }
        
        public string GetScript()
        {
            var userMenus = _userNavigationManager.GetMenus();

            var sb = new StringBuilder();
            sb.AppendLine("(function() {");

            sb.AppendLine("    vtad.nav = {};");
            sb.AppendLine("    vtad.nav.menus = {");

            for (var i = 0; i < userMenus.Count; i++)
            {
                AppendMenu(sb, userMenus[i]);
                if (userMenus.Count - 1 > i)
                {
                    sb.Append(" , ");
                }
            }

            sb.AppendLine("    };");

            sb.AppendLine("})();");

            return sb.ToString();
        }

        private static void AppendMenu(StringBuilder sb, UserMenu menu)
        {
            sb.AppendLine("        '" + menu.Name + "': {");

            sb.AppendLine("            name: '" + menu.Name + "',");

            if (menu.DisplayName != null)
            {
                sb.AppendLine("            displayName: '" + menu.DisplayName + "',");
            }

            sb.Append("            items: ");

            if (menu.Items.Count <= 0)
            {
                sb.AppendLine("[]");
            }
            else
            {
                sb.Append("[");
                for (var i = 0; i < menu.Items.Count; i++)
                {
                    AppendMenuItem(16, sb, menu.Items[i]);
                    if (menu.Items.Count - 1 > i)
                    {
                        sb.Append(" , ");
                    }
                }
                sb.AppendLine("]");
            }

            sb.AppendLine("            }");
        }

        private static void AppendMenuItem(int indentLength, StringBuilder sb, UserMenuItem menuItem)
        {
            sb.AppendLine("{");

            sb.AppendLine(new string(' ', indentLength + 4) + "name: '" + menuItem.Name + "',");

            if (!string.IsNullOrEmpty(menuItem.Icon))
            {
                sb.AppendLine(new string(' ', indentLength + 4) + "icon: '" + menuItem.Icon.Replace("'", @"\'") + "',");
            }

            if (!string.IsNullOrEmpty(menuItem.Url))
            {
                sb.AppendLine(new string(' ', indentLength + 4) + "url: '" + menuItem.Url.Replace("'", @"\'") + "',");
            }

            if (menuItem.DisplayName != null)
            {
                sb.AppendLine(new string(' ', indentLength + 4) + "displayName: '" + menuItem.DisplayName.Replace("'", @"\'") + "',");
            }

            sb.Append(new string(' ', indentLength + 4) + "items: [");

            for (var i = 0; i < menuItem.Items.Count; i++)
            {
                AppendMenuItem(24, sb, menuItem.Items[i]);
                if (menuItem.Items.Count - 1 > i)
                {
                    sb.Append(" , ");
                }
            }

            sb.AppendLine("]");

            sb.Append(new string(' ', indentLength) + "}");
        }
    }
}