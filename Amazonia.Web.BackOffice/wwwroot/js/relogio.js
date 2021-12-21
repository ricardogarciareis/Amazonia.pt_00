function AtualizarDisplay() {
    var agora = new Date();
    var hora = agora.getHours();
    var minuto = agora.getMinutes();
    var segundo = agora.getSeconds();

    txtRelogio.value = hora + ":" + minuto + ":" + segundo;


    if (segundo % 10 == 0) {
        console.error("Sou uma mensagem de erro exibida a cada 10 segundos");

        if (segundo % 3 == 0) {
            console.warn("Sou uma mensagem de alerta grave exibida a cada 30 segundos");
        }
    } else {
        console.info("Sou o log normal que acontece a fora dos segundos múltiplus de 10");
    }

    console.log("console normal a cada segundo");
    if (segundo % 5 == 0) {
        console.debug("Sou uma mensagem de debug" + agora);
    }
    

    return true;
}


setInterval('AtualizarDisplay()', 1000);



function AlertaPersonalizado() {
    alert('Oi mundo, eu funciono');
}
