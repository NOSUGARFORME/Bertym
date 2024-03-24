using Bertym.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bertym.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private List<MenuItem> _menuItems = new()
        {
            new() { Controller="Home", Action="Index", Text="Lab 2"},
            new() { Controller="Product", Action="Index", Text="Каталог"},
            new() { IsPage=true, Area="Admin", Page="/Index",
                //Controller="Home", Action="Index", 
                Text="Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            //Получение значений сегментов маршрута
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];
            foreach (var item in _menuItems)
            {
                // Название контроллера совпадает?
                var _matchController = controller?.Equals(item.Controller) ?? false;
                // Название зоны совпадает?
                var _matchArea = area?.Equals(item.Area) ?? false;
                // Если есть совпадение, то сделать элемент меню активным
                // (применить соответствующий класс CSS)
                if (_matchController || _matchArea)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }
}
