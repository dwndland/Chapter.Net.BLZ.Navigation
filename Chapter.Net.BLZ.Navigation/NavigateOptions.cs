// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NavigateOptions.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     Defines the options for the INavigationService.Navigate*.
/// </summary>
public class NavigateOptions
{
    /// <summary>
    ///     If true, bypasses client-side routing and forces the browser to load the new page from the server, whether the URI
    ///     would normally be handled by the client-side router.
    /// </summary>
    public bool ForceLoad { get; set; } = false;

    /// <summary>
    ///     If true, replaces the current entry in the history stack.
    ///     If false, appends the new entry to the history stack.
    /// </summary>
    public bool Replace { get; set; } = false;

    /// <summary>
    ///     Gets or sets the state to append to the history entry.
    /// </summary>
    public string HistoryEntryState { get; set; } = null;
}