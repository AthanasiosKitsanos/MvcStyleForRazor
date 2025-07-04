using Microsoft.AspNetCore.Components;

namespace MvcStyle.Services;

public interface IAntiForgeryServices
{
    Task<MarkupString> GenerateHiddenMarkupInput();
}
