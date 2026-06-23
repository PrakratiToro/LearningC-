using PropertyChanged;

namespace BMI.MVVM.Models;
[AddINotifyPropertyChangedInterface]

public class BMI
{
    private float _result;
    public float Weight { get; set; }
    public float Height { get; set; }

    public float Result
    {
        get
        {
            return ((Weight/Height)/Height* 10000);
        }
    }

    public string ResultText
    {
        get
        {
            return null; //depth detail
        }
    }
}