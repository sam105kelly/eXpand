﻿#DropDB XpandSystemTesterEasyTest

#Application XpandSystemTester.Web
#Application XpandSystemTester.Win

*UseModel
#IncludeFile ..\Login.inc

*Action Navigation(PreventDataLoading.Default)
*Action New(Prevent Data Loading Object)
*FillForm
 Name = Tolis Bekiaris
*Action Save and New
*FillForm
 Name = Tolis
*Action Save and New
*FillForm
 Name = eXpandFramework
*Action Save and Close
*Action Navigation(PreventDataLoading.Default)
*CheckTable
 RowCount = 3