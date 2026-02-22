//Бушуев Никита Николаевич БАС-1(2024)
//Вариант 2
open System

printfn "Введите натуральное число"
let N = int(Console.ReadLine())

let rec multi x = 
    if x = 0 then 1
    else (x % 10) * multi (x / 10)

[<EntryPoint>]
let main argv =
    if N <= 0 then 
        printfn "Натуральное число не может быть отрицательным или равным нулю" 
    else 
        printfn "Произведение цифр: %d" (multi N)
    0