C:\Factory\Tools\RDMD.exe /RC out

C:\Factory\SubTools\makeDDResourceFile.exe Resource out\Resource.dat Tools\MaskGZData.exe

C:\Factory\SubTools\CallConfuserCLI.exe VioletDiamond\VioletDiamond\bin\Release\VioletDiamond.exe out\VioletDiamond.exe
rem COPY /B VioletDiamond\VioletDiamond\bin\Release\VioletDiamond.exe out
COPY /B VioletDiamond\VioletDiamond\bin\Release\Chocolate.dll out
COPY /B VioletDiamond\VioletDiamond\bin\Release\DxLib.dll out
COPY /B VioletDiamond\VioletDiamond\bin\Release\DxLib_x64.dll out
COPY /B VioletDiamond\VioletDiamond\bin\Release\DxLibDotNet.dll out

C:\Factory\Tools\xcp.exe doc out
C:\Factory\Tools\xcp.exe C:\Dev\Fairy\Donut2\doc out

C:\Factory\SubTools\zip.exe /PE- /RVE- /G out VioletDiamond
C:\Factory\Tools\summd5.exe /M out

IF NOT "%1" == "/-P" PAUSE
