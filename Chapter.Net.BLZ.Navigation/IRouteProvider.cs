// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IRouteProvider.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     Provides routes.
/// </summary>
public interface IRouteProvider
{
    /// <summary>
    ///     Registers a route and key pair.
    /// </summary>
    /// <param name="key">The key representation of a route.</param>
    /// <param name="route">The route.</param>
    void RegisterRoutes(object key, string route);

    /// <summary>
    ///     Gets the known route for a key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The route.</returns>
    string GetRoute(object key);
}