using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicCalc.ViewModels;

namespace BasicCalc;

public partial class CalcView : ContentPage
{
    public CalcView()
    {
        InitializeComponent();
        BindingContext = new CalcViewModel();
    }
}