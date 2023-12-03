# C# Advent Of Code 2022

Solutions for [2023 Advent Of Code challenges](https://adventofcode.com/2023) in C#

### Docker-only dev setup

Use temporary node container with current directory volume:

```
$ docker run --rm -it -v $PWD:/app -w /app mcr.microsoft.com/dotnet/sdk:8.0 bash
# dotnet test app.csproj
```
