# MvcStyleFormComponents

A lightweight Razor component library that allows Blazor Server or MVC-integrated Razor components to use familiar MVC-style HTML form patterns — including `method`, `action`, `controller`, and automatic antiforgery support, plus a component that works like < a > tag. 

## 📦 Installation

You can install the package via NuGet:

```bash
dotnet add package MvcStyle
```

- **In the Program.cs add the namespace MvcStyle.ServiceCollection**
    - Write builder.Services.AddMvcStyle();

- **In the the folder or Project that you created your razor components**
    - Create a file named _Imports.razor and write on the top "@using MvcStyle.Components" so all you razor file are aware of this namespace


## ✨ Features

✅ MVC-style < form >  rendering with method, action, controller, and routeId

✅ MVC-style < a >  rendering with action, controller, and (optional) routeId

✅ Automatically generates antiforgery tokens in the < form >

✅ Easy integration inside .cshtml or .razor views

✅ Customizable submit logic

## 🚀Usage Example
< FileForm method="post" action="SomeControllerAction" controller="Controller" routeId="@Model.Id">

    <input name="Email" @bind="employee.Email" />
    <button type="submit">Save</button>

< /FileForm>

< Nav action action="SomeControllerAction" controller="Controller" routeId="@Model.Id">

    SomeText

< /Nav>

Notice: In the Nav tag, the routeId parameter is optional, it's used in case you want to call a controller that has an integer type parameter.

## 🛡️ Antiforgery Support

**AntiForgeryMarkup = await AntiforgeryService.GenerateHiddenMarkupInput();**


## ⚙️ How it works
- **This component is meant to integrate with traditional MVC-style controllers. On submission:**

    - It generates a classic HTML form with a valid action URL (based on controller, action, and optional routeId)

    - It injects a hidden antiforgery token

    - When submitted, it performs a full-page POST to the corresponding controller action.

    - The controller must return a RedirectToAction to the cshtml that houses the component, to re-render the updated state

    - The form is submitted like a traditional form: there is no AJAX or JavaScript submission.
    
    - It can be used even with custom Endpoints

## ⚠️ Things to notice
-   **The form performs a full page reload on submission**

-   **The controller action should return a RedirectToAction(), to the View that houses the component**

- **Antiforgery token is included by default for safety so always use [ValidateAntiForgeryToken] above the HttpPost Controller Action. This way you can always use HttpPost and not HttpPut nor HttpPatch nor HttpDelete**