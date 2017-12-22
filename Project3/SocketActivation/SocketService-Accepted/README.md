## SocketService-Accepted

This daemon is activated by systemd when a connection is received but the socket has already been accepted. All the daemon has to do is write to file descriptor 3 (the default fd used by systemd) to respond.

Use ```systemd-socket-activate -a -l 127.0.0.1:8080 dotnet SocketService-Accepted.dll``` to start the daemon, then connect to localhost:8080 to activate it.

### Deploying

Run ```sudo dotnet publish -o /opt/Project3```. Copy the SocketService-Accepted.service and SocketService-Accepted.socket to ```~/.config/systemd/user```. Run ```systemctl start --user SocketService-Accepted.socket```.
