call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"


msbuild src/RegistryHive.sln
start bin/Debug/Viewer.exe res/other/SYSTEM