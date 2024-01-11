# Customizing VirtualBox

With VirtualBox Guest Additions enabled, using the virtual machine becomes a lot more convenient. Don’t believe me? Here are the important features that the Guest Additions offer:
* Mouse pointer integration: You no longer need to press any key to “free” the cursor from the Guest OS.
* Shared clipboard: With the Guest Additions installed, you can copy-paste between the guest and the host operating systems.
* Drag and drop: You can also drag and drop files between the host and the guest OS.
* Shared folders: This feature allows you to exchange files between the host and the guest. You can ask VirtualBox to treat a certain host directory as a shared folder, and the program will make it available to the guest operating system as a network share, irrespective of whether the guest actually has a network.
* Better video support: The custom video drivers that are installed with the Guest Additions provide you with extra high and non-standard video modes, as well as accelerated video performance. It also allows you to resize the virtual machine’s window. The video resolution in the guest will be automatically adjusted, as if you had manually entered an arbitrary resolution in the guest’s Display settings.
* Seamless windows: The individual windows that are displayed on the desktop of the virtual machine can be mapped to the host’s desktop, as if the underlying application was actually running on the host.
* Generic host/guest communication channels: The Guest Additions enable you to control and monitor guest execution. The “guest properties” provide a generic string-based mechanism to exchange data bits between a guest and a host, some of which have special meanings for controlling and monitoring the guest. Applications can be started on the Guest machine from the Host.
* Time synchronization: The Guest Additions will resynchronize the time with that of the Host machine regularly. The parameters of the time synchronization mechanism can be configured.
* Automated logins: Basically credentials passing, it can be a useful feature.


Before running the Guest Add-on CD please install this packages

```bash
sudo apt install build-essential dkms linux-headers-generic

```
