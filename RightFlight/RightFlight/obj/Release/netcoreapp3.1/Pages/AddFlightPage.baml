   M S B A M L   `   `   `  ���� F  BRightFlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RightFlightRightFlight      RightFlight.AddFlightPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:RightFlight       N� Title$  
Add Flight�� N� WindowTitle$ RightFlight - Add Flight�� N� ShowsNavigationUI$ False��   AircraftWingBrush N� 
Background# [   � Cursor �� *	UiState+  UiStateToCursor �� 	Converter# [  � 	Resources   ConfirmButtonStyle  ButtonStyle �� BasedOn �� 
TargetType	 �� Property
 �� Value��%�   &	       7  �� 8   " ��.��� 	 � ��$
 18(��� 	 � ��$
 SemiBold"��� 	 � ��$	
 180���� 	 � ��$
 45���� 	 � ��$

 Left=��� 	 � ��$	
 5 0q�.���� $	��500��.+���   	CardStyle#��[ ._���  
 Header#��[ $��
Add Flight���� #��[ ._��� .+���   TextBoxLabel#��[ $��Airline:��   RightFlight.SuggestionBox     RightFlight.SuggestionBox   EntryTextChanged$ AirlineTextChanged��  SuggestionBoxStyle#��[ $��0 0 0 10q�   	EntryText �� *AirlineSearchText+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�   ItemsSource �� *AirlineSearchResult+   SelectedItem �� *SelectedAirline+$ TwoWay=��� #��[ $!��Origin/Destination Airport:��&    RightFlight.AirportSuggestionBox  &    RightFlight.AirportSuggestionBox   EntryTextChanged$ AirportTextChanged��  AiportSuggestionBoxStyle#��[ $��0 0 0 20q�   	EntryText �� *AirportSearchText+$ OneWayToSource=�$ PropertyChanged=�   ItemsSource �� *AirportSearchResult+   SelectedItem �� *SelectedAirport+$ TwoWay=��� $	��250��$��0 0 0 10q����� *RouteSearchResult+ �� SelectedItem �� *SelectedRoute+���� .R��� .+���  �� Orientation$ 
Horizontal=�$��0 0 0 2q�.+���  	 TextBoxLeftLabel#��[	 $��From: ����  
 MiscTextBlock#��[
 ���� *OriginAirport+�� #��[
 ���� *OriginAirportCode+ �� StringFormat$ ({0})���� $ 
Horizontal=�$��0 0 0 4q�.+��� #��[	 $
��To: ���� #��[
 ���� *DestinationAirport+�� #��[
 ���� *DestinationAirportCode+$ ({0})���  � ColumnDefinitions �� $��* ��� $��20 ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��8 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��#��[ $��	Aircraft:���� $��1��$��0������ *RouteAircraftSearchResult+ �� *SelectedRouteAircraft+���� .R��� #��[
 ���� *Model+�� $��3��$��0��#��[ $��Flight Number:���� $��4��$��0��  MiscTextBoxStyle#��[ ���� *FlightNumber+�� $��0��$��2��#��[ $��Date:��(  "System.Windows.Controls.DatePicker  $��1��$��3��$��14(�   SelectedDate �� *SelectedDate+�� $��3��$��2��#��[ $��Departure Time:���� $��4��$��2��$ 
Horizontal=�.+���   SmallTextBoxStyle#��[ $��50��$��0 0 4 0q� �� TextAlignment$ Right=����� *DepartureTimeHours+$ {0:D2}���� #��[
 $��:��$	��2 0q��� #��[ $��50��$��4 0 0 0q����� *DepartureTimeMinutes+$ {0:D2}���� $��3��$��2��$��2��$ 
Horizontal=�$��0 15 0 0q�.+��� #��[ $��Confirm������ *ConfirmCommand+�� #��[ $��Cancel������ *CancelCommand+