   M S B A M L   `   `   `  ����F  BRightFlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RightFlightRightFlight  5      &     RightFlight.AirportSuggestionBox   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:RightFlight     5      -   5          >�Name$
  Root��5      .��5      � .+�5   
   � .+�5      �� -   5         ��Name$ EntryBox��5         RoundedTextBoxTemplate#��[  6(   ��6[   ��  �� ElementName$
 Root�� �� Path$ FontSize���5      �� $
 Root��$ 	EntryText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      � 5      -   5         �Name$ SuggestionPopup��5      $��Bottom=�6-   .��5      �� -   5         ��Name$ SuggestionListBox��5      ��65   �� $ EntryBox��$ ActualWidth���5      �� $
 Root��$ ItemsSource� �� SelectedItem 5      �� $
 Root��$ SelectedItem�$ TwoWay=���5      �� 5      .R�5      �� $
��Wrap=�6(   ��5   (   �� *.+  ItemConverter	 �� 	Converter#	 [ 
 �� ConverterParameter$

 code��5      5!      5"      5$      5&      5'      