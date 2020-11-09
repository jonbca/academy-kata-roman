module Roman.Roman

open System

let convertDigit (roman: char) =
  match roman.ToString().ToUpper() with
  | "I" -> 1
  | "V" -> 5
  | "X" -> 10
  | "L" -> 50
  | "C" -> 100
  | "D" -> 500
  | "M" -> 1000
  | _ -> invalidArg "roman" "not a roman digit"

let convertRoman (roman: string) =
  let numbers = List.map convertDigit (List.ofSeq roman)

  let rec arabify n xs =
    match xs with
    | fst :: sec :: tail -> if (sec > fst) then (arabify (n + sec - fst) tail) else (arabify (n + fst) (sec :: tail))
    | fst :: tail -> arabify (n + fst) tail
    | [] -> n

  arabify 0 numbers

[<EntryPoint>]
let main argv =
  printfn "Hello World from F#!"
  0 // return an integer exit code
