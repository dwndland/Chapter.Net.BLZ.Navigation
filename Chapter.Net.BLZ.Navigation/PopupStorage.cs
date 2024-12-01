// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PopupStorage.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Chapter.Net.BLZ.Navigation;

/// <inheritdoc />
public class PopupStorage : IPopupStorage
{
    private readonly List<OpenTask> _openTasks = new();

    /// <inheritdoc />
    public void PushOpenTask(OpenTask openTask)
    {
        _openTasks.Add(openTask);
    }

    /// <inheritdoc />
    public OpenTask PopOpenTask(object componentKey)
    {
        var existing = _openTasks.FirstOrDefault(x => x.ComponentKey == componentKey);
        _openTasks.Remove(existing);
        return existing;
    }

    /// <inheritdoc />
    public bool HasOpenTask(object componentKey)
    {
        return _openTasks.Any(x => x.ComponentKey == componentKey);
    }
}