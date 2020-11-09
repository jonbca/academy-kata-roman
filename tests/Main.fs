open Expecto

[<Tests>]
let tests = testList "roman numerals" [
  testList "single roman digits" [
    test "roman numeral i" {
      let subject = 'I'
      let result = Roman.Roman.convertDigit subject
      Expect.equal result 1 "convert i to 1"
    }

    test "roman numeral x" {
        let subject = 'x'
        let result = Roman.Roman.convertDigit subject
        Expect.equal result 10 "convert x to 10"
    }

    test "roman numeral l" {
        let subject = 'l'
        let result = Roman.Roman.convertDigit subject
        Expect.equal result 50 "convert l to 50"
    }

    test "roman numeral c" {
        let subject = 'c'
        let result = Roman.Roman.convertDigit subject
        Expect.equal result 100 "convert c to 100"
    }

    test "roman numeral d" {
        let subject = 'd'
        let result = Roman.Roman.convertDigit subject
        Expect.equal result 500 "convert d to 500"
    }

    test "roman numeral m" {
        let subject = 'm'
        let result = Roman.Roman.convertDigit subject
        Expect.equal result 1000 "convert m to 1000"
    }

    test "not a roman numeral" {
        let subject = 'z'
        Expect.throws (fun _ -> Roman.Roman.convertDigit(subject) |> ignore) "z is not a roman numeral"
    }
  ]

  testList "roman numerals" [
    test "convert ii" {
      let subject = "ii"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 2 "convert ii to 2"
    }

    test "convert iii" {
      let subject = "ii"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 2 "convert ii to 2"
    }

    test "convert vi" {
      let subject = "vi"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 6 "convert vi to 6"
    }

    test "convert vii" {
      let subject = "vii"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 7 "convert vii to 7"
    }

    test "convert viii" {
      let subject = "viii"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 8 "convert viii to 8"
    }

    test "convert iv" {
      let subject = "iv"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 4 "convert iv to 4"
    }

    test "convert ix" {
      let subject = "ix"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 9 "convert ix to 9"
    }

    test "convert xl" {
      let subject = "xl"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 40 "convert xl to 40"
    }

    test "convert cd" {
      let subject = "cd"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 400 "convert cd to 400"
    }

    test "convert cm" {
      let subject = "cm"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 900 "convert cm to 900"
    }

    test "convert mcmxcix" {
      let subject = "mcmxcix"
      let result = Roman.Roman.convertRoman subject
      Expect.equal result 1999 "convert mcmxcix to 1999"
    }
  ]

  testList "bad roman numbers" [
    test "try converting abcd" {
      let subject = "abcd"
      Expect.throws (fun _ -> Roman.Roman.convertRoman(subject) |> ignore) "abcd is not a roman numeral"
    }

    test "try converting ICXXXXIIVV" {
      let subject = "ICXXXXIIVV"
      Expect.throws (fun _ -> Roman.Roman.convertRoman(subject) |> ignore) "ICXXXXIIVV is not a roman numeral"
    }
  ]
]


[<EntryPoint>]
let main args =
  runTestsWithCLIArgs [] args tests
