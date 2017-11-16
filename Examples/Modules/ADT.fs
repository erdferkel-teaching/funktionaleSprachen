namespace ADT

type AssocList<'k,'v> = private { list : list<'k*'v> }

module AssocList =
    
    let ofList xs = { list = xs }

    let addOrUpdate (k : 'k) (v : 'v) (l : AssocList<'k, 'v>) =
        let rec doIt k v l =
             match l with
                | [] -> [k,v]
                | (k',v') :: xs -> 
                    if k' = k then (k',v) :: xs
                    else (k',v') :: doIt k v xs
        { list = doIt k v l.list }