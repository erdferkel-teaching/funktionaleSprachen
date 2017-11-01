// classic framework
let mapReduceList (m : 's -> list<'m>) (selector : 'm -> 'k) (reduce : 'k*list<'m> -> list<'r>) (xs : list<'s>) =
    xs |> List.collect m |> List.groupBy selector |> List.collect reduce

// without type annotations
let mapReduce m selector reduce xs =
    xs |> Seq.collect m |> Seq.groupBy selector |> Seq.collect reduce

// use array instead of list
let mapReduceArray m selector reduce xs =
    xs |> Array.collect m |> Array.groupBy selector |> Array.Parallel.collect reduce

// use parallel array implementation instead
let mapReduceParallel m selector reduce xs =
    xs |> Array.Parallel.collect m |> Array.groupBy selector |> Array.Parallel.collect reduce

    
open System
open System.IO

let delimiters =
    [| for code in 0 .. 256 do 
        let c = char code
        if System.Char.IsWhiteSpace c || System.Char.IsPunctuation c then
            yield c
    |]


[<EntryPoint>]
let main argv = 
    //let dirPath = @"..\..\"
    let dirPath = @"C:\Users\steinlechner\Desktop\aardvark.base\src"
    let files = Directory.EnumerateFiles( dirPath, "*.cs", SearchOption.AllDirectories) |> Seq.map File.ReadAllLines |> Seq.toArray

    let split lines = 
        lines |> Array.collect (fun (l : string) -> l.Split delimiters)

    let counts = 
        files |> mapReduceArray split id (fun (k,values) -> [|k, Seq.length values|])

    for e in counts |> Seq.sortByDescending snd |> Seq.take 100 do printfn "%A" e


    0 
