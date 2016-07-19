namespace KestrelTest

open System.Net.Http
// Http.fs seems to be a nice higher level client

module Client = 

    let getAsync (url:string) =
        printfn "Sending get request to %s" url
        async {
            let httpClient = new HttpClient()
            let! response = httpClient.GetAsync(url) |> Async.AwaitTask
            let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            return content
        }

    let send address =
        let res = Async.RunSynchronously (getAsync address)
        printfn "received %s" res
