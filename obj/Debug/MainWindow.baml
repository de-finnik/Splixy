   M S B A M L   `   `   `  ����I  EVokabeltrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:VokabeltrainerVokabeltrainer  5   	       Vokabeltrainer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Vokabeltrainer     5   	     � 
ResizeMode$  	CanResize=�5   	    � Title$ 
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � ��5      �� 5       �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6*   .��5      �  � Color$ Black��6    � Offset$ 0Q�6!   � 5      $ 	#FF0E1027��6   $ 1Q�6%   5      .+�5      � -   5         �Name$ gridStartup��5   	   .+�5      �� -   5         ��Name$ 	BtnLernen��5      $��Lernen��6   $
��Left=�60   $��172,252,0,0q�6K   $	��Top=�6`   $��75��6x   $��Arial Black)�6�   6�   �� 5      -   5        $ BtnEintragen��5      $��	Eintragen��6"   $
��Left=�66   $��349,252,0,0q�6Q   $	��Top=�6f   $��75��6~   $��Arial Black)�6�   6�   5      ]� 5   
   -   5         ]�Name$ 	gridLearn��5      $y�Hidden=�6'   .+�5      �� -   5        $ BtnOpen��5      $
��Open��6&   $
��Left=�65   $��172,252,0,0q�6P   $	��Top=�6e   $��75��6}   $��Arial Black)�6�   6�   �� 5      $��English��6   $
��Left=�6&   $��292,180,0,0q�6A   $	��Top=�6V   
�������	 J� RenderTransformOrigin$	 3.688,-1.423&�6�   �� 5      -   5        
 ��Name$
 textBoxLearnLang1��5      $
��Left=�63   $��23��6N   $��292,204,0,0q�6Z   $
��Wrap=�6o   $	��Top=�6�   $	��120��6�   
�������
���   �6�   �� 5      $��Deutsch��6   $
��Left=�6&   $��531,180,0,0q�6A   $	��Top=�6V   
�������6n   �� 5      -   5         ��Name$ textBoxLearnLang2��5      $
��Left=�61   $��23��6L   $��531,204,0,0q�6X    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��120��6�   �� 5      -   5        $ btnLearnCheck��5      $��Check��6,   $
��Left=�6<   $��442,250,0,0q�6W   $	��Top=�6l   $��75��6�   6�   5      � 5   
   -	   5        $ gridRegister��5      $y�Hidden=�6%   .+�5      �� -
   5         ��Name$ listVocs��5      $
��Left=�6(   $	��300��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��200��6{   �� 5       $��English��6   $
��Left=�6&   $��292,180,0,0q�6A   $	��Top=�6V   
�������$	 3.688,-1.423&�6�   �� 5!      -   5        $ textBoxRegisterLang1��5!      $
��Left=�64   $��23��6O   $��292,204,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5"      $��Deutsch��6   $
��Left=�6&   $��531,180,0,0q�6A   $	��Top=�6V   
�������6n   �� 5#      -   5        $ textBoxRegisterLang2��5#      $
��Left=�64   $��23��6O   $��531,204,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5$      -   5        $ BtnRegisterEdit��5$      $��Edit existing file��6.   $
��Left=�6K   $��230,250,0,0q�6f   $	��Top=�6{   $	��150��6�   6�   �� 5%      -   5        $ btnRegisterAdd��5%      $	��Add��6-   $
��Left=�6;   $��442,250,0,0q�6V   $	��Top=�6k   $��75��6�   6�   �� 5&      -   5        $ btnRegisterSave��5&      $
��Save��6.   $
��Left=�6=   $��600,300,0,0q�6X   $	��Top=�6m   $��75��6�   6�   5'      �� 5(   
   -   5        $ btnHome��5(      $
��Home��6"   $
��Left=�61   $��
372,10,0,0q�6L   $	��Top=�6`   $��75��6x   6�   5)      5*      