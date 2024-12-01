// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NavigateOptions.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     The options to navigate using <see cref="INavigationService.Navigate(object, NavigateOptions)" />.
/// </summary>
public class NavigateOptions
{
    /// <summary>
    ///     Gets or sets a value indicating whether the target page shall be force reloaded or not.
    /// </summary>
    public bool ForceLoad { get; set; } = false;

    /// <summary>
    ///     Gets or sets a value indicating whether the target page shall replace the current in the history.
    /// </summary>
    public bool Replace { get; set; } = false;

    /// <summary>
    ///     Gets or sets the state of the target page.
    /// </summary>
    public string HistoryEntryState { get; set; } = null;
}