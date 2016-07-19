# recreation-fsharp-http

Playing with `.NET Core` and the [Kestrel](https://github.com/aspnet/KestrelHttpServer) HTTP server.

It involves:
- creating a very basic server
- testing a client request using HttpClient
- parsing command line args 

And soon:
- serializing json

Command line parsing is hand crafted, hope [Argu](https://github.com/fsprojects/Argu),
or lower level [CommandLineParser](https://github.com/gsscoder/commandline) to be available on .net core soon!

All of this running on Linux!

## How to install

Restore packages with:

```bash
dotnet restore
```


## Usage

``` bash
dotnet run -- [Options]

Options:
  -m, --mode   Either "client" or "server"
  -p, --port   Select port, default 8090
  -h           Display help
```


## License

[MIT](https://tldrlegal.com/license/mit-license)
