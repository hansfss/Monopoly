   M S B A M L   `   `   `  ����V  RMonopoly Nasdaq Alpha v0.01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Monopoly_Nasdaq_Alpha_v0._01Monopoly_Nasdaq_Alpha_v0._01  5   	   +    %Monopoly_Nasdaq_Alpha_v0._01.NewGame1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Monopoly_Nasdaq_Alpha_v0._01     5   	     � Title$  NewGame1��5   	   $	��450��6   $	��800��6'    � WindowStyle$
 None=�64    � WindowStartupLocation$ CenterScreen=�6H    � 
ResizeMode$ NoResize=�6m   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0.196Q�6)   � 5      $ 	#FF2E2E2E��6   $ 1Q�6-   5      .��5      � .+�5   
   �� $��NEW GAME��6   $
��Left=�6#   $��	94,10,0,0q�6>   $	��Top=�6Q   $	��394��6i   $��72(�6u   
�������6�   �� 5   
   -   5         ��Name$ btnJugador1��5      $��PRESS��6&   $
��Left=�66   $��75��6Q   $��
71,169,0,0q�6]   $	��Top=�6q   $	��167��6�   6�   �� 5   
   -   5        $ btnJugador2��5      $��PRESS��6&   $
��Left=�66   $��75��6Q   $��586,169,0,0q�6]   $	��Top=�6r   $	��167��6�   6�   �� 5   
   -   5        $ btnJugador3��5      $��PRESS��6&   $
��Left=�66   $��75��6Q   $��
71,318,0,0q�6]   $	��Top=�6q   $	��167��6�   6�   �� 5   
   -   5        $ btnJugador4��5      $��PRESS��6&   $
��Left=�66   $��75��6Q   $��586,318,0,0q�6]   $	��Top=�6r   $	��167��6�   6�   �� 5   
   -   5        	 ��Name$	 
lblplayer1��5      $��	player 1:��6$   $
��Left=�68   $��
71,121,0,0q�6S   $	��Top=�6g   $	��119��6   $��18(�6�   ���	#FFBDBDBD6�   �� 5   
   -   5        $	 
lblplayer2��5      $��	player 2:��6$   $
��Left=�68   $��586,121,0,0q�6S   $	��Top=�6h   $	��119��6�   $��18(�6�   ���	#FFBDBDBD6�   �� 5   
   -   5        $	 
lblplayer3��5      $��	player 3:��6$   $
��Left=�68   $��
71,279,0,0q�6S   $	��Top=�6g   $	��119��6   $��18(�6�   ���	#FFBDBDBD6�   �� 5   
   -   5        $	 
lblplayer4��5      $��	player 4:��6$   $
��Left=�68   $��586,279,0,0q�6S   $	��Top=�6h   $	��119��6�   $��18(�6�   ���	#FFBDBDBD6�   �� 5   
   -	   5        $	 lblBack��5      $
��Back��6!   $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   $��57��6v   
�������$��18(�6�   
 � Cursor$

 Hand��6�   �� 5   
   -
   5        $	 lblPLayerNumber��5      $��0��6)   $
��Left=�65   $��391,196,0,0q�6P   $	��Top=�6e   $��95��6}   $��46��6�   $��72(�6�   
�������6�   �� 5   
   -   5        $	 lblStart��5      $��START��6"   $
��Left=�62   $��356,335,0,0q�6M   $	��Top=�6b   
�������$��36(�6�   $

 Hand��6�   6�   �� 5   
   -   5         ��Name$ 
imgPlayer1��5      $��545,292,156,68q�6$   $��Characters/player1_b.png��6<   $
��Fill=�6^    J� RenderTransformOrigin$ 0.5,0.5&�6m   z�5      V� 5      .~�5      �� �� 5       �� 5!       �� Angle$ -46.332Q�6&   T� 5"      5#      5%      �� 5&   
   -   5        $ 
imgPlayer2��5&      $��34,287,667,73q�6$   $��Characters/player4_b.png��6;   $
��Fill=�6]   $ 0.5,0.5&�6l   z�5'      V� 5(      .~�5)      �� �� 5*      �� 5+      $ -36.561Q�6&   T� 5,      5-      5/      �� 50   
   -   5        $ 
imgPlayer3��50      $��551,134,150,226q�6$   $��Characters/player3_b.png��6=   $
��Fill=�6_   $ 0.5,0.5&�6n   z�51      V� 52      .~�53      �� �� 54      �� 55      $ -30.092Q�6&   T� 56      57      59      �� 5:   
   -   5        $ 
imgPlayer4��5:      $��40,137,661,218q�6$   $��Characters/player2_b.png��6<   $
��Fill=�6^   $ 0.5,0.5&�6m   z�5;      V� 5<      .~�5=      �� �� 5>      �� 5?      $ -36.49Q�6&   T� 5@      5A      5C      5D      5E      