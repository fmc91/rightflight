   M S B A M L   `   `   `  ���� F  BRightFlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RightFlightRightFlight  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     RightFlight.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     +localclr-namespace:RightFlight     6sys&clr-namespace:System;assembly=mscorlib       �� 	Resources      RightFlight.HalveConverter 	  Halve*   $RightFlight.UiStateToCursorConvertor  UiStateToCursor �� 
TargetType �� 	Resources �� Property �� Value �� 
TargetType �Name ]�Name ]� Thumb	 n�Name
 �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Angle  RoundedTextBoxTemplate �� RelativeSource �� Path �� 	Converter � ColumnDefinitions �� AncestorType ��Name J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity   
BlurRadius   ShadowDepth  SmallRoundedTextBoxTemplate  AiportSuggestionBoxStyle&    RightFlight.AirportSuggestionBox  SuggestionBoxStyle   RightFlight.SuggestionBox  MiscTextBoxStyle  SmallTextBoxStyle  RoundedButtonTemplate �� Padding 	 ButtonStyle �� 
StartPoint �� EndPoint � Color � Offset  �� Triggers 
 AddButtonStyle! A�Name	" �� X1	# �� Y1	$ �� X2	% �� Y2  RemoveButtonStyle  HomeButtonStyle& �� BasedOn  	CardStyle 
 Header  TextBoxLabel  TextBoxLeftLabel  MiscTextBlock  	DateStyle  CityLabelStyle  	CityStyle  AirportStyle  DurationLabelStyle  DurationStyle  TimeLabelStyle  	TimeStyle  AirlineStyle  FlightNumberStyle  AircraftTypeStyle  AircraftWingBrush' �� ImageSource( j� Stretch"   RightFlight.AirportConverter  AirportConverter#   RightFlight.TimeSpanConverter  TimeSpanConverter��%�  &	        &	      '�� 
     &	 3    7   7   7   &	 �    &	 "    &	 E    &	 h    7  &	 �    7  &	 �    7   7   7   &		 �    7  &	
 r    &	 �	    &	 �    7 	 &	 \    &	 &    &	     &	 �    &	 M    &	 �    &	 �    &	 9    &	 \    &	 �    &	 �    &	     &	 U    &	 �    &	     &	 x    &	 �    &	     &	         �� " �� ��X�(��       *,*SystemParameters.VerticalScrollBarWidthKey+)8Q�X�(��       */-SystemParameters.HorizontalScrollBarHeightKey+)8Q�.���  � �� �� " ��.R�� $ GridRoot��$��8��.+�]� $ 
PART_Track��$
��True��$|�False�� n� $	 Thumb������ .R��� ���#d0d0d0$
 5�� P�  �@��Orientation$ 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	 -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	 -90Q��� $ Thumb�� �@�Tag$ 
Horizontal���� " ��.R��� 
�������
 ��  �� *Self+$ ActualHeight�8   ._��  �� ����  �� 
 Border$ ActualHeight�8  �� $��* ��� ����  �� 
 Border$ ActualHeight�8  .+��� $ PART_ContentHost��$��1��$��Hidden=�$��Center=�$	��0 2q�   $ #909090��$
 0.75Q�$ 5Q�$ 2Q��� " ��.R��� 
�������$
 6��._��� $ PART_ContentHost��$��1��$��Hidden=�$	��6 2q�   $ #909090��$
 0.75Q�$ 5Q�$ 2Q��� "  .���  � ��$ 14(��� "  .���  � ��$ 14(��� " ��.���  � ��8   ��  � ��$ 14(��� " ��.���  � ��8   ��  � ��$ 14(��� " ��.R��� #��z��#��z��#��z��# z��
 ��  �� *Self+$ ActualHeight�8   ._��  �� ����  �� 
 Border$ ActualHeight�8  �� $��* ��� ����  �� 
 Border$ ActualHeight�8  .+��� $��1��$��Center=�$��Center=��� " ��.���  � ��8   ��  � �� �� $	 0,0&�$	 0,1&�.��� $ #4481db��$ 0Q�� $ #245cad��$ 1Q���  � ��$ 2q���  � ��
 ���� ��  � ��
 �����  P�  �@J�IsMouseOver$
 True��. ���  � ��
 �����P�  � ��$
 True��. ���  � �� �� $	 0,0&�$	 0,1&�.��� $ #6da3f2��$ 0Q�� $ #3c78cf��$ 1Q��� " ��.���  � �� �� " ��.R�� .+�A� $! Circle��$��26��$��26��$��1������ $ 0.3,0.3&�$ 0.7,0.7&�.��� $ #6bcf53��$ 0Q�� $ #57ba3f��$ 1Q��� $" 13��$# 4��$$ 13��$% 22��
�������$��4���� $" 4��$# 13��$$ 22��$% 13��
�������$��4�� P�  �@J�IsMouseOver$
 True��. ��� $ Circle�� � �� �#93d1faP�  � ��$
 True��. ��� $ Circle�� � �� �� $ 0.3,0.3&�$ 0.7,0.7&�.��� $ #80e667��$ 0Q�� $ #67d14d��$ 1Q���  � ��$	 5 0q��� " ��.���  � �� �� " ��.R�� .+�A� $! Circle��$��26��$��26��$��1������ $ 0.3,0.3&�$ 0.7,0.7&�.��� $ #eb5454��$ 0Q�� $ #c23434��$ 1Q��� $" 6��$# 6��$$ 20��$% 20��
�������$��4���� $" 20��$# 6��$$ 6��$% 20��
�������$��4�� P�  �@J�IsMouseOver$
 True��. ��� $ Circle�� � �� �#93d1faP�  � ��$
 True��. ��� $ Circle�� � �� �� $ 0.3,0.3&�$ 0.7,0.7&�.��� $ #f26f6f��$ 0Q�� $ #e05555��$ 1Q���  � ��$	 5 0q��� " ��8&   .���  � ��$ 18(���  � ��$ SemiBold"���  � ��$	 180����  � ��$ 8q���  � ��$ Center=��� " ��.���  �@��CornerRadius$ 15����  �@��Padding$ 15q���  � ��$ 8q���  � �� �� $ 0.4,0&�$ 0.6,1&�.��� $ #e0e2e9��$ 0Q�� $ #cfd6da��$ 1Q��� " ��.���  � ��$ 28(���  � ��$ SemiBold"���  � ��$ Center=��� " ��.���  � ��$ 14(���  � ��$ SemiBold"���  � ��$ 2 2 2 4q��� " ��.���  � ��$ 14(���  � ��$ SemiBold"���  � ��$ 2 2 4 2q���  � ��$ Center=��� " ��.���  � ��$ 14(���  � ��$ 2q��� " ��.���  � ��$ 22(���  � ��$ SemiBold"���  � ��$ 0 0 0 6q��� " ��.���  � ��$ 16(���  � ��$ SemiBold"���  � ��$ 0 0 4 0q��� " ��.���  � ��$ 16(��� " ��.���  � ��$ 14(���  � ��$ Italic$��� " ��.���  � ��$ 14(���  � ��$ SemiBold"���  � ��$ 0 0 4 0q��� " ��.���  � ��$ 14(��� " ��.���  � ��$ 11(���  � ��$ SemiBold"��� " ��.���  � ��$ 26(���  � ��$ SemiBold"��� " ��.���  � ��$ 22(���  � ��$ Italic$���  �@��TextAlignment$ Right=���  � ��$ 0 0 0 4q��� " ��.���  � ��$ 18(���  �@��TextAlignment$ Right=���  � ��$ 0 0 0 4q��� " ��.���  � ��$ 14(���  �@��TextAlignment$ Right=��� $6' 0pack://application:,,,/Images/aircraft_wing.jpeg��$( UniformToFill=�    