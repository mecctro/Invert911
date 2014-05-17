REM call "C:\Program Files (x86)\WiX Toolset v3.8\bin\heat.exe" project "InvertCommon.csproj" -pog:Binaries -ag -template:fragment -out InvertCommonProject.wxs
REM call "C:\Program Files (x86)\WiX Toolset v3.7\bin\heat.exe"  dir "$(TargetDir)."  -var var.WixDemo.TargetDir -dr APPLICATIONFOLDER  -cg Binaries -ag -scom -sreg -sfrag –srd -o "$(SolutionDir)Installer\$(ProjectName).Binaries.wxs"

call "C:\Program Files (x86)\WiX Toolset v3.8\bin\heat.exe" project "InvertCommon.csproj" -pog Binaries -pog Content -pog Documents -ag -cg InvertCommonBinaries -out InvertCommonProject.wxs



pause
