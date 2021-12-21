function ValidarCampos() {
    var resultado = true;
    var texto = document.getElementById("textoValidacaoPrimeiroNome");

    if (txtPrimeiroNome.value == "") {
        resultado = false;
        texto.style.display = "block";
    } else {
        texto.style.display = "none";
    }

    return resultado;
}