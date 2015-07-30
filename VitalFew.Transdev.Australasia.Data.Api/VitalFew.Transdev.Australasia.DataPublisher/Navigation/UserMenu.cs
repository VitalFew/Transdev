using System.Collections.Generic;

namespace VitalFew.Transdev.Australasia.DataPublisher.Navigation
{
    public class UserMenu
    {
        /// <summary>
        /// Unique name of the menu in the application. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name of the menu.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Menu items (first level).
        /// </summary>
        public IList<UserMenuItem> Items { get; set; }

        /// <summary>
        /// Creates a new <see cref="UserMenu"/> object.
        /// </summary>
        public UserMenu()
        {

        }
    }
}