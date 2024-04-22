// -----------------------------------------------------------------------------------------------------------------
// <copyright file="RouteProvider.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Chapter.Net.BLZ.Navigation;

/// <inheritdoc />
public class RouteProvider : IRouteProvider
{
    private readonly Dictionary<object, string> _pairs;

    /// <summary>
    ///     Creates a new instance of the <see cref="RouteProvider" />.
    /// </summary>
    public RouteProvider()
    {
        _pairs = new Dictionary<object, string>();
    }

    /// <inheritdoc />
    public void RegisterRoutes(object key, string route)
    {
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(route);

        _pairs[key] = route;
    }

    /// <inheritdoc />
    public string GetRoute(object key)
    {
        ArgumentNullException.ThrowIfNull(key);
        if (!_pairs.ContainsKey(key))
            throw new InvalidOperationException($"For the key '{key}' no route is registered.");

        return _pairs[key];
    }
}