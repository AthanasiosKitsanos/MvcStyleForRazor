using Microsoft.AspNetCore.Components;

namespace MvcStyleForRazor;

public interface IAntiForgeryServices
{
    Task<MarkupString> GenerateHiddenMarkupInput();
}
