C:\Factory\Tools\RDMD.exe /RC out

C:\Factory\SubTools\makeDDResourceFile.exe Resource out\Resource.dat Tools\MaskGZData.exe

C:\Factory\SubTools\CallConfuserCLI.exe AquaDiamond\AquaDiamond\bin\Release\AquaDiamond.exe out\AquaDiamond.exe
rem COPY /B AquaDiamond\AquaDiamond\bin\Release\AquaDiamond.exe out
COPY /B AquaDiamond\AquaDiamond\bin\Release\Chocolate.dll out
COPY /B AquaDiamond\AquaDiamond\bin\Release\DxLib.dll out
COPY /B AquaDiamond\AquaDiamond\bin\Release\DxLib_x64.dll out
COPY /B AquaDiamond\AquaDiamond\bin\Release\DxLibDotNet.dll out

C:\Factory\Tools\xcp.exe doc out
C:\Factory\Tools\xcp.exe C:\Dev\Fairy\Donut2\doc out

	MD out\�V�i���I�f�[�^
	C:\Factory\Tools\xcp.exe Resource\Scenario out\�V�i���I�f�[�^

C:\Factory\SubTools\zip.exe /PE- /RVE- /G out AquaDiamond
C:\Factory\Tools\summd5.exe /M out

IF NOT "%1" == "/-P" PAUSE
