   M S B A M L   `   `   `  ����G  CPROJEKAT_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PROJEKAT_HCI.ViewPROJEKAT_HCI.View  5   	   K GApex, Version=1.5.0.0, Culture=neutral, PublicKeyToken=98d06957926c086d;)clr-namespace:Apex.Controls;assembly=ApexApex.Controls 5   	   0    *PROJEKAT_HCI.View.DodavanjeSaradnikaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PROJEKAT_HCI.View     5   	   :apex)clr-namespace:Apex.Controls;assembly=Apex     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  ORGANIZACIJA-PROSLAVA.IO��5
   	   $	��450��6*   $	��800��67    � 	Resources 5       �� 
TargetType   Textbox1 �� Property �� Value �� 
TargetType ��Name �� CornerRadius ��Name��%  &	        �� 5   
   " ��6   .�5      ��  � ��$ 7q�6(   �� 5       � ��$ 5q�6'   �� 5       � �� �#0006+   �� 5       � ��$ 15(�6)   �� 5       � ��$ 30��6*   �� 5       � ��$	 250��6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $ 10��5      ���#000$��2q�5      ���#fff._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�5      $��Hidden=�5      5       5"      5$      5%      5'      .��5)      � 	 � RowDefinitions	 5*   
   �� 5+      $	��13* �6   �� 5,      $	��84* �6   .+�5/   
   ��   PrimaryHueDarkBrush#��[ 6   
�������$��20(�6U   $��Center=�6c   $��Center=�6�   .��6�   Dodavanje saradnika6�   �� 50   
   $��1��6   $��0��6"   $��2��62   $��Center=�6G   $��Center=�6d   .+�52        Apex.Controls.ApexGrid  
   Rows$
 	auto,auto��6      Columns$ 	auto,auto��6-   $��	150,0,0,0q�6A   .+�53      �� $��Naziv��6   $
��left=�6(   $��Center=�6C   
���   �$��15(�6q   $��2��6   �� 54      -   5        $��Naziv��54   &   $��40��6   $��	150,8,0,0q�64   $	��300��6G   6U   55        56      $
 	auto,auto��6   $ 	auto,auto��6-   $��	150,0,0,0q�6A    � ColumnDefinitions 57      �� 58      $
��187* �6'   �� 59      $
��455* �6'   .+�5<      �� $	��Tip��6   $
��left=�6'   $��Center=�6B   
���   �$��15(�6p   $
��0,16q�6~   �� 5=      -   5         ��Name$	 Tip��5>      $��150,20,192,0q�5=        MaterialDesignComboBox#��[ 5?      $��Center=�5A      $��Center=�5B      $	��300��5D      $��40��6!   
�������$��2��6@   5F      5H        5I      $
 	auto,auto��6   $ 	auto,auto��6-   $��	150,0,0,0q�6A   .+�5J      �� $��Lokacija��6   $
��left=�6+   $��Center=�6F   
���   �$��15(�6t   $��2��6�   �� 5K      -   5        $��Lokacija��5K      $��40��6*   $	��300��68   $��150,10,192,0q�6D   6\   5M      �� 5Q       �� Orientation$ 
Horizontal=�6   $��	150,0,0,0q�63   $	��131��6F   .+�5R      �� $
��Opis��6   $
��left=�6'   $	��Top=�6B   
���   �$��15(�6m   $��2��6{   �� 5V      -   5        $
��Opis��5W       ! MaterialDesignOutlinedTextBox#��[ 5X      $	��Top=�5Y      $��Right=�5Z   )   $	��100��5[      $	��302��6&    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5]      " �� VerticalScrollBarVisibility$
 Auto=�5^      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Opišite saradnika��5_      $��100,10,10,10q�5`      
�������5a      5c      �� 5l      $ 
Horizontal=�6   $��	10,10,0,0q�62   .+�5m      �� -   5        $��odustao��5m   /   $	��140��6>   $��Odustani��6J   $��0��6^   $��1��6k   $��2��6{   $��116,0,136,0q�6�   �� 5n      -   5         ��Name$ Azuriraj_saradnika��5n   7   $��Dodaj saradnika��6S   $	��149��6m   $��116,0,136,0q�6y   5p      5r      5u      5v      