## UWP Quick Shortcuts
A simple launcher for Windows's Action Center + Settings, for UWP Platform.

## Build
1. Install Visual Studio with Windows SDK 16299+ and UWP workload.
2. Clone this project, then open the solution file (.sln) in VS.
3. Build and run by click Local machine button (the button which has a green play icon)

## Screenshot(s)
![image](https://user-images.githubusercontent.com/77564176/188419704-6c0e8077-277b-4248-b3dd-0d658fe4bf72.png)
![image](https://user-images.githubusercontent.com/77564176/213872124-47e9a4e8-0ad2-4672-8a16-82d2d55b5269.png)

## Notes
* Basically I made this app for Windows 10 Mobile instead, on PC we have keyboard and mouse:)
* You can't open Action center on Windows 10 Mobile because ```ms-actioncenter://``` procotol which is used to open the Action center does not available on W10M.
* Actually I open Settings pages by protocol links (link [here.](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-settings-app))
