"use strict";
//Задание 1
    var a = 1, b = 1, c, d;
    c = ++a; alert(c);           // 2 сначала происходит добавлени потом присвоение
    d = b++; alert(d);           // 1 сначала присвоение потом добавление
    c = (2+ ++a); alert(c);      // 5  a = 2 и в этом примере мы сначала уведичиваем значение а на 1 а потом прибавляем 2
    d = (2+ b++); alert(d);      // 4  b = 2 здесь сначала происходит сложение чисел а затем увеличение b
    alert(a);                    // 3 вывод а (нечего коментировать)
    alert(b);                    // 3 вывод b (нечего коментировать)
    
//Задание 2
    var a = 2;
    var x = 1 + (a *= 2); //x будет равен 5 так как a *= 2 здесь мы умножаем а на 2 и прибаляем 1
    alert(x);//для проверки
//Задание 3
    let a = 2;
    let b = -4;
if( a > 0 && b > 0 ) {
    alert(a - b);                     
 }
 else if( a < 0 && b < 0 ) {
    alert(a * b);                      
 }
 else if( (a >= 0 && b <= 0) || (a >= 0 && b <= 0)) {
    alert(a + b);                     
 }
//Задание 4 не совсем понял зачем выводить числа от а до 15 ведь тогда проще использовать for здесь я так понимаю надо просто научиться использовать  switch так что вот
let a = 2;
switch(a){
    case 1:
        alert(1);
        break;
    case 2:
        alert(2);
         break;
    case 3:
        alert(3);
        break;
    case 4:
        alert(4);
        break;
    case 5:
        alert(5);
        break;
    case 6:
        alert(6);
        break;
    case 7:
        alert(7);
        break;
    case 8:
        alert(8);
        break;
    case 9:
        alert(9);
        break; 
    case 10:
        alert(10);
        break;
    case 11:
        alert(11);
        break;
    case 12:
        alert(12);
        break;
    case 13:
        alert(13);
        break;
    case 14:
        alert(14);
        break;
    case 15:
        alert(15);
        break;
    default:
        alert('Число не входит в промежуток от 0 до 15(или не целое)');
 }
 //Задание 5 return вроде не нужен, но в задании он стоит не знал как по другому использовать
 function multiplication_numbers(x, y){
       alert(x * y);
       return;
       alert(x + y);//это не выполнится
 }
 function addition_numbers(x, y){
    alert(x + y);
    return;
}
function subtraction_numbers(x, y){
    alert(x - y);
    return;
    
}
function division_numbers(x, y){
    alert(x / y);
    return;
    
}

//Задание 6
function mathOperation(arg1, arg2, operation){
    switch(operation){
        case '+':
            multiplication_numbers(arg1, arg2);
            break;
        case '-':
            addition_numbers(arg1, arg2);
             break;
        case '*':
            subtraction_numbers(arg1, arg2);
            break;
        case '/':
            division_numbers(arg1, arg2);
            break;
        default:
            alert('Неизвестная операция');
     }
}

   