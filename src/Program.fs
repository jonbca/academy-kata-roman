module Roman.Roman

open System.Text.RegularExpressions

let convertDigit roman =
  match roman.ToString().ToUpper() with
  | "I" -> 1
  | "V" -> 5
  | "X" -> 10
  | "L" -> 50
  | "C" -> 100
  | "D" -> 500
  | "M" -> 1000
  | _ -> invalidArg "roman" "not a roman numeral"

let (|ValidRomanNumber|_|) (romanString: string) =
  let m =
    Regex("^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$").Match(romanString.ToUpper())

  if m.Success then Some romanString else None

let convertRoman roman =
  let numbers =
    match roman with
    | ValidRomanNumber roman -> roman |> List.ofSeq |> List.map convertDigit
    | _ -> invalidArg "roman" "not a roman number"

  let rec arabify n xs =
    match xs with
    | fst :: sec :: tail when sec > fst -> arabify (n + sec - fst) tail
    | fst :: sec :: tail -> arabify (n + fst) (sec :: tail)
    | fst :: tail -> arabify (n + fst) tail
    | [] -> n

  arabify 0 numbers

[<EntryPoint>]
let main argv =
  match argv with
  | [| roman |] -> printfn "%d" (convertRoman roman)
  | _ -> failwith "usage: dotnet run mcmlxxxiv"
  0 // return an integer exit code
