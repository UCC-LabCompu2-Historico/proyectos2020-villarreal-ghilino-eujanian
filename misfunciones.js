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
        dolar = 1.13*valor;
    } else if (id=="dolar"){
        euro = valor*0.89;
        dolar = valor;
    }

    document.form_donaciones.valor_dolar.value = Math.round(dolar*100)/100;
    document.form_donaciones.valor_euro.value = Math.round(euro*100)/100;


}

/**
 * Control de alertas y cant de donacion y llamada a funcion dibujarProgreso
 * @method donar1
 * @return
 */

var cuenta = 0;

function donar1(){
    var dolar;
    dolar = document.getElementById("dolar").value;



    if (dolar>0) {
        dibujarProgreso(dolar);
        alert('Gracias por su donacion!');
        cuenta = cuenta + 1;
        document.form_contador.cuenta.value = cuenta;
    } else {
        alert('Su donacion no fue procesada, por favor revise los datos ingresados')
    }


}
/**
 * Control de dibujo
 * @param {number} valor - cantidad a dibujar
 * @method dibujarProgreso
 * @return
 */


var progreso = 0;
function dibujarProgreso(valor) {
    var dolar = valor;
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    var xMax = canvas.width;
    var yMax = canvas.height;
    var posFinal = 0;


    ctx.fillStyle = "#00e009";
    ctx.fillRect(progreso,0,dolar,yMax);
    ctx.fill();

    progreso = progreso + dolar;

    if (dolar>xMax){
        alert('Hemos llegado al maximo de donaciones!');
        canvas.width=canvas.width;
    }

}



