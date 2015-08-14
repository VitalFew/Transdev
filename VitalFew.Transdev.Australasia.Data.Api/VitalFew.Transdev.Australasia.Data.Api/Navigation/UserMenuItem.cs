using System.Collections.Generic;

namespace VitalFew.Transdev.Australasia.Data.Api.Navigation
{
    public class UserMenuItem
    {
        /// <summary>
        /// Unique name of the menu item in the application. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Icon of the menu item if exists.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Display name of the menu item.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The URL to navigate when this menu item is selected.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Sub items of this menu item.
        /// </summary>
        public IList<UserMenuItem> Items { get; set; }

        /// <summary>
        /// Creates a new <see cref="UserMenuItem"/> object.
        /// </summary>
        public UserMenuItem()
        {

        }
    }
}