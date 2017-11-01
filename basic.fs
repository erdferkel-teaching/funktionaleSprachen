

let cons (x : 'a) (xs : list<'a>) = 
    x :: xs

let rec addEnd (e : 'a) (xs : list<'a>) =
    match xs with
        | x::xs -> x::addEnd e xs
        | [] -> [e]

let rec sum (xs : list<int>) = 
    match xs with
        | [] -> 0
        | x::xs -> x + sum xs

let rec sumBy (f : 'a -> int) (xs : list<'a>) = 
    match xs with
        | [] -> 0
        | x::xs -> f x + sumBy f xs

let sumBy2 = sumBy id

let flip f a b = f b a


let rec foldr f z xs = // aka List.foldBack
    match xs with   
        | x::xs -> f x (foldr f z xs) 
        | []-> z


let rec foldl f z xs = // aka List.fold
    match xs with
        | x::xs -> 
            let z = f z x
            foldl f z xs
        | [] -> z

let folded = foldl (fun acc x -> x :: acc) [] [1;2;3]
let foldBacked = foldr (fun x acc -> x :: acc) [] [1;2;3]

let rec revList3 xs =
    match xs with
        | [] -> []
        | x::xs -> revList3 xs @ [x]

let rec revList4 xs acc =
    match xs with   
        | [] -> acc
        | x::xs -> revList4 xs (x :: acc)
        
let rev2 xs = List.fold (flip cons) [] xs

let reverseList xs = foldl (flip cons) [] xs

let collect xs = foldr (@) [] xs

let b = collect [[1;2];[3;4]]