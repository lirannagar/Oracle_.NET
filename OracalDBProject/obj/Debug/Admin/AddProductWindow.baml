   M S B A M L   `   `   `  ����J  FOracalDBProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OracalDBProject.AdminOracalDBProject.Admin  5   	   1clr-namespace:OracalDBProjectOracalDBProject  5   	   ,    &OracalDBProject.Admin.AddProductWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OracalDBProject.Admin     5   	   9OracalDBProjectclr-namespace:OracalDBProject     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ AddProductWindow��5
   	   $��390.035��6"   $��313.866��63    � 	Resources 5      %   OracalDBProject.MarketsDBSource   marketsDBSource  pRODUCTSViewSource �� Source �� Source��%Y   &	        &	      7     5   
   6*   �� 5   
    6:   �� *
PRODUCTS+8   5      .��5      � $��0,0,3.8,7.6q�6    � DataContext# [ 6    .+�5   
   �� -   5         ��Name$ IDProductLabel��5      $	��ID:��6(   $
��Left=�66   $��	10,23,0,0q�6Q   $	��Top=�6d   $��46��6|   $��23��6�   �� 5   
   -   5        $ NamePeoductLabel��5      $��Name:��6*   $
��Left=�6:   $��	10,51,0,0q�6U   $	��Top=�6h    J� RenderTransformOrigin$ 0.288,0.047&�6�   $��46��6�   �� 5   
   -   5        $ QuantityProductLabel��5      $��	Quantity:��6.   $
��Left=�6B   $��	10,82,0,0q�6]   $	��Top=�6p   $ 0.712,0.745&�6�   �� 5   
   -   5         ��Name$ IDProductTextBox��5      $
��Left=�6,   $��23��6G   $��	78,23,0,0q�6S   	 �� TextWrapping$
	 Wrap=�6f   $	��Top=�6z   $	��215��6�   �� 5   
   -   5        $ NameProductTextBox��5      $
��Left=�6.   $��23��6I   $��	78,54,0,0q�6U   $
	 Wrap=�6h   $	��Top=�6|   $	��215��6�   �� 5   
   -   5        $ QuantityProducTextBox��5      $
��Left=�61   $��23��6L   $��	78,82,0,0q�6X   $
	 Wrap=�6k   $	��Top=�6   $	��215��6�   �� 5   
   -   5        
 ��Name$
 AddProductButton��5      $��Add Product��6+   $
��Left=�6A   $��
78,113,0,0q�6\   $	��Top=�6p   $	��215��6�   6�   �� 5   
   -	   5        $ ExplainLabelProduct��5      $��(can be empty)��6-   $
��Left=�6F   $��	25,29,0,0q�6a   $	��Top=�6t   $��53��6�   $��6(�6�   $��20��6�   �� 5   
   -
   5        $
 BackButtonProduct��5      $
��Back��6,   $
��Left=�6;   $��10,5,0,0q�6V   $	��Top=�6h   $��58��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridAddProduct��5      $
��Left=�6+   $��
19,155,0,0q�6F   $	��Top=�6Z   $	��188��6r   $	��274��6   ��6�   �� 5      5      