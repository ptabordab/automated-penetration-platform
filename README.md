# Automated Penetration Platform (APM)
Cybersecurity University of Toronto Bootcamp Final Project - Automated Penetration Platform


### Overview
Automated Penetration Platform leverages a process of using advanced testing tools to
evaluate a system’s security architecture.It helps identify most, if not all, of the security
risks with in your network by implementing it regularly to stop cyber threats and attacks.
Automated Penetration Platform is an advanced form of manual penetration testing that
leverages machine learning and algorithms to find flaws in systems, highlighting
vulnerabilities speedily. Assessing vulnerabilities present in your network or web
applications, Automated Penetration Platform helps you stay ahead of cybercriminals.

Once detected, loopholes can be blocked to prevent intrusion.



### Vision

An Automatic Penetration Platform (APP) is a software tool
that automates penetration testing by executing code to
perform discovery (reconnaissance) using nmap.

Once a machine is identified, it uses a fixed set of Metasploit
exploits against the target
and generates logs that can be displayed in a Splunk dashboard.

The APP uses Docker/Docker Compose to manage the environment
and Kali as the operating system.

The APM is designed to simulate real-world attacks and identify
vulnerabilities in the system.
It is a powerful tool that can help organizations identify
and fix security issues before they are exploited by attackers.

Please note that the APM is still in development and
more details will be available soon.



### Benefits

Automated Penetration Platform provides a number of advantages to testers and organizations.

Some of these benefits include:

**Time-saving**:
Automated tools can significantly reduce the time required for penetration testing. Reports can be generated almost instantly after a test is completed, which is not always possible with manual testing.


**Multi-tasking**: Automated tools can execute multiple tests simultaneously,
which is not possible with manual testing.

**Frequency**: Automated tool scan replicate tests as of ten as needed, sometimes
multiple times a day.This helps testers stay on top of security and vulnerability
issues with in the system.

**Stress reduction**: Automated testing can reduce stress levels for testers and
developers, allowing them to focus on other projects and tasks that require
human attention.

**Ease of updating**: Automated tools can be easily updated to reflect recent
pen-testing procedures and detect newer intrusion models. This is possible
through an update made available by our developers



### An efficient alternative to manual testing
Automated testing has gained significant attention and adoption in recent years. Most developers and testers use automated tools to promote efficiency and save time. While the benefits of these tools are numerous, they are not yet a complete alternative to human testers. Automated tools are still limited in test scope and applicability. For instance, while an automated tool may be perfect for running regression tests and analysis, it definitely cannot handle exploratory tests. Exploration testing requires the experiential and analytical skills of the tester. Additionally, automation is still limited in the area of user-experience testing. For example, visual elements and placements of tabs and menu. Real user feedback remains appropriate and needed for QA. Automated tools are prone to bugs and technical faults, just like human testers. Therefore, automatic testing and human testing should work collaboratively for efficient and better results.



### Suitability

Before employing an automated tool/platform for your penetration testing, here are a few things to consider:

**Identify your test needs**:
The first step is to identify the type of test you need to execute on your system and to what extent the test should be carried out.
This should depend on the use and need of the system.

For example, the test required for an
an internet banking platform would undoubtedly differ and may necessitate a more rigorous process than that required for a school portal.


**Identify test methods**: The next
step is to identify the appropriate test method that best suits your needs.
It may be automated, manual, or a combination of both.

**Schedule a test date**:
Draw up a timeline for your testing activity.
Penetration testing  frequently requires engaging in different activities
over some time.
To meet your time target and not over stress the system, it is best to schedule
testing activities.

**Identify the appropriate test tools**:
There are various automated tools by different developers in the market for penetration testing.
Some may be more sophisticated than others, offer different services,
and some tools may be selective to certain operating systems.

**Determine the required test frequency**: It is important to determine the
required test frequency.
This could be an industry standard or a professional choice.
Whichever one, determining a periodic retest time and sticking
to it is important part of a penetration test.
You need to have records of test results for the
present.
These reports could also act as a guide in the future.


### Summary
APP is a versatile platform performing a range of functions to test the security of a system. It can scan a system for vulnerabilities, simulate an attack, and identify weaknesses and frailties. These three major functionalities can work independently or in tandem to execute a pen-test.The W3AF is equipped with a variety of tools that make it an efficient pen-test tool.


## System Requirements
1. Base OS, we can use Kali Linux or Ubuntu
2. If using Ubuntu, you will have to install nmap
3. If using Ubuntu, you will have to install metasploit framework
4. Docker (and Docker Compose)
5. NodeJS
6. Splunk as a container
7. Metasploitable 2 as a container
8. MondoDB as a container
9. Wordpress and MySQL as a container


## Installattion Steps
1. Install VirtualBox
2. Install Ubuntu (and set user as root - diisabled by default -)
   *NOTE*: By default ubuntu disable root user by not assigning a password

   We need to add the username in sudoers file to be allowed issue sudo commands

   ```bash
   sudo su 
   usermod -aG sudo username
   ```

3. Update Kernel headers
4. Install VirtualBox Guess Add-on
5. Install Docker and Docker Compose
6. Install NodeJS and npm
7. Installa nmap
8. Install metasploit Framework
9. Install Nessus
10. Install git




## Limitations



## npm dependencies
1. npm i -D typescript
2. npm i node-npm




## Documentation
1. [How to install NodeJS on Ubuntu](/docs/nmap/how_to_install_nodejs_on_ubuntu.md)
2. [How to install nmap on Ubuntu](/docs/nmap/how_to_install_nmap_on_ubuntu.md)
3. [How to install Splunk in Docker Compose](/docs/splunk/how_to_install_splunk_in_docker.md)
4. [How to install Nessus on Ubuntu](/docs/nessus/how_to_install_nessus.md)
5. [NodeJS and Typescript](https://nodejs.org/en/learn/getting-started/nodejs-with-typescript)
6. [Typescript](/docs/typescript/typescript.md)
7. [Docker/Docker Compose](/docs/docker/how_to_install_docker_on_ubuntu.md)
8. [How to install git on Ubuntu](/docs/git/how_to_install_git_on_ubuntu.md)
9. [How to install Docker on Ubuntu](/docs/docker/how_to_install_docker_on_ubuntu.md)
10. [How o install metasploit framework on Ubuntu](/docs/metasploit/how_to_install_metasploit_framework_on_ubuntu.md)
