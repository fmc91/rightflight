using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RightFlight
{
    public partial class SuggestionBox : UserControl
    {
        private bool m_blockPopup;

        private bool m_blockEntryBoxTextChanged;

        public event RoutedEventHandler EntryTextChanged;

        public SuggestionBox()
        {
            InitializeComponent();
        }

        public string EntryText
        {
            get { return (string)GetValue(EntryTextProperty); }
            set { SetValue(EntryTextProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private void RootLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            Window w = Window.GetWindow(this);
            w.LocationChanged += WindowLocationChanged;
        }

        private void SuggestionBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_blockPopup = true;
            m_blockEntryBoxTextChanged = true;

            if (SuggestionListBox.SelectedItem == null)
                EntryBox.Text = String.Empty;
            else
                EntryBox.Text = SuggestionListBox.SelectedItem.ToString();

            m_blockPopup = false;
            m_blockEntryBoxTextChanged = false;

            SuggestionPopup.IsOpen = false;
        }

        private void EntryBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_blockEntryBoxTextChanged) return;

            SelectedItem = null;

            EntryTextChanged?.Invoke(this, new RoutedEventArgs());

            if (!ItemsSource.Any() || String.IsNullOrWhiteSpace(EntryBox.Text))
                SuggestionPopup.IsOpen = false;
            else if (!m_blockPopup)
                SuggestionPopup.IsOpen = true;
        }

        private void EntryBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (ItemsSource.Any() && !String.IsNullOrWhiteSpace(EntryBox.Text))
                    SuggestionPopup.IsOpen = true;
            }
            else if (e.Key == Key.Escape)
            {
                SuggestionPopup.IsOpen = false;
            }
        }

        private void RootLostFocus(object sender, RoutedEventArgs e)
        {
            SuggestionPopup.IsOpen = false;
        }

        private void WindowLocationChanged(object sender, EventArgs e)
        {
            SuggestionPopup.IsOpen = false;
        }

        public static readonly DependencyProperty EntryTextProperty =
            DependencyProperty.Register(nameof(EntryText), typeof(string), typeof(SuggestionBox), new PropertyMetadata(String.Empty));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(SuggestionBox), new PropertyMetadata(defaultValue: null));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(SuggestionBox), new PropertyMetadata(defaultValue: null));
    }
}
