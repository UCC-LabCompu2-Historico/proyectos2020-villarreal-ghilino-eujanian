/**
 * Conversor de euro a dolar
 * @method conversor
 * @param {string} id - el id de los inputs
 * @param {number} valor - El valor de cada input mencionado
 * @return
 */


function conversor(id, valor) {
    var euro, dolar;



    if (valor.includes(",")){
        valor = valor.replace(",",".");
    }
    if (isNaN(valor)){
        alert('Se ingreso un valor no numerico')
        euro = "";
        dolar = "";
    } else if (id=="euro"){
        euro = valor;
        dolar = 0.89*valor;
    } else if (id=="dolar"){
        euro = valor*1.13;
        dolar = valor;
    }

    document.form_donaciones.valor_dolar.value = Math.round(dolar*100)/100;
    document.form_donaciones.valor_euro.value = Math.round(euro*100)/100;


}


function donar1(){
    var dolar;
    dolar = document.getElementById("dolar").value;
    if (dolar>0) {
        alert('Gracias por su donacion!')
    } else {
        alert('Su donacion no fue procesada, por favor revise los datos ingresados')
    }


}

