namespace DatastructuresOOP

type StackImpl<'a> =
    | EmptyStack
    | StackNode of 'a * StackImpl<'a>

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Stack =        
    let hd x = 
        match x with
            | EmptyStack -> failwith "Empty stack"
            | StackNode(hd, tl) -> hd

    let pop x = 
        match x with
            | EmptyStack -> failwith "Empty stack"
            | StackNode(hd, tl) -> hd, tl
        
    let tl x =
        match x with
            | EmptyStack -> failwith "Emtpy stack"
            | StackNode(hd, tl) -> tl
        
    let cons hd tl = StackNode(hd, tl)
    
    let empty = EmptyStack
        
    let rec rev s =
        let rec loop acc = function
            | EmptyStack -> acc
            | StackNode(hd, tl) -> loop (StackNode(hd, acc)) tl
        loop EmptyStack s


// lifo
type Stack<'a>(s : StackImpl<'a>) =
    member x.Rev = Stack<'a>(Stack.rev s)
    member x.Push v = Stack<'a>(Stack.cons v s)
    member x.Pop () = 
        let v,s = Stack.pop s
        v, Stack<'a>(s)
    new() = Stack<'a>(Stack.empty)