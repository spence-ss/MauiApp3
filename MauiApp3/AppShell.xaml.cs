namespace MauiApp3;

public partial class AppShell : Shell
{
    private AppShellViewModel Model => BindingContext as AppShellViewModel;
    public AppShell()
    {
        InitializeComponent();
        FlyoutBehavior = Model.FlyoutBehavior;
        Model.PropertyChanged += (s, e) =>
        {
            switch (e.PropertyName)
            {
                case "FlyoutBehavior":
                    FlyoutBehavior = Model.FlyoutBehavior;
                    break;
                case "CodeBehindDisplay":
                    CodeBehindFlyout.FlyoutDisplayOptions = Model.CodeBehindDisplay;
                    break;
                default:
                    break;
            }

        };
    }
}