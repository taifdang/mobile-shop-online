

var quantity_product = Number(document.getElementById("quantity_product").value);   


document.getElementById("counter-minus").onclick = function(){   
    if(Number(document.getElementById("quantity_product").value) < 2){
        document.getElementById("quantity_product").value = '1';
    }
    else{
        quantity_product -=1;
        document.getElementById("quantity_product").value = quantity_product
    }
}

document.getElementById("counter-plus").onclick = function(){

    quantity_product +=1;
    document.getElementById("quantity_product").value = quantity_product
}










