

module TheMLApproach =
    open Datastructures
    let a = Stack.empty
    let ten = Stack.cons 10 a // stack only provides operations, internal structure not exposed
    let test = 
        match a with 
            | EmptyStack -> ()
            | _ -> ()

module TheOOPCompatibleApproach =
    
    open DatastructuresOOP

    let a = Stack.empty
    let ten = Stack.cons 10 a

    let oopStack = Stack()
    let addedTen = oopStack.Push 10


module UsingAbstractDataTypes =
    
    open ADT

    let test () = 
        let a = AssocList.ofList [1,"a"]
        let added = AssocList.addOrUpdate 2 "b" a
        // not allowed. let b = { list = [] }
        ()

[<EntryPoint>]
let main argv = 
    
    UsingAbstractDataTypes.test()
    


    0
