using Microsoft.AspNetCore.Components;
using Ven.Shared.Entities;

namespace Ven.Frontend.Pages.Coutries;

public partial class FormCountry
{
    [Parameter, EditorRequired]
    public Country Country { get; set; } = null!;

    [Parameter, EditorRequired]
    public EventCallback OnSubmit { get; set; }

    [Parameter, EditorRequired]
    public EventCallback ReturnAction { get; set; }
}