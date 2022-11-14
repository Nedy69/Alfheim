using Avalonia.Web.Blazor;

namespace Alfheim.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<Alfheim.App>()
            .SetupWithSingleViewLifetime();
    }
}