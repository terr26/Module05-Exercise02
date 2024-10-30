using Module07Data_Access.Services;
using Module07Data_Access.ViewModel;

namespace Module07Data_Access.View;

public partial class ViewPersonal : ContentPage
{
    public ViewPersonal()
    {
        InitializeComponent();

        var personalViewModel = new PersonalViewModel();
        BindingContext = personalViewModel;
    }
}