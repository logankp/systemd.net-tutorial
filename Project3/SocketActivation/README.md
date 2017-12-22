# Project 3

Adding socket activation and systemd notify support to C# daemons

## Project Structure

This project contains three different programs. Each one uses a different method of activation:

 * [SocketService](SocketService): A "normal" daemon that receives a socket and must accept the connection
 * [SocketService-Accepted](SocketService-Accepted): A daemon that receives an already accepted socket from systemd
 * [SocketService-Inet](SocketService-Inet): Receives an accepted socket from stdin/stdout

## Building

Execute ```dotnet build``` on the command line.

## Running

Execute the ```systemd-socket-activate``` command specified in the README. You must then use nc/telnet to connect to the daemon.

To run as a service, copy the project.service and project.socket files to ```~/.config/systemd/user/```. Run ```systemctl start --user <socket file>```.

## Publishing

To publish, run ```sudo dotnet publish -o /opt/ProjectName```
