using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeStore.Classes
{
    public static class ExtensionMethods
    {

        public static SelectList ToSelectList<TEnum>(this TEnum obj, object selectedValue)
   where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text", selectedValue);
        }
    }
}
