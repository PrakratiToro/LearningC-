using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMI.MVVM.ViewModels;

namespace BMI.MVVM.Views;

public partial class BMIView : ContentPage
{
    public BMIView()
    {
        InitializeComponent();
        BindingContext = new BMIViewModel();
    }
}