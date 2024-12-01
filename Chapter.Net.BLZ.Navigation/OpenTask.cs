// -----------------------------------------------------------------------------------------------------------------
// <copyright file="OpenTask.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     Represents an open popup.
/// </summary>
/// <param name="HostId">The ID where the popup is shown.</param>
/// <param name="ComponentKey">The key of the open popup.</param>
/// <param name="Component">The popup.</param>
public record OpenTask(object HostId, object ComponentKey, Type Component)
{
    /// <summary>
    ///     The task triggering close of the popup.
    /// </summary>
    public TaskCompletionSource<object> Task { get; } = new();
}