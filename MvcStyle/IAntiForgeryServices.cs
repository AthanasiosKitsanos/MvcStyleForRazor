using Microsoft.AspNetCore.Components;

namespace MvcStyle;

public interface IAntiForgeryServices
{
    Task<MarkupString> GenerateHiddenMarkupInput();
}
