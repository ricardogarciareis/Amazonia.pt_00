$(document).ready(function () {
    $("#meubotao").click(function () {
        console.log('inicio');
        $("h1").css({ visibility: "visible" });
        console.log('fim');
    });
});


function OiMundo() {
    alert('Oi mundo a partir da funcao usndo jquery');
}

$(function () {
    $("#meubotaoExemplo").click(function () {
        OiMundo();
    });
});



function OperacoesString(tipoOperacao, parametro) {
    var resultado = "";

    if (tipoOperacao == "substring") {
        resultado = parametro.substring(1, 3);
    }

    alert(resultado);
    return resultado;
}
