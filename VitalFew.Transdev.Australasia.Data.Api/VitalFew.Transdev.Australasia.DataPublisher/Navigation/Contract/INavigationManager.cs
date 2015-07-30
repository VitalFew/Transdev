using System.Collections.Generic;

namespace VitalFew.Transdev.Australasia.DataPublisher.Navigation.Contract
{
    public interface INavigationManager
    {
        IReadOnlyList<UserMenu> GetMenus();
    }
}
