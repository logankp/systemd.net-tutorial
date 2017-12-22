# SocketService-Inet

This daemon is activated in the same way as the last one, but the socket is passed in on stdin/stdout.

Use ```systemd-socket-activate -a --inet -l 127.0.0.1:8080 dotnet SocketService-Inet.dll``` to run this one. Connect using telnet/nc. Ex: ```telnet localhost 8080```.

### Deploying

Run ```sudo dotnet publish -o /opt/Project3```. Copy the SocketService-Inet@.service and SocketService-Inet.socket to ```~/.config/systemd/user```. Run ```systemctl start --user SocketService-Inet.socket```. Note that when run this way, each incoming connection will spawn a new instance of the daemon.
