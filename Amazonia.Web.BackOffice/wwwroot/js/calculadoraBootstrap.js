var tema = 0;
var primeiroValor = 0;
var limpar = false;
var operadorGlobal = "";


function MudarTemaBootstrap() {
    var href = "https://bootswatch.com/5/sandstone/bootstrap.min.css";
    tema++;


    switch (tema) {
        case 1:
            href = "https://bootswatch.com/5/cerulean/bootstrap.min.css"
            break;
        case 2:
            href = "https://bootswatch.com/5/darkly/bootstrap.min.css"
            break;
        case 3:
            href = "https://bootswatch.com/5/cyborg/bootstrap.min.css"
            break;
        default:
            href = "https://bootswatch.com/5/sandstone/bootstrap.min.css";
            tema = 0;
    }

    var title = document.getElementById("meuTitulo");
    title.innerText = href;

    var link = document.getElementById("meuCss");
    link.href = href;
}


function AtualizarDisplay() {

    var agora = new Date();
    var hora = agora.getHours();
    var minuto = agora.getMinutes();
    var segundo = agora.getSeconds();

    var title = document.getElementById("meuTitulo");
    title.innerText = hora + ":" + minuto + ":" + segundo;;
}


//setInterval('AtualizarDisplay()', 1000);
//setInterval('MudarTemaBootstrap()', 10000);


function LimparDisplayCalculadora() {
    //Exemplo com DocumentObjectModel
    var display = document.getElementById("txtDisplay");
    display.value = "0";
    primeiroValor = 0;
    operadorGlobal = "";

    //exemplo com JQUERY
    $("#txtAreaDeTestes").val("");
}


function AtualizarDisplay(parametro) {
    if (limpar) {
        $("#txtDisplay").val("0");
        limpar = false;
    }

    var display = document.getElementById("txtDisplay");
    if ((display.value == "0" || display.value == "Infinity") && parametro != ".") {
        display.value = "";
    }

    if (display.value != "Infinity") {
        $("#txtDisplay").css("color", "blue");
    }

    display.value += parametro;
}


function ApagarUltimoElementoDigitado() {
    var display = document.getElementById("txtDisplay");
    var valorAtual = display.value;
    var posicaoApagar = valorAtual.length >= 1 ? valorAtual.length - 1 : 0;

    var valorAposApagar = valorAtual.substring(0, posicaoApagar);

    if (valorAposApagar.length == 0) {
        valorAposApagar = "0";
    }

    display.value = valorAposApagar;
}


function AlterarSinal() {

    /*
    //ExemploComDOM
    var display = document.getElementById("txtDisplay");
    var valorAtual = display.value;
    */

    //ExemploJQuery
    var valorAtual = $("#txtDisplay").val();
    var sinal = valorAtual[0];

    if (sinal == 0 && valorAtual.length == 1) {
        //GuardCondition -- Boa prática defendida por Uncle Bob         
        return;
    }


    if (sinal != "-") {
        valorAtual = "-" + valorAtual;
    } else {
        valorAtual = valorAtual.substring(1, valorAtual.length);
    }
    $("#txtDisplay").val(valorAtual);
}

function GuardarValorAtual(operador) {
    var valorAtual = $("#txtDisplay").val();
    primeiroValor = valorAtual;

    if (operador != operadorGlobal) {
        var areaTestes = $("#txtAreaDeTestes").val();
        areaTestes = areaTestes + operador + "\t" + valorAtual + "\n";
        $("#txtAreaDeTestes").val(areaTestes);
    }

    limpar = true;
    operadorGlobal = operador;
}

function ApresentarResultado() {
    var valorAtual = $("#txtDisplay").val();
    var resultado = 0;

    var fltPrimeiroValor = parseFloat(primeiroValor);
    var fltSegundoValor = parseFloat(valorAtual);

    switch (operadorGlobal) {
        case "+":
            resultado = fltPrimeiroValor + fltSegundoValor;
            break;

        case "-":
            resultado = fltPrimeiroValor - fltSegundoValor;
            break;

        case "*":
            resultado = fltPrimeiroValor * fltSegundoValor;
            break;

        case "/":
            //Caso fizesse no c#, cuidado com a divisão por zero.
            resultado = fltPrimeiroValor / fltSegundoValor;
            if (resultado == "Infinity") {
                $("#txtDisplay").css("color", "red");
            }

            break;
    }

    $("#txtDisplay").val(resultado);
}


function AplicarRegraPercentagem() {
    //Cuidado... tem um bug aqui em comparação com a calc do Windows (ficou por resolver)
    var valorDisplay = $("#txtDisplay").val();
    var resultado = valorDisplay / 100;

    if (operadorGlobal == "") {
        resultado = 0;
    }

    $("#txtDisplay").val(resultado);
}


function InserirPonto(parametro) {
    var display = $("#txtDisplay").val();
    if (display.indexOf(parametro) < 0) {
        AtualizarDisplay(parametro);
    }
}


$(document).ready(function () {
    $("#btnC").click(function () {
        LimparDisplayCalculadora();
    });
});

$(document).ready(function () {
    $("#btnBksp").click(function () {
        ApagarUltimoElementoDigitado();
    });
});

$(document).ready(function () {
    $(".btnNumerico").click(function () {
        var valor = $(this).val();
        AtualizarDisplay(valor);
    });
});


$(document).ready(function () {
    $("#btnPlusMinus").click(function () {
        AlterarSinal();
    });
});


$(document).ready(function () {
    $(".btnOPeracao").click(function () {
        var operador = $(this).val();
        GuardarValorAtual(operador);
    });
});



$(document).ready(function () {
    $("#btnResult").click(function () {
        ApresentarResultado();
    });
});


$(document).ready(function () {
    $(".btnMemoria").click(function () {
        alert('NotImplementedException');
    });
});


$(document).ready(function () {
    $("#btnDot").click(function () {
        var parametro = $(this).val();
        InserirPonto(parametro);
    });
});



$(document).ready(function () {
    $("#btnPercentage").click(function () {
        AplicarRegraPercentagem();
    });
});


