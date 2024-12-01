// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IPopupStorage.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     Stores information about open tasks representing popups.
/// </summary>
public interface IPopupStorage
{
    /// <summary>
    ///     Keeps an open task.
    /// </summary>
    /// <param name="openTask">The task to keep.</param>
    void PushOpenTask(OpenTask openTask);

    /// <summary>
    ///     Returns and removes an open task by its component.
    /// </summary>
    /// <param name="componentKey">The component the task is for.</param>
    /// <returns>The removed open task.</returns>
    OpenTask PopOpenTask(object componentKey);

    /// <summary>
    ///     Check if there is already an open task by its component.
    /// </summary>
    /// <param name="componentKey">The component to look for.</param>
    /// <returns>True if there is an open task by its component; otherwise false.</returns>
    bool HasOpenTask(object componentKey);
}