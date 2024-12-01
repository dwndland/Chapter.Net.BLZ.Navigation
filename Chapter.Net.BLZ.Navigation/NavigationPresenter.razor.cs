// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationPresenter.razor.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Components;

namespace Chapter.Net.BLZ.Navigation;

/// <summary>
///     Represents a presentation host for popups.
/// </summary>
public partial class NavigationPresenter
{
    private object _currentComponentKey;
    private Type ComponentToRender { get; set; }
    private bool IsComponentVisible { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the popup host.
    /// </summary>
    [Parameter]
    public object ID { get; set; }

    /// <summary>
    ///     Gets or sets the navigation service.
    /// </summary>
    [Inject]
    public INavigationService NavigationService { get; set; }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        NavigationService.ShowPopupRequested += OnShowPopupRequested;
        NavigationService.ClosePopupRequested += OnClosePopupRequested;
    }

    private void OnShowPopupRequested(object id, object componentKey, Type componentType)
    {
        if (ID != id)
            return;

        _currentComponentKey = componentKey;
        ComponentToRender = componentType;
        IsComponentVisible = true;
        StateHasChanged();
    }

    private void OnClosePopupRequested(object componentKey)
    {
        if (_currentComponentKey != componentKey)
            return;

        IsComponentVisible = false;
        ComponentToRender = null;
        StateHasChanged();
    }
}