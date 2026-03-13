# How to install nmap on Ubuntu


To install Nmap on Ubuntu, you can use the package manager apt. Open a terminal and run the following commands:
Update the package list:

```bash
sudo apt update
```


Install Nmap:

```bash
sudo apt install nmap
```

This will download and install Nmap and its dependencies on your Ubuntu system. After the installation is complete, you can use Nmap from the command line.

For example:
```bash
nmap -v -A example.com
```


This command will perform a verbose and aggressive scan on the specified host (example.com in this case). Adjust the hostname or IP address accordingly for your scanning needs.

Remember to use Nmap responsibly and comply with legal and ethical standards. Unauthorized scanning of networks that you do not own or have explicit permission to scan is against the law and can result in serious consequences. Always ensure you have proper authorization before conducting any network scanning.
