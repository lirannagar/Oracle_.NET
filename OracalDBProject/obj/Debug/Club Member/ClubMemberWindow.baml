   M S B A M L   `   `   `  ����J  FOracalDBProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:OracalDBProject.Club_MemberOracalDBProject.Club_Member  5   	   2    ,OracalDBProject.Club_Member.ClubMemberWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:OracalDBProject.Club_Member     5   	     � WindowStartupLocation$  CenterScreen=�5   
    � Title$ ClubMemberWindow��5	   	   $	��300��6"   $	��300��6/   .��5
      �  � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��13* �6   .+�5   
   �� -   5         ��Name$ firstNameClubMemberLabel��5      $��First Name:��62   $
��Left=�6H   $��	10,30,0,0q�6c   $	��Top=�6v   �� 5   
   -   5        $ lastNameClubMemberLabel��5      $��
Last Name:��61   $
��Left=�6F   $��	10,56,0,0q�6a   $	��Top=�6t   $��2��6�   �� 5   
   -   5        $ passwordClubMember��5      $��	Password:��6,   $
��Left=�6@   $��	10,75,0,0q�6[   $	��Top=�6n   $��63��6�   $��2��6�   �� 5   
   -   5        $  phoneNumberClubMemberLabel��5      $��Phone Number:��64   $
��Left=�6L   $��10,19.067,0,0q�6g   $	��Top=�6~   $��1��6�   �� 5   
   -   5        $ emailClubMemberLabel��5      $��Email:��6.   $
��Left=�6?   $��10,42.8,0,0q�6Z   $	��Top=�6o   $��1��6�   �� 5   
   -   5        $ addressClubMemberLabel��5      $��Address:��60   $
��Left=�6C   $��10,67.067,0,0q�6^   $	��Top=�6u   $��25��6�   $��1��6�   �� 5   
   -   5         ��Name$ firstNameTextBox��5      $
��Left=�6,   $��23��6G   $��	79,33,0,0q�6S    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��195��6�   �� 5   
   -   5        $ lastNameTextBox��5      $
��Left=�6+   $��23��6F   $��	79,56,0,0q�6R   $
 Wrap=�6e   $	��Top=�6y   $	��195��6�   $��2��6�   G� 5   
   -	   5         G�Name$ clubMemberPasswordBox��5      $
��Left=�65   $��78,4.067,0,0q�6P   $	��Top=�6f   $	��196��6~   $��1��6�   �� 5   
   -
   5        $ phoneNumberTextBox��5      $
��Left=�6.   $��23��6I   $��103,22.067,0,0q�6U   $
 Wrap=�6m   $	��Top=�6�   $	��171��6�   $��1��6�   �� 5   
   -   5        $ emailClubMemberTextBox��5      $
��Left=�62   $��23��6M   $��78,45.067,0,0q�6Y   $
 Wrap=�6p   $	��Top=�6�   $	��196��6�   $��1��6�   �� 5   
   -   5        $ addressClubMemberTextBox��5      $
��Left=�64   $��23��6O   $��78,68.8,0,0q�6[   $��1��6p   $
 Wrap=�6}   $	��Top=�6�   $	��196��6�   �� 5   
   -   5         ��Name$ backButtonClubMember��5      $
��Back��6/   $
��Left=�6>   $��4,6,0,0q�6Y   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ singUpClubMeberButton��5      $��Sing Up��60   $
��Left=�6B   $��68,117.8,0,0q�6]   $��1��6s   $	��Top=�6�   $	��150��6�   6�   5      5      