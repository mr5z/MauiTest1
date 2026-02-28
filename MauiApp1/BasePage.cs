using Mopups.Services;

namespace MauiApp1;

public class BasePage : ContentPage
{
    protected override bool OnBackButtonPressed()
    {
        return MopupService.Instance.PopupStack.Any();
    }
}