   M S B A M L   `   `   `  ���� F  BRightFlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RightFlightRightFlight  "    RightFlight.FlightSearchPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:RightFlight     -     N�Name$
  Root�� N� Title$ Flight Search�� N� WindowTitle$&  RightFlight - Search for Flights�� N� ShowsNavigationUI$ False��   AircraftWingBrush N� 
Background# [   � Cursor �� *	UiState+  UiStateToCursor �� 	Converter# [  � 	Resources   TravelClassStyle �� 
TargetType	 �� Property
 �� Value  
PriceStyle  SearchButtonStyle  ButtonStyle �� BasedOn  BookButtonStyle��%d  &	       &	 �     &	 �     7  &	 �    7  �� " ��.��� 	 � ��$
 12(��� 	 � ��$
 SemiBold"��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 0 0 0 4q��� " ��.��� 	 � ��$
 Georgia Pro)��� 	 � ��$
 28(��� 	 �@��TextAlignment$
 Center=��� " ��8   .��� 	 � ��$
 18(��� 	 � ��$
 SemiBold"��� 	 � ��$	
 180���� 	 � ��$
 45���� 	 � ��$
 Right=��� 	 � ��$
 Bottom=��� " ��8   .��� 	 � ��$
 16(��� 	 � ��$
 SemiBold"��� 	 � ��$	
 160���� 	 � ��$
 45���� 	 � ��$
 Right=��� 	 � ��$
 Bottom=�.���� .���� $	��800��$	��650��.+���   	CardStyle#��[ ._��  � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0�� 
 Header#��[ $��Search for Flights���� $��1�� 	 HomeButtonStyle#��[	 $
��Home������ *HomeCommand+�� #��[ ._��� .+�� $��0 0 0 12q� �� $��* ��� $��25 ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��$��0�� 
 TextBoxLabel#��[
 $��From:��   RightFlight.SuggestionBox     RightFlight.SuggestionBox   EntryTextChanged$ OriginEntryTextChanged��$��1��$��0��  SuggestionBoxStyle#��[    	EntryText �� *OriginCitySearchText+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�   ItemsSource �� *OriginCitySearchResult+   SelectedItem �� *SelectedOriginCity+$ TwoWay=��� $��0��$��2��#��[
 $	��To:��  $! DestinationEntryTextChanged��$��1��$��2��#��[  �� *DestinationCitySearchText+$ OneWayToSource=�$ PropertyChanged=� �� *DestinationCitySearchResult+ �� *SelectedDestinationCity+$ TwoWay=��  �� $��* ��� $	��180 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $
��18 0q�.+��� #��[
 $��Adults:��   RightFlight.IncrementBox  $��85��$��20(�   MinValue$ 0��   MaxValue$ 9��   Value �� *Adults+$ OneWayToSource=��� $
��18 0q�.+��� #��[
 $��	Children:��  $��85��$��20(�$ 0��$ 9�� �� *
Children+$ OneWayToSource=��� $
��18 0q�.+��� #��[
 $��Infants:��  $��85��$��20(�$ 0��$ 9�� �� *	Infants+$ OneWayToSource=��� $��1��#��[ $��Search������ *FlightSearchCommand+�� ���� *FlightSearchResult+���� .R��� ���� .R��� #��[ ._��  �� $��7* ��� $��3* ��� $��4* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��2��  	DateStyle#��[ ���� *DepartureTime+ �� StringFormat$ dddd dd MMMM yyyy���� $��0��$��1��$	��0 6q�.+��� $ 
Horizontal=�.+���   CityLabelStyle#��[ $��From:����   	CityStyle#��[ ���� *
OriginCity+�� #��[ ���� *OriginCountry+$ , {0}���� $ 
Horizontal=�.+���   AirportStyle#��[ ���� *OriginAirport+�� #��[ ���� *OriginAirportCode+$  ({0})���� $��0��$��2��$	��0 6q�.+��� $ 
Horizontal=�.+��� #��[ $	��To:���� #��[ ���� *DestinationCity+�� #��[ ���� *DestinationCountry+$ , {0}���� $ 
Horizontal=�.+��� #��[ ���� *DestinationAirport+�� #��[ ���� *DestinationAirportCode+$  ({0})���� $��0��$��3��$ 
Horizontal=�.+���   DurationLabelStyle#��[ $��	Duration:����   DurationStyle#��[ ���� *FlightDuration+  TimeSpanConverter# [ �� $��1��$��1��$��Center=�.+���   TimeLabelStyle#��[ $��
Departure:����   	TimeStyle#��[ ���� *DepartureTime+$ HH:mm���� $��1��$��2��$��Center=�.+��� #��[ $��Arrival:���� #��[ ���� *ArrivalTime+$ HH:mm���� $��2��$��0��$��4��.+��� ���� *AirlineLogoPath+��   AirlineStyle#��[ ���� *	Airline+��   FlightNumberStyle#��[ ���� *FlightNumber+��   AircraftTypeStyle#��[ ���� *AircraftType+�� $��0��$��4��$��2��$��0 10 0 0q����� *TicketPrices+���� .R��� $ 
Horizontal=�$��Center=����� .R��� $	��120��.+��� #��[ ���� *TravelClass+�� #��[ ���� *Amount+$ 	£{0:#,#}���� $��2��$��4��#��[ $
��Book������  �� ElementName$
 Root�� �� Path$ DataContext.BookCommand����� *.+