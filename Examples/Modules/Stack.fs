namespace Datastructures

type 'a stack =
    | EmptyStack
    | StackNode of 'a * 'a stack

// needed if we want a class stack as well   
module Stack =        
    let hd = function
        | EmptyStack -> failwith "Empty stack"
        | StackNode(hd, tl) -> hd
        
    let tl = function
        | EmptyStack -> failwith "Emtpy stack"
        | StackNode(hd, tl) -> tl
        
    let cons hd tl = StackNode(hd, tl)
    
    let empty = EmptyStack
        
    let rec rev s =
        let rec loop acc = function
            | EmptyStack -> acc
            | StackNode(hd, tl) -> loop (StackNode(hd, acc)) tl
        loop EmptyStack s

