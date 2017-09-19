
// top level function
let plus1 = fun (a : int) -> a + 1

let main () =
    // functions can be stored in variables
    // in functional speak: we bind the value `plus1`
    // to a identifier `a`.
    // a has type: int -> int 
    let a = plus1

    // let us call the function
    let b = plus1(2) // b = 3

    // in functional programming, we typically omit the
    // parenthesis, e.g.
    let b = plus1 2 // b = 3

    // functions can be defined within functions as well
    let multiply = fun (a : int) (b : int) -> a * b
    
    // each argument adds another -> to the type, thus:
    // multiply has type:
    // int -> int -> int

    let nine = multiply 3 4
    // arguments subsequently fill up the arguments
    // (int -> int -> int) 
    //   ^ 3   ^ 4
    //   |     |     fill up arguments from left hand side
    // we end up with a value of type int (since both parameters 
    // disappeared by applying arguments)

    // let us define a function which doubles its input value
    let duplicate  = fun a -> multiply 2 a

    // most functional languages allow to partially apply a function.
    // this means, calling a function with fewer arguments (as actually declared formally)
    let duplicate' = multiply 2
    // (int -> int -> int)
    //   ^      ^
    //   | 2    | remains a parameter 
    // thus, duplicate' has type: int -> int
    // in other words: whenever an a function definition's argument
    // is immediately applied to the body: fun a -> multiply 2 a
    // this is a called eta reduction (cmp `äquivalentsumformung`).

    // since lists are very important, most functional languages
    // provide special syntax to construct them on the fly 
    let a = [1;2;3] // list literal; items separated by ;

    // one central concept is called `map`. 
    // lists can be mapped (other strucutures as well, we will see this later on)
    // mapping a list applies a function to each element in the list.
    // map (fun a -> a + 1) [1;2;3] => [2;3;4]
    // in F#/OCaml, map is defined in the List module (for our purposes
    // at the moment this is similar to a namespace).

    // let us map over the list by using our previously defined multiply function
    let duplicateList = fun list -> List.map (fun x -> duplicate x) list

    // let us now simplify the code by applying `eta reduction`
    let duplicateList = fun list -> List.map duplicate list

    // again...
    let duplicateList = List.map duplicate

    ()