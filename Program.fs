namespace KestrelTest

module main = 
    open System
    open System.IO

    let help = """
Usage: dotnet run -- [options]

Options:
    -m, --mode MODE     set program mode: client | server 
    -p, --port PORT     set server port
    -h, --help          print this help menu"""

    [<EntryPoint>]
    let main argv = 
        let args = Arguments.parseCommandLine argv

        match args.help with
        | true -> printfn "%s" help
        | _ ->
            let baseAddress = sprintf "http://localhost:%d/" args.port 
            match args.mode with
            | Arguments.ModeClient -> Client.send baseAddress
            | Arguments.ModeServer -> Server.create baseAddress

        0
