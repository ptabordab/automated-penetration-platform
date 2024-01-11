# How to install git on Ubuntu

## Installing Git with Default Packages

1. Install git client

```bash
sudo apt install git

```

2. Validate

```bash
git --version
```


## Setting Up Git

Configuration can be achieved by using the git config command. Specifically, we need to provide our name and email address because Git embeds this information into each commit we do. We can go ahead and add this information by typing:

```bash
git config --global user.name "Your Name"
git config --global user.email "youremail@domain.com"
```

We can display all of the configuration items that have been set by typing:

``` bash
git config --list
```

Output
user.name=Your Name
user.email=youremail@domain.com

The information you enter is stored in your Git configuration file, which you can optionally edit by hand with a text editor of your choice like this (we’ll use nano):

```bash
nano ~/.gitconfig
~/.gitconfig contents
[user]
  name = Your Name
  email = youremail@domain.com
```

Press CTRL and X, then Y then ENTER to exit the text editor.
