# Project 2

Adding support for logging to the systemd journal.

## Building

Execute `dotnet build` on the command line.

## Running

Execute `dotnet run` on the command line to run as a console application.

To run as a service, copy the project2.service file to `~/.config/systemd/user/`. Run `systemctl start --user project2.service` to start.

## Publishing

To publish, run `sudo dotnet publish -o /opt/Project2`

### Output

This service writes "Hello World!" and log messages every 2 seconds. You can see this by running `systemctl status --user project2.service`
