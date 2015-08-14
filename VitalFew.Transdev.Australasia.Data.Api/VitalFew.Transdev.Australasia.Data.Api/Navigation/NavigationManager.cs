using System.Collections.Generic;

using VitalFew.Transdev.Australasia.Data.Api.Navigation.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Navigation
{
    public class NavigationManager : INavigationManager
    {
        //TODO: Should read from navigation provider. righ now I am hardcoded userMenu
        public IReadOnlyList<UserMenu> GetMenus()
        {
            var userMenus = new List<UserMenu>();

            userMenus.Add(new UserMenu
            {
                DisplayName = "Main Menu",
                Name = "MainMenu",
                Items = new List<UserMenuItem>
                {
                    new UserMenuItem
                    {
                        Name="Home",
                        DisplayName="Home",
                        Icon="fa fa-home",
                        Url="#/",
                        Items = new List<UserMenuItem>()
                   }
                }
            });

            return userMenus;
        }
    }
}