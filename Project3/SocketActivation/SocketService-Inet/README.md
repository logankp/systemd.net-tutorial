# SocketService-Inet

This daemon is activated in the same way as the last one, but the socket is passed in on stdin/stdout.

Use ```systemd-socket-activate -a --inet -l 127.0.0.1:8080 dotnet SocketService-Inet.dll``` to run this one.
