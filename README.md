# UwpNumberFormatting

## UITest
* Install and run [WinAppDriver.exe](https://github.com/Microsoft/WinAppDriver/releases)
  * Windows Application Driver will then be running on the test machine listening to requests on the default IP address and port (127.0.0.1:4723)
  * Check the IP address and the port matches with [WindowsApplicationDriverUrl](NumberBoxApp.UITests/Session.cs#L15) in Session.cs
* Ensure just "NumberBoxApp.UITests" and "NumberBoxApp1" projects.
* Start "NumberBoxApp1" without debugger (CTRL + F5)
  * Once the app is deployed you can check if [AppID](NumberBoxApp.UITests/Session.cs#L16) is currect. Just enter "get-StartApps | Where-Object {$_.Name -like 'NumberBoxApp1'}" command in powershell
* Run Tests from Test Explorer 
