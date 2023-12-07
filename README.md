# C# Advent Of Code 2023

Solutions for [2023 Advent Of Code challenges](https://adventofcode.com/2023) in C#

### Docker-only dev setup

Use temporary container with current directory volume:

```
$ docker run --rm -it -v $PWD:/app -w /app mcr.microsoft.com/dotnet/sdk:8.0 bash
# dotnet test --logger "console;verbosity=normal" aoc2023.csproj
# dotnet test --logger "console;verbosity=normal" aoc2023.csproj --filter aoc2023.day2
```

### VSCode Dev Container setup

VSCode can use devcontainers to be configured with the proper extensions and without dotnet executable locally installed.

Do do it, install the [related extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) (`ms-vscode-remote.remote-containers`) and reopen vscode in Dev Container mode.

> the first run can take some minutes to install and setup properly container and vscode extensions

If you want to open an additional bash session in the vscode container:

```
$ docker exec -it -w /workspaces/$(basename $PWD) <container-name> bash
# dotnet test --logger .........
```
