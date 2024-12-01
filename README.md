<img src="https://raw.githubusercontent.com/dwndland/Chapter.Net.BLZ.Navigation/master/Icon.png" alt="logo" width="64"/>

# Chapter.Net.BLZ.Navigation Library
Chapter.Net.BLZ.Navigation brings build in features to easy navigate through the application from viewmodels and display overlay popups easily.

## Overview

## Features
- **Navigate:** Navigates between pages from viewmodels.
- **Refresh:** Refreshes the current page.
- **ShowPopup:** Shows a popup.
- **ClosePopup:** Closes a popup from viewmodels.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.BLZ.Navigation library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.BLZ.Navigation
    ```

2. **Initialize the navigation service:**
    - In the IOC register the INavigationService and its dependencies.
    ```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSingleton<IRouteProvider, RouteProvider>();
    builder.Services.AddSingleton<IPopupStorage, PopupStorage>();
    builder.Services.AddScoped<INavigationService, NavigationService>();
    ```

3. **Register routes to navigate by keys:**
    - In the registered route provider, register a route by a key.
    ```csharp
    public enum ViewKeys
    {
        HomeView,
        LoginView,
        ConnectionErrorView
        SetupView
    }
    ```
    ```csharp
    var routeProvider = (RouteProvider)app.Services.GetRequiredService<IRouteProvider>();
    routeProvider.RegisterRoutes(ViewKeys.HomeView, "/");
    routeProvider.RegisterRoutes(ViewKeys.LoginView, "/login");
    routeProvider.RegisterRoutes(ViewKeys.ConnectionErrorView, "/connectionerror");
    routeProvider.RegisterRoutes(ViewKeys.SetupView, "/setup");
    ```

4. **Navigate between pages:**
    - Get the INavigationService injected and navigate to a page by its registered view.
    ```csharp
    public class HomeViewModel : ObservableObject, IViewModel
    {
        public async Task Load()
        {
            if (_setupService.NeedInitialize())
            {
                _navigationService.Navigate(ViewKeys.SetupView);
            }
        }
    }
    ```

5. **Show a popup overlay the main content from a viewmodel:**
    - Create a popup view and its viewmodel.  
    (In this demo the MVVM pattern is used from Chapter.Net.BLZ.)
    ```razor
    @inherits ViewModelComponent<DemoViewModel>

    <div class="button-group">
        <FluentButton>Yes</FluentButton>
        <FluentButton>No</FluentButton>
    </div>
    ```
    ```csharp
    public class DemoViewModel : ObservableObject, IViewModel
    {
    }
    ```
    - After button click, close the popup with a result.
    ```razor
    @inherits ViewModelComponent<DemoViewModel>

    <div class="button-group">
        <FluentButton OnClick="DataContext.Yes">Yes</FluentButton>
        <FluentButton OnClick="DataContext.No">No</FluentButton>
    </div>
    ```
    ```csharp
    public class DemoViewModel : ObservableObject, IViewModel
    {
        public void Yes()
        {
            _navigationService.ClosePopup(nameof(DemoView), true);
        }

        public void No()
        {
            _navigationService.ClosePopup(nameof(DemoView), false);
        }
    }
    ```
    - Define a spot where to show the popup.  
    (MainLayout.razor)
    ```razor
    @inherits LayoutComponentBase

    <FluentLayout>
        <NavigationPresenter ID="@("PopupLayer")" />
    </FluentLayout>
    ```
    - Show the popup ignoring any result.
    ```csharp
    public class MainViewModel : ObservableObject, IViewModel
    {
        public void ShowDemo()
        {
            _navigationService.ShowPopup<DemoView>("PopupLayer", nameof(DemoView));
        }
    }
    ```
    - Show the popup with receive its result.
    ```csharp
    public class MainViewModel : ObservableObject, IViewModel
    {
        public void ShowDemo()
        {
            var result = _navigationService.ShowPopup<DemoView, bool>("PopupLayer", nameof(DemoView));
        }
    }
    ```

## Hints
Usually to have a page, you give its route in the header like that
```razor
@page "/setup"
```
I suggest to use a constant for that route, it then can also be used for registering on the route provider.
```csharp
public static class Routes
{
    public const string HomeView = "/";
    public const string SetupView = "/setup";
}
```
```razor
@attribute [Route(Routes.SetupView)]
```
```csharp
var routeProvider = (RouteProvider)app.Services.GetRequiredService<IRouteProvider>();
routeProvider.RegisterRoutes(ViewKeys.HomeView, Routes.HomeView);
routeProvider.RegisterRoutes(ViewKeys.SetupView, Routes.SetupView);
```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.BLZ.Navigation)
* [GitHub](https://github.com/dwndland/Chapter.Net.BLZ.Navigation)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
