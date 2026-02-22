//Бушуев Никита Николаевич БАС-1(2024)
//Вариант 2
open System

// Добавление элемента в начало списка
let addToStart a list = 
    a :: list

// Добавление элемента в конец списка
let addToEnd a list =
    list @ [a]

// Удаление первого вхождения элемента
let deleteFirst a list =
    match List.tryFindIndex (fun x -> x = a) list with
    | Some index -> list.[0..index-1] @ list.[index+1..]
    | None -> list

// Удаление элемента по индексу
let deleteByIndex index list =
    if index < 0 || index >= List.length list then
        list
    else
        list.[0..index-1] @ list.[index+1..]

// Проверка наличия элемента в списке
let find a list =
    List.contains a list

// Поиск индекса элемента
let findIndex a list =
    let rec search i = function
        | [] -> -1
        | head::tail when head = a -> i
        | head::tail -> search (i + 1) tail
    search 0 list

// Сцепка двух списков
let concatenate list1 list2 =
    list1 @ list2

// Получение элемента по индексу
let tryGetByIndex index list =
    if index < 0 || index >= List.length list then
        None
    else
        Some list.[index]

[<EntryPoint>]
let main argv =
    // Создаем начальный список
    let myList = [1; 2; 3; 4; 5]
    printfn "Начальный список: %A" myList
    printfn ""
    
    // 1. Добавление в начало
    let afterAddToStart = addToStart 0 myList
    printfn "1. После добавления 0 в начало: %A" afterAddToStart
    
    // 2. Добавление в конец
    let afterAddToEnd = addToEnd 6 myList
    printfn "2. После добавления 6 в конец: %A" afterAddToEnd
    
    // 3. Удаление элемента
    let afterDelete = deleteFirst 3 myList
    printfn "3. После удаления элемента 3: %A" afterDelete
    
    // 4. Удаление по индексу
    let afterDeleteByIndex = deleteByIndex 2 myList
    printfn "4. После удаления элемента с индексом 2: %A" afterDeleteByIndex
    
    // 5. Поиск элемента
    let has3 = find 3 myList
    printfn "5. Есть ли число 3 в списке? %b" has3
    
    let has10 = find 10 myList
    printfn "   Есть ли число 10 в списке? %b" has10
    
    // 6. Поиск индекса
    let index3 = findIndex 3 myList
    printfn "6. Индекс числа 3: %d" index3
    
    let index10 = findIndex 10 myList
    printfn "   Индекс числа 10: %d" index10
    
    // 7. Сцепка списков
    let listA = [1; 2; 3]
    let listB = [4; 5; 6]
    let concatenated = concatenate listA listB
    printfn "7. Сцепка списков %A и %A: %A" listA listB concatenated
    
    // 8. Получение по номеру
    match tryGetByIndex 10 myList with
    | Some element -> printfn "8. Элемент с индексом 10: %d" element
    | None -> printfn "8. Индекс 10 вне диапазона!"
    
    // Проверка с отрицательным индексом
    match tryGetByIndex -1 myList with
    | Some element -> printfn "   Элемент с индексом -1: %d" element
    | None -> printfn "   Индекс -1 вне диапазона!"
    
    0