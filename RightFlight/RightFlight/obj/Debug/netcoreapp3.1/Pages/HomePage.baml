   M S B A M L   `   `   `  ����F  BRightFlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RightFlightRightFlight  5          RightFlight.HomePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:RightFlight     5        N� Title$  HomePage��5	       N� WindowTitle$ RightFlight - Home��5
       N� ShowsNavigationUI$ False��5         AircraftWingBrush N� 
Background# [  5       � 	Resources 5        HomePageButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 �� Padding �� 
StartPoint �� EndPoint � Color � Offset �� Triggers P� Property P� Value��%  &	       �� 5   
   " ��6,   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $	 12��6K   #��z��5      #��z��6I   #
 z��6u   ._�5      �� $��1��6/   $��Center=�6?   $��Center=�6Z   5      5      5      �� 5       � �� 5      �� 5      $	 0,0&�6*   $	 0,1&�6;   .��5       � $ #4481db��6'   $ 0Q�67   � 5!      $ #245cad��6'   $ 1Q�67   5"      5$      �� 5&       � ��$ 2q�60   �� 5'       � ��
 ���� 6,   �� 5(       � ��
 �����6+   �� 5)       � ��$ 80��6'   �� 5*       � ��$ 28(�6)   �� 5+       � ��$	 0 4q�6'    5-      P� 5.       �@J�IsMouseOver$
 True��61   . �5/      ��  � ��
 �����64   50      P� 51       � ��$
 True��6/   . �52      ��  � �� 53      �� 54      $	 0,0&�62   $	 0,1&�6C   .��55   "   � $ #6da3f2��6/   $ 0Q�6?   � 56   "   $ #3c78cf��6/   $ 1Q�6?   57      59      5:      5<      5>      .��5@      �� .��5A   
   � .+�5C      ��   	CardStyle#��[ 6   $	��500��68   $	��300��6G   $��Center=�6V   ._�5D      �� .+�5F      �� #��[ 6   $��Search for Flights��6J   ��5G      �� *SearchForFlightsCommand+�� 5I      #��[ 6   $��	Add Route��6J   ��5J      �� *AddRouteCommand+�� 5L      #��[ 6   $��
Add Flight��6J   ��5M      �� *AddFlightCommand+5N      5O      5Q      5R      5S      