   M S B A M L   `   `   `  ���� F  BRightFlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RightFlightRightFlight  &     RightFlight.AirportSuggestionBox   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:RightFlight     -     >�Name$
  Root��.��� .+�� .+��� -    ��Name$ EntryBox��   RoundedTextBoxTemplate#��[  ����  �� ElementName$
 Root�� �� Path$ FontSize����� $
 Root��$ 	EntryText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�� -    �Name$ SuggestionPopup��$��Bottom=�.���� -    ��Name$ SuggestionListBox������ $ EntryBox��$ ActualWidth����� $
 Root��$ ItemsSource� �� SelectedItem �� $
 Root��$ SelectedItem�$ TwoWay=����� .R��� $
��Wrap=����� *.+  ItemConverter	 �� 	Converter#	 [ 
 �� ConverterParameter$

 code��