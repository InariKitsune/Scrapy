   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   
PrestamixC   PrestamixC.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     8metro,http://metro.mahapps.com/winfx/xaml/controls   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     � Title$  Scrapy��$	��608��$
��1019�� � Icon$ img/scrapy.ico��(   "MahApps.Metro.Controls.MetroWindow   RightWindowCommands +   %MahApps.Metro.Controls.WindowCommands  .@��� -    ��Name$ ThemeButton�� �� 
IsReadOnly . 
���   �.@��� $	��Red���� $��Green���� $
��Blue���� $
��Pink���� $��Yellow���� $��Purple���� $��Orange���� $��Brown���� $
��Lime���� $
��Teal�� �� 
IsSelected . �� $
��Grey���� $��Indigo���� $
��Cyan���� $��BlueGrey���� $��	LightBlue���� $��
LightGreen���� $��
DeepOrange���� $��
DeepPurple��.��� $��
10,0,13,10q�.+��� $��10,10,81,10q�-   'MahApps.Metro.Controls.TabControlHelper   IsUnderlined . .@��� -    ��Name$ pawnsTab��$��Empeños��$��0,0,0,-4q�.��� .+��� -   $ pawnSearchCategory��$��	10,10,0,0q�$	��Top=�$��30�� . $
��Left=�$	��125��.@��� $��Número de empeño���� $��CI del cliente���� $��Número de prenda���� $��Monto���� $��Unidad monetaria���� $��Estado���� -    ��Name$ pawnSearchCriteria��$��30��$��140,10,359,0q�	 �� TextWrapping$
	 Wrap=�$�� ��$	��Top=�
 �� 	MaxLength$
 50���� -    ��Name$ pawnSearchButton��$��
0,10,233,0q�$	��Top=�$��30��$��Right=�$	��121��.��]� $��99��$��27��.+��� -    ��Name$ searchImage��$��img/searchLight.png��$��32��$��	0,-7,0,-3q���  J� RenderTransformOrigin$ 
0.476,0.48&�$��56��$��0,0,0,4q�Buscar&   System.Windows.Controls.DataGrid  -     Name$ EmpeñosDataGrid��$��10,45,233,10q�   SelectionUnit$ FullRow=� �� SelectedItem$   ��$ �� IsSynchronizedWithCurrentItem$
 TrueY�   
IsReadOnly . �� -   $ BotonRegistrarEmpeños��$��
0,45,103,0q�$	��Top=�$��33��$��Right=�$	��125��.��]� $��99��$��27��.+��� -	   $ addImage��$��img/addLight.png��$��29���� $ 
0.476,0.48&�$��19��$��56��$	��0,4q�	Añadir�� -
   $ DeleteButton��$��
0,83,103,0q�$	��Top=�$��33��$��Right=�$	��125��.��]� $��98��$��27��.+��� -   $ deleteImage��$��img/closeLight.png��$��30��$ 	0.5,0.265&�$
��0,-6q��� $ 
0.476,0.48&�$��55��$��0,3,0,1q�
Eliminar�� -   $ 	EditSPawn��$��0,121,103,0q�$	��Top=�$��33��$ -1.16,2.091&�$��Right=�$	��125��.��]� $��Right=�$��91��$��23��.+��� -   $ 	editImage��$��img/editLight.png��$��29��$��0,-13q��� $ 
0.476,0.48&�$��19��$	��0,2q�$��49��Editar�� -   $ Archive_Pawn��$��0,159,103,0q�$	��Top=�$��33��$ -1.16,2.091&�$��Right=�$	��125��.��]� $��Right=�$��91��$��23��.+��� -   $ archiveImage��$��img/folderLight.png��$��29��$��0,-13q��� $ 
0.476,0.48&�$��19��$	��0,2q�$��53���� $�Archivar���� -   $ viewArchive��$��Ver archivados��$��	0,0,10,10q�$��33��$��Right=�$	��125��$��Bottom=��� -   $ 	pledgetab��$��Prendas��$��
-2,0,-2,-3q�.��� .+��� -   $ pledgeSearchCaterogy��$
��Left=�$��0,10,0,0q�$	��Top=�$	��125��$��30��$��1�� . .@��� $��Número de prenda���� $��Nombre de la prenda���� $��
Ubicación���� -   $ pledgeSearchCriteria��$��30��$��130,10,359,0q�$
	 Wrap=�$	��Top=�$��1��$�� ��$
 50���� -   $ pledgeSearchButton��$��
0,10,233,0q�$	��Top=�$��30��$��1��$��Right=�$	��121��.��]� $��99��$��27��.+��� -   $ searchImageP��$��img/searchLight.png��$��32��$��	0,-7,0,-3q��� $ 
0.476,0.48&�$��56��$��0,0,0,4q�Buscar  -   $ PrendasDataGrid��$��0,45,233,51q�$
 TrueY� . $��1���� -   $ DeletePledge��$��
0,45,103,0q�$	��Top=�$��33��$��Right=�$	��125��.��]� $��98��$��27��.+��� -   $ deleteImageP��$��img/closeLight.png��$��30��$ 	0.5,0.265&�$
��0,-6q��� $ 
0.476,0.48&�$��55��$��0,3,0,1q�
Eliminar�� -   $ 
EditPledge��$��
0,83,103,0q�$	��Top=�$��33��$ -1.16,2.091&�$��Right=�$	��125��.��]� $��Right=�$��91��$��23��.+��� -   $ 
editImage1��$��img/editLight.png��$��29��$��0,-13q��� $ 
0.476,0.48&�$��19��$	��0,2q�$��49���� $�Editar���� -   $ customersTab��$��Clientes��$��
-2,0,-2,-3q�.��� .+��� -   $ customerSearchCategory��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��125��$��30�� . .@��� $��CI del cliente���� $��Nombre���� $��Apellido paterno���� -   $ customerSearchCriteria��$��30��$��140,10,359,0q�$
	 Wrap=�$�� ��$	��Top=�$
 50���� -   $ customerSearchButton��$��
0,10,233,0q�$	��Top=�$��30��$��Right=�$	��121��.��]� $��99��$��27��.+��� -   $ searchImageC��$��img/searchLight.png��$��32��$��	0,-7,0,-3q��� $ 
0.476,0.48&�$��56��$��0,0,0,4q�Buscar  -    $ ClientesDataGrid��$��10,45,233,51q�$
 TrueY� . �� -!   $ DeleteCustomer��$��
0,45,103,0q�$	��Top=�$��33��$��Right=�$	��125��.��]� $��98��$��27��.+��� -"   $ deleteImageC��$��img/closeLight.png��$��30��$ 	0.5,0.265&�$
��0,-6q��� $ 
0.476,0.48&�$��55��$��0,3,0,1q�
Eliminar�� -#   $ EditCustomer��$��
0,83,103,0q�$	��Top=�$��33��$ -1.16,2.091&�$��Right=�$	��125��.��]� $��Right=�$��91��$��23��.+��� -$   $ 
editImage2��$��img/editLight.png��$��29��$��0,-13q��� $ 
0.476,0.48&�$��19��$	��0,2q�$��49���� $�Editar���� -%   $��
Depósitos��$��
-2,0,-2,-3q�.��� .+��� -&   $ WarehouseSearchCategory��$��	10,10,0,0q�$	��Top=�$��30�� . $
��Left=�$	��125��.@��� $��Número de almacen���� $��Nombre del almacen���� $��
Dirección���� $��Estado���� -'   $ WarehouseSearchCriteria��$��30��$��140,10,359,0q�$
	 Wrap=�$�� ��$	��Top=�$
 50���� -(   $ WarehouseSearchButton��$��
0,10,233,0q�$	��Top=�$��30��$��Right=�$	��121��.��]� $��99��$��27��.+��� -)   $ searchImage1��$��img/SearchLight.png��$��32��$��	0,-7,0,-3q��� $ 
0.476,0.48&�$��56��$��0,0,0,4q��� $�Buscar��  -*   $ AlmacenesDataGrid��$��10,45,233,10q�$ FullRow=�$   ��$
 TrueY� . �� -+   $ BotonRegistrarDeposito��$��
0,45,103,0q�$	��Top=�$��33��$��Right=�$	��125��.��]� $��99��$��27��.+��� -,   $ 	addImage1��$��img/addLight.png��$��29���� $ 
0.476,0.48&�$��19��$��56��$	��0,4q��� $�Añadir���� --   $ DeleteWarehouseButton��$��
0,83,103,0q�$	��Top=�$��33��$��Right=�$	��125��.��]� $��98��$��27��.+��� -.   $ deleteImage1��$��img/closeLight.png��$��30��$ 	0.5,0.265&�$
��0,-6q��� $ 
0.476,0.48&�$��55��$��0,3,0,1q��� $�Eliminar���� -/   $ EditSWarehouse��$��0,121,103,0q�$	��Top=�$��33��$��Right=�$	��125��.��]� $��Right=�$��91��$��23��.+��� -0   $ 
editImage3��$��img/editLight.png��$��29��$��0,-13q��� $ 
0.476,0.48&�$��19��$	��0,2q�$��49���� $�Editar��