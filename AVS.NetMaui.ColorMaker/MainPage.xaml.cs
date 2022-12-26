using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AVS.NetMaui.ColorMaker;

public partial class MainPage : ContentPage
{
    private bool _isRandom;
    private string _hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

    private void SliderUpdateValue(object sender, ValueChangedEventArgs e)
    {
        if (!_isRandom)
        {
            var red = SldRed.Value;
            var green = SldGreen.Value;
            var blue = SldBlue.Value;

            var color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        Debug.WriteLine(color.ToString());
        BtnRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        _hexValue = color.ToHex();
        LblHex.Text = _hexValue;
    }

    private async void ImageButtonCopyColor(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(_hexValue);
        var toast = Toast.Make("Cor Copiada.", 
            ToastDuration.Short, 12);
        await toast.Show();
    }

    private void CreateColor(object sender, EventArgs e)
    {
        _isRandom = true;
        var random = new Random();
        var color = Color.FromRgb(random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256));
        SetColor(color);
        SldRed.Value = color.Red;
        SldGreen.Value = color.Green;
        SldBlue.Value = color.Blue;
        _isRandom = false;
    }
}
