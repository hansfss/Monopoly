   M S B A M L   `   `   `  ����V  RMonopoly Nasdaq Alpha v0.01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Monopoly_Nasdaq_Alpha_v0._01Monopoly_Nasdaq_Alpha_v0._01  5   	   -    'Monopoly_Nasdaq_Alpha_v0._01.PressStart   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Monopoly_Nasdaq_Alpha_v0._01     5   	     � WindowStyle$
  None=�5   	   
�����p� � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�6X    � Title$ 
PressStart��5	   	   $	��450��6   $	��800��6)   .��5
      � 
���   �.+�5   
   �� -   5         ��Name$ monopolylogo��5      $��
0,10,0,164q�6&   $��Board/Logo.png��6:   $
��Fill=�6R   6a   �� 5   
   -   5         ��Name$ 
lblVersion��5      $��¡Bolsa de Comercio!��6$   $
��Left=�6B   $��355,218,0,0q�6]   $	��445��6r   
������� � Cursor$ No��6�   $��20(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $	��Top=�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.432Q�6&   T� 5      5      5      �� 5   
   -   5        $ 
lblNewGame��5      $�� ��6$   $
��Left=�6/   $��193,291,0,0q�6J   $	��Top=�6_   
�������$��24(�6�   $
 Hand��6�   6�   �� 5   
   -   5        $ lblExit��5      $�� ��6!   $
��Left=�6,   $��193,380,0,0q�6G   $	��Top=�6\   
�������$��24(�6�   $
 Hand��6�   �� 5   
   -   5        $ lblConfiguration��5      $�� ��6*   $
��Left=�65   $��193,333,0,0q�6P   $	��Top=�6e   
�������$��24(�6�   $
 Hand��6�   6�   �� 5   
   -   5        $ lblPressStart��5      $��press start��6'   $
��Left=�6=   $��145,312,0,0q�6X   $	��Top=�6m   $��OCR A Extended)�6�   $��72(�6�   
�������$
 Hand��6�   6�   �� 5   
   -   5        	 ��Name$	 config��5      $��	0,229,0,0q�6$   
 �� Stretch$

 Fill=�67   $	��800��6F   �� 5   
   $��Label��6   $
��Left=�6    $	��Top=�6;   �� 5   
   -   5        $ lblconfig_back��5      $
��Back��6(   $
��Left=�67   $��1029,395,-323,0q�6R   $	��Top=�6k   $��94��6�   $
 Hand��6�   $��20(�6�   
�������6�   �� 5   
   -	   5        $ imgInstructivo2��5      $��469,692,250,-320q�6)   $��Board/Chance.png��6C   $
��Fill=�6]   �� 5   
   -
   5        $ imgInstructivo1��5      $��469,573,239,-197q�6)   $��Board/Nasdaq100.png��6C   $
��Fill=�6`   �� 5   
   -   5        $ imgInstructivo3��5      $��100,692,609,-325q�6)   $��Board/GoToJail.png��6C   $
��Fill=�6_   �� 5    
   -   5        $ imgInstructivo4��5       $��100,573,609,-210q�6)   $��Board/Jail.png��6C   $
��Fill=�6[   �� 5!   
   -   5        $ lblInstructivo2��5!      $V��PGo to jail: intenta no caer acá
apenas lo hagas irás directamente
a la cárcel��6)   $
��Left=�6�   $��207,692,0,-308q�6�   $	��Top=�6�   
���   �$��14(�6�   {�.  6�   �� 5"   
   -   5        $ lblInstructivo1��5"      $����Si te envían a la cárcel 
(sea cual sea la razón) 
 tienes que esperar 3 turnos 
para salir o esperar
la suerte de un dado doble
��6)   $
��Left=�6�   $��207,553,0,-218q�6�   
���   �$��14(�6  {�.  $	��115��64  $	��Top=�6A  �� 5#   
   -   5        $ lblInstructivo3��5#      $��Tarjetas de 
casualidad��6)   $
��Left=�6T   $��566,711,0,-308q�6o   $	��Top=�6�   
���   �$��14(�6�   {�.  $��97��6�   �� 5$   
   -   5        $ lblInstructivo4��5$      $��Tarjetas de 
Nasdaq - 100��6)   $
��Left=�6Q   $��566,573,0,-170q�6l   $	��Top=�6�   
���   �$��14(�6�   {�.  $��97��6�   �� 5%   
   -   5        $ lblconfig_next��5%      $
��Next��6(   $
��Left=�67   $��1029,454,-323,-41q�6R   $	��Top=�6m   $��94��6�   $
 Hand��6�   $��20(�6�   
�������6�   �� 5&   
   -   5        $ lblconfig_previous��5&      $��Previous��6,   $
��Left=�6?   $��1029,506,-323,-93q�6Z   $	��Top=�6u   $��94��6�   $
 Hand��6�   $��20(�6�   
�������6�   �� 5'   
   -   5        $ lblInstructivo5��5'      $����Lanza los dados y avanza por las casillas. 
Intenta comprar todas las empresas y se 
el mayor accionista de todos para ganar!

Modo rápido: puedes usar la barra 
espaciadora para lanzar los dados, moverte
y tomar las cartas.��6)   $
��Left=�61  $��748,573,-241,-284q�6L  $	��Top=�6g  
���   �$��14(�6�  {�.  $	��293��6�  $	��161��6�  �� 5(   
   -   5        $ ImageEasterEgg��5(      $��-1129,-151,1243,450q�6(   $��Board/Logo2.png��6E   $
��Fill=�6^   �� 5)   
   -   5        $ imgInstructivo5��5)      $��654,608,68,-218q�6)   $��Board/dice.png��6B   $
��Fill=�6Z   5+      5,      