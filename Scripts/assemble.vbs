Set oShell = CreateObject ("Wscript.Shell") 
Dim strArgs
strArgs = "cmd /c assemble.bat"
oShell.Run strArgs, 0, false