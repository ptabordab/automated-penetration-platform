#  How to Install Node.js on Ubuntu

1. Open a terminal on your Ubuntu machine.
2. Update the package repository information:
```bash
sudo apt update
```
3. Install Node.js and npm (Node Package Manager) using the following command:
```bash
sudo apt install nodejs npm
```

To check if Node.js and npm have been successfully installed, you can run the following commands to display their versions:
```bash
node -v
npm -v
```

This should display the installed versions of Node.js and npm.

*NOTE*: You might get an older version of NnodeJs (12.x) which is usually not suitable for modern development 
follow this steps to use 16.x - https://computingforgeeks.com/how-to-install-node-js-on-ubuntu-debian/ or 
https://unix.stackexchange.com/questions/627635/upgrading-nodejs-on-ubuntu-how-to-fix-broken-pipe-error
