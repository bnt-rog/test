using CommunityToolkit.Maui.Views;
using PTR_DRS.ViewModels;

namespace PTR_DRS.Views;

public partial class RiderDialog : Popup
{
    public RiderDialog(RiderViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void CloseDialog(object sender, EventArgs e)
    {
        Close();
    }
}