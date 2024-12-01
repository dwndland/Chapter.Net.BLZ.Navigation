// -----------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     The service to navigate through the application from viewmodels.
/// </summary>
public interface INavigationService
{
    /// <summary>
    ///     Triggered if a popup wants to get shown.
    /// </summary>
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
}