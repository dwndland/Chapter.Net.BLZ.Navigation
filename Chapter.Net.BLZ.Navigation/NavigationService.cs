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
    private readonly IPopupStorage _popupStorage;
    private readonly IRouteProvider _routeProvider;

    /// <summary>
    ///     Creates a new instance of <see cref="NavigationService" />.
    /// </summary>
    /// <param name="routeProvider">The route provider.</param>
    /// <param name="popupStorage">The popup storage.</param>
    /// <param name="navigationManager">The navigation manager.</param>
    /// <param name="jsRuntime">The JS runtime.</param>
    public NavigationService(IRouteProvider routeProvider, IPopupStorage popupStorage, NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        _routeProvider = routeProvider;
        _popupStorage = popupStorage;
        _navigationManager = navigationManager;
        _jsRuntime = jsRuntime;
    }

    /// <inheritdoc />
    public event Action<object, object, Type> ShowPopupRequested;

    /// <inheritdoc />
    public event Action<object> ClosePopupRequested;

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

    /// <inheritdoc />
    public async Task ShowPopup<TComponent>(object hostId, object componentKey) where TComponent : IComponent
    {
        if (_popupStorage.HasOpenTask(componentKey))
            throw new InvalidOperationException($"The component key {componentKey} is already in use.");

        var openTask = new OpenTask(hostId, Guid.NewGuid(), typeof(TComponent));
        _popupStorage.PushOpenTask(openTask);
        ShowPopupRequested?.Invoke(hostId, openTask.ComponentKey, openTask.Component);
        await openTask.Task.Task;
    }

    /// <inheritdoc />
    public async Task<TResult> ShowPopup<TComponent, TResult>(object hostId, object componentKey) where TComponent : IComponent
    {
        if (_popupStorage.HasOpenTask(componentKey))
            throw new InvalidOperationException($"The component key {componentKey} is already in use.");

        var openTask = new OpenTask(hostId, componentKey, typeof(TComponent));
        _popupStorage.PushOpenTask(openTask);
        ShowPopupRequested?.Invoke(hostId, openTask.ComponentKey, openTask.Component);
        return (TResult)await openTask.Task.Task;
    }

    /// <inheritdoc />
    public void ClosePopup(object componentKey, object result = null)
    {
        var openTask = _popupStorage.PopOpenTask(componentKey);
        if (openTask == null)
            throw new InvalidOperationException($"The component key {componentKey} is unknown.");

        ClosePopupRequested?.Invoke(componentKey);
        openTask.Task.SetResult(result);
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