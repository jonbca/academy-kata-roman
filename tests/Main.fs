open Expecto

let tests = testList "roman numerals" [
  test "roman numeral i" {
    let subject = "i"
    let result = Roman.Roman.convert subject
    Expect.equal result 1 "convert i to 1"
  }
]

[<EntryPoint>]
let main args =
  runTestsWithCLIArgs [] args tests
