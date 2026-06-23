namespace BMI.MVVM.ViewModels;

public class BMIViewModel
{
    public Models.BMI BMI { get; set; }

    public BMIViewModel() //CONSTRUCTOR
    {
        BMI = new Models.BMI();//INSTANCE
        BMI.Weight = 70;
        BMI.Height = 180;
    }
}