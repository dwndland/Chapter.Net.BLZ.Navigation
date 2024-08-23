// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Chapter.Net.BLZ.Navigation;

/// <inheritdoc />
public class NavigationService : INavigationService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly NavigationManager _navigationManager;
    private readonly IRouteProvider _routeProvider;

    /// <summary>
    ///     Creates a new instance of the <see cref="NavigationService" />.
    /// </summary>
    /// <param name="routeProvider">The route provider.</param>
    /// <param name="navigationManager">The navigation manager.</param>
    /// <param name="jsRuntime">The javascript runtime.</param>
    public NavigationService(IRouteProvider routeProvider, NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        _routeProvider = routeProvider;
        _navigationManager = navigationManager;
        _jsRuntime = jsRuntime;
    }

    /// <inheritdoc />
    public async Task NavigateBack()
    {
        await _jsRuntime.InvokeVoidAsync("eval", "history.back();");
    }

    /// <inheritdoc />
    public async Task NavigateForward()
    {
        await _jsRuntime.InvokeVoidAsync("eval", "history.forward();");
    }

    /// <inheritdoc />
    public void Refresh()
    {
        _navigationManager.Refresh();
    }

    /// <inheritdoc />
    public void Refresh(bool forceReload)
    {
        _navigationManager.Refresh(forceReload);
    }

    /// <inheritdoc />
    public void Navigate(object key)
    {
        var route = _routeProvider.GetRoute(key);
        _navigationManager.NavigateTo(route);
    }

    /// <inheritdoc />
    public void Navigate(object key, NavigateOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        var route = _routeProvider.GetRoute(key);
        _navigationManager.NavigateTo(route, CreateOptions(options));
    }

    /// <inheritdoc />
    public string GetCurrentHistoryEntryState()
    {
        return _navigationManager.HistoryEntryState;
    }

    private NavigationOptions CreateOptions(NavigateOptions options)
    {
        var navOptions = new NavigationOptions
        {
            ForceLoad = options.ForceLoad,
            ReplaceHistoryEntry = options.Replace,
            HistoryEntryState = options.HistoryEntryState
        };
        return navOptions;
    }
}