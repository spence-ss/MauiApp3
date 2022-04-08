

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp3;


public partial class AppShellViewModel : ObservableObject
{
    
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(PinText))]
    FlyoutBehavior flyoutBehavior = FlyoutBehavior.Locked;

    public string PinText => FlyoutBehavior == FlyoutBehavior.Locked ? "UnPin" : "Pin";

    [ICommand]
    void TogglePin()
    {
        FlyoutBehavior = FlyoutBehavior == FlyoutBehavior.Locked ? FlyoutBehavior.Flyout : FlyoutBehavior.Locked;
    }

    [ObservableProperty]
    FlyoutDisplayOptions flyoutDisplay = FlyoutDisplayOptions.AsSingleItem;

    [ObservableProperty]
    FlyoutDisplayOptions codeBehindDisplay = FlyoutDisplayOptions.AsSingleItem;

    [ICommand]
    void ToggleDisplay()
    {
        FlyoutDisplay = flyoutDisplay == FlyoutDisplayOptions.AsSingleItem
            ? FlyoutDisplayOptions.AsMultipleItems
            : FlyoutDisplayOptions.AsSingleItem;  
        Shell.Current.DisplayAlert("FYI", $"FlyoutDisplay Toggled.  Current Display is: {FlyoutDisplay}", "OK");
    }

    [ICommand]
    async void ToggleCodeBehindDisplay()
    {
     
        //Gives an error in Windows
        if (DeviceIdiom.Desktop != DeviceInfo.Idiom || await Shell.Current.DisplayAlert("Are you sure?", "Changing the FlyoutDisplayOptions in the code behind results in an error on Windows.", "Continue", "Cancel"))
        {
            CodeBehindDisplay = codeBehindDisplay == FlyoutDisplayOptions.AsSingleItem
             ? FlyoutDisplayOptions.AsMultipleItems
             : FlyoutDisplayOptions.AsSingleItem;
            await Shell.Current.DisplayAlert("FYI", $"FlyoutDisplay Toggled.  Current Display is: {CodeBehindDisplay}", "OK");
        }
    }

}
