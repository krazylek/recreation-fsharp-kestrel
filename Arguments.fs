namespace KestrelTest


module Arguments =
    type ProgramMode = ModeServer | ModeClient

    type CommandLineOptions = {
        mode: ProgramMode;
        port: int;
        help: bool;
    }

    let rec parseCommandLineRec args optionsSoFar = 
        match args with 
        | [] -> 
            optionsSoFar  

        | "-m"::xs | "--mode"::xs -> 
            match xs with
            | "server"::xss -> 
                let newOptionsSoFar = { optionsSoFar with mode=ModeServer}
                parseCommandLineRec xss newOptionsSoFar 
            | "client"::xss -> 
                let newOptionsSoFar = { optionsSoFar with mode=ModeClient}
                parseCommandLineRec xss newOptionsSoFar 
            | _ -> 
                eprintfn "Mode needs a second argument"
                parseCommandLineRec xs optionsSoFar 

        | "-p"::xs | "--port"::xs -> 
            match xs with
            | p::xss -> 
                match System.Int32.TryParse(p) with
                | (true, port) ->
                    let newOptionsSoFar = { optionsSoFar with port=port }
                    parseCommandLineRec xss newOptionsSoFar 
                | _ -> 
                    eprintfn "Port needs to be an int"
                    parseCommandLineRec xss optionsSoFar 
            | _ -> 
                eprintfn "Port needs a second argument"
                parseCommandLineRec xs optionsSoFar 

        | "-h"::xs | "--help"::xs -> 
            let newOptionsSoFar = { optionsSoFar with help=true}
            parseCommandLineRec xs newOptionsSoFar 
            
        | x::xs -> 
            eprintfn "Option '%s' is unrecognized" x
            parseCommandLineRec xs optionsSoFar 

    let parseCommandLine argv = 
        let defaultOptions = {
            mode = ModeServer;
            port = 8090;
            help = false;
        }
        let args = argv |> List.ofSeq
        parseCommandLineRec args defaultOptions


//
// When available on .net core, Argu or CommandLineParser should be easier options
//

    // commandline style
    
    //type options = {
        //[ <Option('m', "mode", Required = true, HelpText = "set program mode: client | server | both")>] Mode : string;
        //[ <Option('p', "port", HelpText = "set server port")>] Port : string;
    //}

    //let result = CommandLine.Parser.Default.ParseArguments<options>(argv)
    //match result with
    //| :? Parsed<options> as parsed ->
        //match parsed with
        //|  
    //| :? NotParsed<options> as notParsed -> fail notParsed.Errors


    // Argu style
    
    //open CommandLine

    //type ProgramMode =
        //| Client = "client"
        //| Server = "server"
        //| Both = "both"

    //type ProgramOptions = 
        //| [<AltCommandLine("-p")>] Port of tcp_port: int
        //| [<Mandatory><AltCommandLine("-m")>] Mode of value:string
    //with
        //interface IArgParserTemplate with
            //member arg.Usage = 
                //match arg with
                //| Port _ -> "set server port"
                //| Mode _ -> "set program mode: client | server | both"
