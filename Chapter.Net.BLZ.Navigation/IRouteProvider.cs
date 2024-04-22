// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IRouteProvider.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     Allow move from page to page within the application.
/// </summary>
public interface IRouteProvider
{
    /// <summary>
    ///     Assigns a key to a route to use for navigate.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="route">The target route.</param>
    /// <exception cref="ArgumentNullException">The key cannot be null.</exception>
    /// <exception cref="ArgumentNullException">The route cannot be null.</exception>
    void RegisterRoutes(object key, string route);

    /// <summary>
    ///     Provides the route for a key if registered.
    /// </summary>
    /// <param name="key">The key for the route.</param>
    /// <returns>The registered route.</returns>
    /// <exception cref="ArgumentNullException">The key cannot be null.</exception>
    /// <exception cref="InvalidOperationException">For the key no route is registered.</exception>
    string GetRoute(object key);
}