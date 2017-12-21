# Project 3

Adding socket activation to C# daemons

## Project Structure

This project contains three different programs. Each one uses a different method of activation:

 * SocketService: A "normal" daemon that receives a socket and must accept.
 * SocketService-Accepted: A damone that receives an already accepted socket from systemd
 * SocketService-Inet: Receives an accepted socket from stdin/stdout

## Building

Execute ```dotnet build``` on the command line.

## Running

Execute the specified ```systemd-socket-activate``` command. You must then use nc/telnet to connect to the daemon.

To run as a service, copy the project3.service file to ```~/.config/systemd/user/```. Run ```systemctl start --user <service file>```.

## Publishing

To publish, run ```sudo dotnet publish -o /opt/ProjectName```


