// -----------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     Allow move from page to page within the application.
/// </summary>
public interface INavigationService
{
    /// <summary>
    ///     Navigates back.
    /// </summary>
    Task NavigateBack();

    /// <summary>
    ///     Navigates forward.
    /// </summary>
    Task NavigateForward();

    /// <summary>
    ///     Refreshes the current page.
    /// </summary>
    void Refresh();

    /// <summary>
    ///     Refreshes the current page with the option to force reload.
    /// </summary>
    /// <param name="forceReload">The indicator if reload shall be forced.</param>
    void Refresh(bool forceReload);

    /// <summary>
    ///     Navigates to a route registered by <see cref="RegisterTargets" />.
    /// </summary>
    /// <param name="key">The registered route key.</param>
    /// <exception cref="ArgumentNullException">The key cannot be null.</exception>
    void Navigate(object key);

    /// <summary>
    ///     Navigates to a route registered by <see cref="RegisterTargets" /> with options.
    /// </summary>
    /// <param name="key">The registered route key.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="ArgumentNullException">The key cannot be null.</exception>
    /// <exception cref="ArgumentNullException">The options cannot be null.</exception>
    void Navigate(object key, NavigateOptions options);

    /// <summary>
    ///     Reads the history entry state from the current page.
    /// </summary>
    /// <returns>The history entry state from the current page.</returns>
    string GetCurrentHistoryEntryState();
}