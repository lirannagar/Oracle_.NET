   M S B A M L   `   `   `  ����J  FOracalDBProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:OracalDBProjectOracalDBProject  5   	        OracalDBProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:OracalDBProject     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Log in Super Market��5	   	   $	��350��6%   $	��400��62   .��5
      � -   5         �Name$ startProgram��5
      4  .System.Windows.Automation.AutomationProperties   AutomationId$ 	formLogIn��6!   $��0,0,2,0q�6O    � ColumnDefinitions 5   
   �� 5      $	��44* �6   �� 5      $
��224* �6   �� 5      $	��32* �6   �� 5      $
��155* �6   �� 5      $	��62* �6   .+�5   
   �� -   5         ��Name$ UserNameLabel��5      $��
User name:��6'   $
��Left=�6<   $��
48,110,0,0q�6W   $	��Top=�6k   $	��119��6�   $��18(�6�   $��1��6�   �� 5   
   -   5         ��Name$ TextUserName��5      $��2��6(   $
��Left=�6<   $��23��6W   $��	3,121,0,0q�6c    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��120��6�   $��3��6�   �� 5   
   -   5        $ passwordBox��5      $
��Left=�6'   $��	3,157,0,0q�6B   $	��Top=�6U   $	��120��6m   $��2��6y   $��25��6�   $��3��6�   �� 5   
   -   5        $ PasswordLabel��5      $��	Password:��6'   $
��Left=�6;   $��
48,149,0,0q�6V   $	��Top=�6j   $	��120��6�   $��18(�6�   $��1��6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��	3,201,0,0q�6@   $	��Top=�6S   $	��120��6k   $��2��6w   $��3��6�   .@�5      �� $��Administrator��6   �� 5      	 �� 
IsSelected	 . $��Club Member��6-   5      �� 5   
   -   5        
 ��Name$
 LogInButton��5      $��Log In��6&   $
��Left=�67   $��114,258,0,0q�6R   $	��Top=�6g   $	��119��6    J� RenderTransformOrigin$ 
0.173,-0.4&�6�   $��3��6�   $��27��6�   $��1��6�   �� 5   
   -   5        $ 	RoleLabel��5      $��Role: ��6#   $
��Left=�64   $��
47,190,0,0q�6O   $	��Top=�6c   $	��120��6{   $��18(�6�   $��1��6�   �� 5   
   -	   5        $ TitleMsgLabel��5      $��WELCOME TO "SHAUL MARKET"��6'   $
��Left=�6U   $��	31,19,0,0q�6p   $	��Top=�6�   $	��285��6�   $��18(�6�   $��1��6�   $��4��6�   �� 5   
   -
   5        $ LogInMsgLabel��5      $��Please login��6'   $
��Left=�6>   $��
114,53,0,0q�6Y   $	��Top=�6m   $	��119��6�   $��18(�6�   $��1��6�   $��3��6�   5      5       