using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RightFlight
{
    public partial class IncrementBox : UserControl
    {
        public IncrementBox()
        {
            InitializeComponent();
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        private void IncrementButtonClick(object sender, RoutedEventArgs e)
        {
            if (Value < MaxValue)
                ++Value;
        }

        private void DecrementButtonClick(object sender, RoutedEventArgs e)
        {
            if (Value > MinValue)
                --Value;
        }

        public void ValueChanged()
        {
            if (Value > MaxValue)
                Value = MaxValue;
            else if (Value < MinValue)
                Value = MinValue;
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(IncrementBox), new PropertyMetadata(0, ValueChangedCallback));

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register(nameof(MinValue), typeof(int), typeof(IncrementBox), new PropertyMetadata(Int32.MinValue, ValueChangedCallback));

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register(nameof(MaxValue), typeof(int), typeof(IncrementBox), new PropertyMetadata(Int32.MaxValue, ValueChangedCallback));

        public static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((IncrementBox)d).ValueChanged();
        }

    }
}
