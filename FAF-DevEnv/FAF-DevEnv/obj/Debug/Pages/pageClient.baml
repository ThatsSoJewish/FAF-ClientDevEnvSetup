   M S B A M L   `   `   `  ����D  @FAFDevEnv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FAFDevEnv.PagesFAFDevEnv.Pages  5           FAFDevEnv.Pages.pageClient   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:FAFDevEnv.Pages     5        N� Title$  
pageClient��5      $	��349��6   $	��400��6'    � 	Resources 5	         buttonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%v  &	        �� 5
   
   " ��6$   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � ��$ 5q�6'   �� 5       � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�6/   ���#707070$ 0��6Y   #��z��6j   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver	 . . �5   "   ��  � �� �	#FF6C6C6C6?   �� 5   "    � ��
 �   �6?   �� 5   "    � �� �#8F8F8F6@   5      5      5      5      5       .��5!      � 
���   �$��	0,-16,0,0q�6   .+�5"   
   � $��0,25,0,0q�6   .+�5#      �� -   5        $��FAFLogo��5#      $��/Resources/faf-logo.png��6#   $��
0,-2,0,188q�6D   
 J� RenderTransformOrigin$
 0.511,0.355&�6X   �� 5$      -   5         ��Name$ labelFilePath��5$      
�������$��0,0,0,0q�6>   $��0,155,0,101q�6P   .��5%      �� $����For this installer to create the development environment correctly, you must have 'Git For Windows' and 'Python 3+' installed. If you do not have either of these programs links are provided by the buttons below. Once these programs are installed, choose a filepath to install the FAF Client development environment, and then click 'Create Environment.'��6   $
��Left=�5&      $��Center=�67   $
 0.478,2.188&�6R   $
��Wrap=�6v    �� TextAlignment$ Center=�6�   $	��401��6�   $��90��6�   5'      �� 5(      -   5        $��buttonDownloadGIT��5(      $��Git For Windows��6.   $
��Left=�6H   $��
74,240,0,0q�6c   $	��Top=�6w   $��98��6�   #��[  6�   �� 5)      -   5        $��buttonDownloadPy��5)      $��	Python 3+��6-   $
��Left=�6A   $��209,240,0,0q�6\   $	��Top=�6q   $��98��6�   #��[  6�   �� 5*      -   5        $ 
labelNotes��5*      
�������$��0,0,0,0q�6;   $��Center=�6M   $��4,259,297,53q�6o   .��5+      �� $��Current Directory: ��6   $
 	0.5,0.534&�67   $��16��6Y   5,      �� 5-      -   5        $��textboxFilePath��5-      $
��Left=�6-   $��17��6H   $	��338��6T   $��
10,284,0,0q�6`    �� TextWrapping$ NoWrap=�6t   $	��C:\��6�   $	��Top=�6�   $��Center=�6�   $
 0.117,0.647&�6�   $��12(�5.      �� 5/      -   5        $��buttonBrowse��5/      $��Browse��6)   $
��Left=�6:   $��17��6U   $��42��6a   $��351,284,0,0q�6l   $	��Top=�6�   $��10(�6�   $
 0.5,0.5&�6�   $��0,0,0,0q�6�   #��[  50      �� 51      -   5        $��buttonCreateEnv��51      $��Create Environment��6,   $
��Left=�6I   $	��118��6d   $��
10,311,0,0q�6p   $	��Top=�6�   #��[  6�   $��20��6�   �� 52      -	   5        $��buttonLaunchClient��52      $��Launch Client��6/   $
��Left=�6G   $��275,311,0,0q�6b   $	��Top=�6w   $	��118��6�   #��[  6�   $��20��6�   53      � 54   
   -
   5        $��
popupFiles��54      $
��Left=�6"   $	��Top=�6=   $	��155��6U   $	��173��6a   ��.   J� OpacityMask
 �   �$��	0,-35,0,0q�6�    � PlacementTarget 6�   ��  �� ElementName$ FAFLogo��.��55      � 
���   �$	��173��6&   $	��Top=�63   $��0,0,0,0q�6K   .+�56      �� ���	#FF707070$��1q�61   �� 57      $��42��6   $	��Top=�6$   .��58      �� -   5        $��labelPopupText��58       $
��Wrap=�66   
���   �
�������$��Choose the build location��6p   $��center=�6�   $ Center=�6�   $	��154��6�   59      �� 5:      -   5        $��lstboxInstallPaths��5:      
���   �
�������$��0,25,0,0q�6Z   6l   5;      5<      5=      5>      