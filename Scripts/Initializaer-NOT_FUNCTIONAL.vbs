Dim oItem, oShell, folderPath
Set oShell = CreateObject("Shell.Application")
Set oItem = oShell.BrowseForFolder(&H0, title, flag, dir)
If Not (oItem Is Nothing) Then
folderPath = oItem.ParentFolder.ParseName(oItem.Title).Path
bash ./Setup-Bash.sh
End If