## SocketService

The daemon is activated by a connection to a systemd socket and responds with a message.

Run by typing ```systemd-socket-activate -l 127.0.0.1:8080 dotnet SocketService.dll```. This will cause systemd to listen on port 8080 and spawn SocketService when a connection is received. The program will then respond with a message and exit.
