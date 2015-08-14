using System.Collections.Generic;

namespace VitalFew.Transdev.Australasia.Data.Api.Navigation.Contract
{
    public interface INavigationManager
    {
        IReadOnlyList<UserMenu> GetMenus();
    }
}
