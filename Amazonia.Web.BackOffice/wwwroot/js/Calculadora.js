
function Operacoes(tipoOperacao) {
    var param1 = parseInt(txtPrimeiroValor.value);
    var param2 = parseInt(txtSegundoValor.value);
    var resultado = 0;

    switch (tipoOperacao) {
        case "somar":
            resultado = Somar(param1, param2);
            break;
        case "subtrair":
            resultado = Subtrair(param1, param2);
            break;
        case "multiplicar":
            resultado = Multiplicar(param1, param2);
            break;
        case "dividir":
            resultado = Dividir(param1, param2);
            break;
        default:
            alert("Ops, operacao invalida");
    }

    txtResultado.value = resultado;
}

function Somar(param1, param2) {
    return param1 + param2;
}

function Subtrair(param1, param2) {
    return param1 - param2;
}

function Multiplicar(param1, param2) {
    return param1 * param2;
}


function Dividir(param1, param2) {
    if (param2 == 0) {
        console.warn('Cuidado divisao por zero');
        alert('Cuidado Divisao por Zero');
        return;
    }        

    return param1 / param2;
}



var contador = 0;

function ImagemClicada() {
    contador++;
}