# Project 1

Getting started building a systemd service.

## Building

Execute `dotnet build` on the command line.

## Running

Execute `dotnet run` on the command line to run as a console application.

To run as a service, copy the project1.service file to `~/.config/systemd/user/`. Run `systemctl start --user project1.service` to start.

## Publishing

To publish, run `sudo dotnet publish -o /opt/Project1`

### Output

This service writes "Hello World!" every 2 seconds. You can see this by running `systemctl status --user project1.service`
