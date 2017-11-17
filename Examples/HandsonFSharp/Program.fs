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



type Tree<'k,'v> =
    | EmptyTree
    | TreeNode of ' k * 'v * Tree<'k,'v> * Tree<'k,'v>
    

[<EntryPoint>]
let main argv =


    let empty = EmptyTree
    
    let rec find key = function
        | EmptyTree -> None
        | TreeNode(k, v, l, r) ->
            if key = k then Some v
            elif key < k then find key l
            else find key r
        
    let rec insert key value = function
        | EmptyTree -> TreeNode(key,value, EmptyTree, EmptyTree)
        | TreeNode(hd, v, l, r) as node ->
            if hd = key then TreeNode(key,value,l,r)
            elif key < hd then TreeNode(hd, v, insert key value l, r)
            else TreeNode(hd, v, l, insert key value r)

    let ofList xs = List.fold (fun m (k,v) -> insert k v m) empty xs

    let rec toList t =
        match t with    
            | EmptyTree -> []
            | TreeNode(k,v,l,r) -> 
                (toList l) @ [k,v] @ (toList r)

    let t = ofList [("a",2);("b",3);("a",5)]
    let five = find "a" t // 5
    let t2 = insert "c" 10 t 
    let ten = find "c" t2 // 10
    let notFound = find "x" t2 // None

    let result = toList t2
 
    //let dirPath = @"..\..\"
    let dirPath = @"C:\Users\steinlechner\Desktop\aardvark.base\src"
    let files = Directory.EnumerateFiles( dirPath, "*.cs", SearchOption.AllDirectories) |> Seq.map File.ReadAllLines |> Seq.toArray

    let split lines = 
        lines |> Array.collect (fun (l : string) -> l.Split delimiters)

    let counts = 
        files |> mapReduceArray split id (fun (k,values) -> [|k, Seq.length values|])

    for e in counts |> Seq.sortByDescending snd |> Seq.take 100 do printfn "%A" e


    0 
