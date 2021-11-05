using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DemoApp.Controls
{
    public partial class StepperControl : ContentView
    {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(int), typeof(StepperControl), default, BindingMode.TwoWay/*,propertyChanged : OnValueChanged*/);

        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(StepperControl), 0, BindingMode.TwoWay);

        public static readonly BindableProperty BackgroundButtonProperty = BindableProperty.Create(nameof(BackgroundButton), typeof(Color), typeof(StepperControl),
            Color.FromHex("#DFF3E7"), BindingMode.TwoWay);

        public static readonly BindableProperty TextColorButtonProperty = BindableProperty.Create(nameof(TextColorButton), typeof(Color), typeof(StepperControl),
            Color.FromHex("#27AE60"), BindingMode.TwoWay); 

        public static readonly BindableProperty TextColorValueProperty = BindableProperty.Create(nameof(TextColorValue), typeof(Color), typeof(StepperControl),
            Color.FromHex("#4F4F4F"), BindingMode.TwoWay);  

        //public static readonly BindableProperty FontSizeValueProperty = BindableProperty.Create(nameof(FontSizeValue), typeof(double), typeof(StepperControl),
        //    14, BindingMode.TwoWay); 

        public event EventHandler<EvenStepper> TapEvent;

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        //static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    try
        //    {
        //        var control = (StepperControl)bindable;

        //        var value = (int)newValue;

        //        control.ApplyValue(value);
        //    }
        //    catch { }
        //}

        //void ApplyValue(int value)
        //{
        //    txtValue.Text = value.ToString();
        //    btnMinus.IsEnabled = value != 0;
        //}

        public Color BackgroundButton
        {
            get => (Color)GetValue(BackgroundButtonProperty);
            set => SetValue(BackgroundButtonProperty, value);
        }

        public Color TextColorButton
        {
            get => (Color)GetValue(TextColorButtonProperty);
            set => SetValue(TextColorButtonProperty, value);
        }
        public Color TextColorValue
        {
            get => (Color)GetValue(TextColorValueProperty);
            set => SetValue(TextColorValueProperty, value);
        }
        //public double FontSizeValue
        //{
        //    get => (double)GetValue(TextColorValueProperty);
        //    set => SetValue(FontSizeValueProperty, value);
        //}

        public class EvenStepper : EventArgs
        {
            public int Value { get; set; }
        }

        public StepperControl()
        {
            InitializeComponent();
        }

        private void btnIncrease_Clicked(object sender, EventArgs e)
        {
            if (MaxValue > 0)
            {
                if (Value < MaxValue)
                {
                    ++Value;
                    TapEvent?.Invoke(this, new EvenStepper { Value = Value });
                }
            }
            else
            {
                ++Value;
                TapEvent?.Invoke(this, new EvenStepper { Value = Value });
            }
            txtValue.Text = Value.ToString();
             btnMinus.IsEnabled = Value != 0;
        }

        private void btnDecrease_Clicked(object sender, EventArgs e)
        {
            if (Value > 0)
            {
                --Value;
            }
            btnMinus.IsEnabled = Value != 0;
            txtValue.Text = Value.ToString();
            TapEvent?.Invoke(this, new EvenStepper { Value = Value });
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == nameof(BackgroundButton))
            {
                btnMinus.BackgroundColor = BackgroundButton;
                btnPlus.BackgroundColor = BackgroundButton;
            }

            if(propertyName == nameof(TextColorButton))
            {
                btnMinus.TextColor = TextColorButton;
                btnPlus.TextColor = TextColorButton;
            }

            if(propertyName == nameof(TextColorValue))
            {
                txtValue.TextColor = TextColorValue;
            }

            //if(propertyName == nameof(FontSizeValue))
            //{
            //    txtValue.FontSize = FontSizeValue;
            //}

            if (propertyName == nameof(Value))
            {
                txtValue.Text = Value.ToString();
                btnMinus.IsEnabled = Value != 0;
            }
        }
    }
}
