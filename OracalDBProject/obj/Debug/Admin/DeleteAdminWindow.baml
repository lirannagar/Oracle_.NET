   M S B A M L   `   `   `  ����J  FOracalDBProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OracalDBProject.AdminOracalDBProject.Admin  5   	   1clr-namespace:OracalDBProjectOracalDBProject  5   	   -    'OracalDBProject.Admin.DeleteAdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OracalDBProject.Admin     5   	   9OracalDBProjectclr-namespace:OracalDBProject     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ DeleteAdminWindow��5
   	   $	��300��6#   $��750.8��60    � 	Resources 5      %   OracalDBProject.MarketsDBSource   marketsDBSource  uSERSViewSource �� Source �� Source��%V   &	        &	      7     5   
   6*   �� 5   
    67   �� *USERS+8   5      .��5      �  � DataContext# [ 6   $��10,0,0.4,0.4q�6:    J� RenderTransformOrigin$ 0.5,0.5&�6P    � ColumnDefinitions 5   
   �� 5      $
��575* �6   �� 5      $
��119* �6   �� 5      $	��13* �6   �� 5      $	��20* �6   �� 5      $��6* �6   z�5   
   V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.006Q�6"   T� 5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dataGrid��5      $
��Left=�6%   $��	10,86,0,0q�6@   $	��Top=�6S   $	��159��6k   $	��674��6x   $��2��6�   ��6�   �� 6�   �� 5    
   -   5        
 ��Name$
 searchButtonDeleteWindow��5       $��Search��63   $
��Left=�6D   $��
539,60,0,0q�6_   $	��Top=�6s   $��48��6�   $��19��6�   $��2��6�   �� 5!   
   -   5         ��Name$ searchComboBoxDeleteAdmin��5!      $��229,57,182.2,179q�66   .@�5"      �� $��By Name��6   �� 5#       �� 
IsSelected . $��By ID��6-   5$      �� 5%   
   -   5         ��Name$ textBoxSearchDeleteAdmin��5%      $
��Left=�64   $��21��6O   $��
397,60,0,0q�6[    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��137��6�   �� 5&   
   -   5         ��Name$ searchLabelAdmin��5&      $��Search:��6*   $
��Left=�6<   $��
133,61,0,0q�6W   $	��Top=�6k   $��60��6�   �� 5'   
   -   5        $ deleteLabel��5'      $��Enter ID Admin:��6%   $
��Left=�6?   $��
133,30,0,0q�6Z   $	��Top=�6n   $ 0.403,-0.027&�6�   �� 5(   
   -   5        $ deleteTextBox��5(      $
��Left=�6)   $��23��6D   $��
397,32,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��137��6�   �� 5)   
   -	   5        $
 deleteButtonAdmin��5)      $��2��6,   $��Delete��6@   $
��Left=�6Q   $��
539,34,0,0q�6l   $	��Top=�6�   $��49��6�   6�   �� 5*   
   -
   5        $
 showAllAdminsButton��5*      $��Show All Admins��6.   $
��Left=�6H   $��	397,8,0,0q�6c   $	��Top=�6v   $	��190��6�   $��2��6�   6�   �� 5+   
   -   5        $
 
backButton��5+      $
��Back��6%   $
��Left=�64   $��10,8,0,0q�6O   $	��Top=�6a   $��75��6y   6�   5-      5.      