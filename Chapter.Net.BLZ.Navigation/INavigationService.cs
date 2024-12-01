// -----------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     The service to navigate through the application from viewmodels.
/// </summary>
public interface INavigationService
{
    /// <summary>
    ///     Triggered if a popup wants to get shown.
    /// </summary>
    event Action<object, object, Type> ShowPopupRequested;

    /// <summary>
    ///     Triggered if a popup wants to get closed.
    /// </summary>
    event Action<object> ClosePopupRequested;

    /// <summary>
    ///     Navigates back the history.
    /// </summary>
    /// <returns>The task to await.</returns>
    Task NavigateBack();

    /// <summary>
    ///     Navigates forward the history.
    /// </summary>
    /// <returns>The task to await.</returns>
    Task NavigateForward();

    /// <summary>
    ///     Reloads the current page.
    /// </summary>
    void Refresh();

    /// <summary>
    ///     Reloads the current page.
    /// </summary>
    /// <param name="forceReload">A value indicating whether the reload shall be forced or not.</param>
    void Refresh(bool forceReload);

    /// <summary>
    ///     Navigates to a particular page known by its keys. See <see cref="IRouteProvider.RegisterRoutes" />.
    /// </summary>
    /// <param name="key">The key of the route.</param>
    void Navigate(object key);

    /// <summary>
    ///     Navigates to a particular page known by its keys. See <see cref="IRouteProvider.RegisterRoutes" />.
    /// </summary>
    /// <param name="key">The key of the route.</param>
    /// <param name="options">The navigation options.</param>
    void Navigate(object key, NavigateOptions options);

    /// <summary>
    ///     Gets the state of the current page.
    /// </summary>
    /// <returns>The state of the current page.</returns>
    string GetCurrentHistoryEntryState();

    /// <summary>
    ///     Shows a popup.
    /// </summary>
    /// <typeparam name="TComponent">The popup component.</typeparam>
    /// <param name="hostId">The host where to show the popup.</param>
    /// <param name="componentKey">The key of the component.</param>
    /// <returns>The task to await (Finishes on close of the popup).</returns>
    Task ShowPopup<TComponent>(object hostId, object componentKey) where TComponent : IComponent;

    /// <summary>
    ///     Shows a popup.
    /// </summary>
    /// <typeparam name="TComponent">The popup component.</typeparam>
    /// <typeparam name="TResult">The expected result.</typeparam>
    /// <param name="hostId">The host where to show the popup.</param>
    /// <param name="componentKey">The key of the component.</param>
    /// <returns>The popup result.</returns>
    Task<TResult> ShowPopup<TComponent, TResult>(object hostId, object componentKey) where TComponent : IComponent;

    /// <summary>
    ///     Closes a popup by its key.
    /// </summary>
    /// <param name="componentKey">The popup key.</param>
    /// <param name="result">The popup result.</param>
    void ClosePopup(object componentKey, object result = null);
}