"use strict";
//Задание 1
let a = 0;
while( a <= 100 ) { 
    alert(a); 
    a++;
 }
 //Задание 2 , 3

 var storagedata = [
	{ id: 1, title: "Стол", vol: 12 ,cost:100 },
	{ id: 2, title: "Стул", vol: 300 ,cost:200 },
	{ id: 3, title: "Книга", vol: 5 ,cost:1300},
	{ id: 4, title: "Самолёт", vol: 2 ,cost:10},
	{ id: 6, title: "Ракета", vol: 12,cost:1200},
	{ id: 5, title: "Звездолёт", vol: 2,cost:1 }
];//корзина

function countBasketPrice(data) {//функция для нахождения суммы.
	summbs=0;
	data.forEach(item=>{
		summbs+=(item.vol*item.cost);
	});
	return summbs;
}
alert(countBasketPrice(storagedata));
// задание 4
let a = 0;
for (;a <= 9; alert(a++) ); 

// задание 5
for (var x = 1; x <= 20; x++) {
    for (var y = 1; y <= x; y++) {
        console.log('*');
    }
	console.log('\n');
}
   

   