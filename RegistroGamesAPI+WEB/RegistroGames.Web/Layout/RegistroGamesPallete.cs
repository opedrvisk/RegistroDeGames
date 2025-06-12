using MudBlazor;
using MudBlazor.Utilities;

namespace ScreenSound.Web.Layout;

public class RegistroGamesPallete : PaletteDark
{
    private RegistroGamesPallete()
    {
        Primary = new MudColor("#9966FF");
        Secondary = new MudColor("#F6AD31");
        Tertiary = new MudColor("#8AE491");
    }

    public static RegistroGamesPallete CreatePallete => new();
}
