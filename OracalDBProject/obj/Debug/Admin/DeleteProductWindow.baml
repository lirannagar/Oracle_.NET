   M S B A M L   `   `   `  ����J  FOracalDBProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OracalDBProject.AdminOracalDBProject.Admin  5   	   1clr-namespace:OracalDBProjectOracalDBProject  5   	   /    )OracalDBProject.Admin.DeleteProductWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OracalDBProject.Admin     5   	   9OracalDBProjectclr-namespace:OracalDBProject     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Delete Product��5
   	   $	��300��6    $��354.4��6-    � 	Resources 5      %   OracalDBProject.MarketsDBSource   marketsDBSource  pRODUCTSViewSource �� Source �� Source��%Y   &	        &	      7     5   
   6*   �� 5   
    6:   �� *
PRODUCTS+8   5      .��5      �  � DataContext# [ 6   $��10,10,-0.4,0.4q�6=    � RowDefinitions 5   
   �� 5      $
��159* �6   �� 5      $	��17* �6   �� 5      $	��84* �6   .+�5   
   �� -   5         ��Name$ BackButtonDeleteProduct��5      $
��Back��62   $
��Left=�6A   $��5,4,0,0q�6\   $	��Top=�6m   $��47��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridProductTable��5      $
��Left=�6-   $��	20,90,0,0q�6H   $	��Top=�6[   $	��160��6s   $	��288��6�   $��3��6�   ��6�   �� 6�   �� 5   
   -   5        $ SearchDeleteProductButton��5      $��Search��64   $
��Left=�6E   $��
264,29,0,0q�6`   $	��Top=�6t   $��59��6�   $��21��6�   6�   �� 5   
   -   5        	 ��Name$	 SearchProductDeleteLabel��5      $��Search:��62   $
��Left=�6D   $��5,26,0,0q�6_   $	��Top=�6q   �� 5   
   -   5        
 ��Name$ 
 textBoxSearchDeleteProduct��5      $
��Left=�66   $��21��6Q   $��
139,29,0,0q�6]    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $	 DeleteProductLabel��5      $��
ID Product��6,   $
��Left=�6A   $��4,49,0,0q�6\   $	��Top=�6n   �� 5   
   -   5        $
 textBoxDeleteProduct��5      $
��Left=�60   $��19��6K   $��
139,55,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��120��6�   �� 5   
   -	   5        $ DeleteButton��5      $��Delete��6'   $
��Left=�68   $��
264,55,0,0q�6S   $	��Top=�6g   $��59��6    J� RenderTransformOrigin$ 0.549,-0.132&�6�   6�   �� 5   
   -
   5         ��Name$  searchComboBoxDelteProduct��5      $��53,28,199.4,105.2q�67   .@�5      �� $��By Name��6   �� 5       �� 
IsSelected . $��By ID��6-   5       �� 5"   
   -   5        $ ShowAllProductButton��5"      $��Show All Products��6/   $
��Left=�6K   $��	139,4,0,0q�6f   $	��Top=�6y   $	��184��6�   6�   5#      5$      