"use strict";
//Задание 1
    var Tc = 23;
    var Tf = (9 / 5) * Tc + 32
    alert(Tf);
//Задание 2
    var name = "Василий";
    var admin  = 123;
    admin = name;
    alert(admin);
//Задание 3
    var numstr = "108";
    var num  = 1000;
    var summ = numstr + num;
    alert(summ);
    //для сумирования используем знак "+" перед строковой переменной(она преобразуется в число)
    alert(num - + numstr);