var userLogado = null;

function AtivarMenuNavegacao(param) {
    $(param).addClass("active");
}


//Exemplo, não usar em aplicações porque é inseguro e pode ser facilmente burlado
//if (userLogado == null && location.pathname != "/index.html") {
//    location.href = "/index.html";
//}