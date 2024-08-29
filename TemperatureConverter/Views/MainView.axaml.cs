using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Diagnostics;

namespace TemperatureConverter.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void OnButtonClick(object sender, RoutedEventArgs e)
    {

        if (!string.IsNullOrWhiteSpace(celsiusTextBox.Text) && string.IsNullOrWhiteSpace(fahrenheitTextBox.Text) && (double.TryParse(celsiusTextBox.Text, out double celsiusInput)) && !celsiusTextBox.Text.Contains("."))
        {
            //double celsiusInput = Convert.ToDouble(celsiusTextBox.Text);
            double celsiusToFahrenheit = celsiusInput * (9d / 5d) + 32d;
            celsiusToFahrenheit = Math.Round(celsiusToFahrenheit, 1);
            fahrenheitTextBox.Text = celsiusToFahrenheit.ToString();
            fahrenheitTextBox.IsReadOnly = true;
            celsiusTextBox.IsReadOnly = true;

            Debug.WriteLine($"Click! Fahrenheit={fahrenheitTextBox.Text}");
        }
        else if (!string.IsNullOrEmpty(fahrenheitTextBox.Text) && string.IsNullOrWhiteSpace(celsiusTextBox.Text) && (double.TryParse(fahrenheitTextBox.Text, out double fahrenheitInput)) && !fahrenheitTextBox.Text.Contains("."))
        {
            //double fahrenheitInput = Convert.ToDouble(fahrenheitTextBox.Text);
            double fahrenheitToCelsius = (fahrenheitInput - 32d) * 5d / 9d;
            fahrenheitToCelsius= Math.Round(fahrenheitToCelsius, 1);
            celsiusTextBox.Text = fahrenheitToCelsius.ToString();
            fahrenheitTextBox.IsReadOnly = true;
            celsiusTextBox.IsReadOnly = true;
        }
        else
        {
            fahrenheitTextBox.IsReadOnly = false;
            celsiusTextBox.IsReadOnly = false;
            celsiusTextBox.Clear();
            fahrenheitTextBox.Clear();
        }

    }

    private void ClearButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        fahrenheitTextBox.IsReadOnly = false;
        celsiusTextBox.IsReadOnly = false;
        celsiusTextBox.Clear();
        fahrenheitTextBox.Text = "";
    }
}
