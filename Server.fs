namespace KestrelTest

module Server = 
    open System
    open System.IO
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Http


    type Startup() = 
        member this.Configure (app : IApplicationBuilder) = 
            app.Run (fun ctx ->
                printfn "%A - %A - %A - %A" ctx.Request.Method ctx.Request.PathBase ctx.Request.Path ctx.Request.QueryString
                sprintf "%s: %s" ctx.Request.Method "Hello world" |> ctx.Response.WriteAsync     
            )

    let create baseAddress =
        WebHostBuilder()
            .UseKestrel()
            .UseUrls([| baseAddress |])
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .Build()
            .Run()
