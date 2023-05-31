using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zadanie_Five
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {        
        public Calculator()
        {
            InitializeComponent();            
        }
        private void SliderValue(object sender, ValueChangedEventArgs e)
        {
            LabelSlider.Text = $"{Slider.Value}%";
            if (myLabelOne.Text != "" && srok.Text != "")
            {
                Calculation(sum.Text, srok.Text, picker.SelectedIndex, Slider.Value);
            }
            else
            {
                myLabelOne.Text = "Ежемесячный платеж: ...";
                myLabelTwo.Text = "Общая сумма: ...";
                myLabelOne.Text = "Переплата: ...";
            }
        }

        private void Calculation(string sum, string srok, int picker, double Slider)
        {
            if (Convert.ToDouble(srok) != 0 && Convert.ToDouble(sum) != 0)
            {
                switch (picker)
                {
                    case 0:
                        {
                            double EveryMonthPay = (Convert.ToDouble(sum) + Convert.ToDouble(sum) * Slider / 100) / Convert.ToDouble(srok);
                            myLabelOne.Text = $"Ежемесячный платеж: {Math.Round(((Convert.ToDouble(sum) + Convert.ToDouble(sum) * Slider / 100) / Convert.ToDouble(srok)), 2)}";
                            myLabelTwo.Text = $"Общая сумма: {Math.Round(EveryMonthPay * Convert.ToDouble(srok), 2)}";
                            myLabelOne.Text = $"Переплата: {Math.Round((Convert.ToDouble(srok) - Convert.ToDouble(sum)), 2)}";
                        }
                        break;
                    case 1:
                        {
                            double EveryMonthPay = Convert.ToDouble(sum) * (Slider + (Slider / (Math.Pow((1 + Slider), (Convert.ToDouble(srok)) - 1))));
                            myLabelOne.Text = $"Ежемесячный платеж: {Math.Round(EveryMonthPay, 2)}";
                            myLabelTwo.Text = $"Общая сумма: {Math.Round(EveryMonthPay * (Convert.ToDouble(srok)), 2)}";
                            myLabelThree.Text = $"Переплата: {Math.Round(Math.Round((Convert.ToDouble(srok) - Convert.ToDouble(sum))), 2)}";
                        }
                        break;
                    default:
                        {
                            myLabelOne.Text = "Ежемесячный платеж:...";
                            myLabelTwo.Text = "Общая сумма:...";
                            myLabelThree.Text = "Переплата:...";
                        }
                        break;
                }
            }
            else
            {
                myLabelOne.Text = "Ежемесячный платеж:Oшибка";
                myLabelTwo.Text = "Общая сумма:Oшибка";
                myLabelThree.Text = "Переплата:Oшибка";
            }
        }
    }
}