   M S B A M L   `   `   `  ���� F  BRightFlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RightFlightRightFlight       RightFlight.BookFlightPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:RightFlight     -     N�Name$
  Root�� N� Title$ Book Flight�� N� WindowTitle$ RightFlight - Book Flight�� N� ShowsNavigationUI$ False��   AircraftWingBrush N� 
Background# [   � Cursor �� *	UiState+  UiStateToCursor �� 	Converter# [  � 	Resources   
PriceStyle �� 
TargetType	 �� Property
 �� Value  BookFlightButtonStyle  ButtonStyle �� BasedOn&    RightFlight.NationalityConverter  NationalityConverter��%  &	       &	 i     7  &	 �     �� " ��.��� 	 � ��$
 Georgia Pro)��� 	 � ��$
 28(��� 	 �@��TextAlignment$
 Right=��� " ��8   .��� 	 � ��$	
 180���� 	 � ��$
 8q��� 	 � ��$	
 5 0q��� 	 � ��$
 18(��� 	 � ��$
 SemiBold"�  .���� .���� $	��800��$	��600��.+���   	CardStyle#��[ ._���  
 Header#��[ $��Book Flight���� #��[ ._��  � ColumnDefinitions �� $��7* ��� $��3* ��� $��4* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��0��$��2��  	DateStyle#��[ ����  �� Path$" SelectedFlight.DepartureTime� �� StringFormat$ dddd dd MMMM yyyy���� $��0��$��1��$	��0 6q�.+���  �� Orientation$ 
Horizontal=�.+���  	 CityLabelStyle#��[	 $��From:����  
 	CityStyle#��[
 ���� $ SelectedFlight.OriginCity��� #��[
 ���� $" SelectedFlight.OriginCountry�$ , {0}���� $ 
Horizontal=�.+���   AirportStyle#��[ ���� $" SelectedFlight.OriginAirport��� #��[ ���� $&  SelectedFlight.OriginAirportCode�$  ({0})���� $��0��$��2��$	��0 6q�.+��� $ 
Horizontal=�.+��� #��[	 $	��To:���� #��[
 ���� $$ SelectedFlight.DestinationCity��� #��[
 ���� $' !SelectedFlight.DestinationCountry�$ , {0}���� $ 
Horizontal=�.+��� #��[ ���� $' !SelectedFlight.DestinationAirport��� #��[ ���� $+ %SelectedFlight.DestinationAirportCode�$  ({0})���� $��0��$��3��$ 
Horizontal=�.+���   DurationLabelStyle#��[ $��	Duration:����   DurationStyle#��[ ���� $# SelectedFlight.FlightDuration�  TimeSpanConverter# [ �� $��1��$��1��$��Center=�.+���   TimeLabelStyle#��[ $��
Departure:����   	TimeStyle#��[ ���� $" SelectedFlight.DepartureTime�$ HH:mm���� $��1��$��2��$��Center=�.+��� #��[ $��Arrival:���� #��[ ���� $  SelectedFlight.ArrivalTime�$ HH:mm���� $��2��$��0��$��4��.+��� ���� $$ SelectedFlight.AirlineLogoPath���   AirlineStyle#��[ ���� $ SelectedFlight.Airline���   FlightNumberStyle#��[ ���� $! SelectedFlight.FlightNumber���   AircraftTypeStyle#��[ ���� $! SelectedFlight.AircraftType��� $	��0 8q�$	��150��$��Right=����� $! SelectedFlight.TicketPrices� �� SelectedItem �� *SelectedTicketType+ �� Mode$ TwoWay=����� .R��� $��14(����� *TravelClass+�� #��[ ���� $ SelectedTicketType.Amount�$ 	£{0:#,#}���� #��[ ._��� $��16(�$��SemiBold"�$7��1Please enter the details of each passenger below.���� ���� *PassengerInfo+���� .R��� ���� .R��� #��[ ._��  �� $��* ��� $��10 ��� $��* ��� $��25 ��� $��* ��� $��10 ��� $��* � �� $
��Auto ��� $��8 ��� $
��Auto ��� $
��Auto ��� $��12 ��� $
��Auto ��� $
��Auto ��� $��12 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��7��$��18(�$��SemiBold"����� *Index+$ Passenger {0}���� $��0��$��2��  TextBoxLabel#��[ $��First Name:���� $��0��$��3��  MiscTextBoxStyle#��[ ���� *	FirstName+�� $��2��$��2��#��[ $��
Last Name:���� $��2��$��3��#��[ ���� *
LastName+�� $��0��$��5��#��[ $��Date of Birth:��(  "System.Windows.Controls.DatePicker  $��0��$��6��$��14(�   SelectedDate �� *DateOfBirth+�� $��2��$��5��#��[ $��Nationality:���� $��2��$��6��$��14(�����  �� ElementName$
 Root��$ DataContext.Nationalities� �� *NationalityId+$ OneWayToSource=�# [ ���� .R��� $��14(����� *CountryName+�� $��4��$��2��#��[ $��Address:���� $��4��$��3��$��3��#��[ ���� *	Address+�� $��4��$��5��#��[ $��City:���� $��4��$��6��#��[ $��Center=����� *City+�� $��6��$��5��#��[ $��Country:���� $��6��$��6��#��[ $��Center=����� *	Country+�� $��6��$��8��#��[ $��	Postcode:���� $��6��$��9��#��[ ���� *
Postcode+�� #��[ ._��� $ 
Horizontal=�$��Right=�.+��� #��[ $��Confirm������ *ConfirmCommand+�� #��[ $��Cancel������ *CancelCommand+