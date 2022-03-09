using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.NumberFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NumberBoxApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            TestNumberBox.RegisterPropertyChangedCallback(NumberBox.TextProperty, new DependencyPropertyChangedCallback(TextPropertyChanged));

            DecimalFormatter formatter = new DecimalFormatter();
            formatter.IntegerDigits = 1;
            formatter.FractionDigits = 2;
            formatter.NumeralSystem = "ArabExt";
            formatter.NumberRounder = new IncrementNumberRounder { Increment = 0.25 };

            TestNumberBox.NumberFormatter = formatter;
            TestNumberBox.AcceptsExpression = false;
        }

        private void NumberBoxValueChanged(object sender, Microsoft.UI.Xaml.Controls.NumberBoxValueChangedEventArgs e)
        {
            if (TestNumberBox != null && NewValueTextBox != null && OldValueTextBox != null)
            {
                NewValueTextBox.Text = e.NewValue.ToString();
                OldValueTextBox.Text = e.OldValue.ToString();
            }
        }

        private void TextPropertyChanged(DependencyObject o, DependencyProperty p)
        {
            TextTextBox.Text = TestNumberBox.Text;
        }
    }
}
