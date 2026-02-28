namespace MauiApp1;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        return Mopups.Services.MopupService.Instance.PopupStack.Any();
    }
}
