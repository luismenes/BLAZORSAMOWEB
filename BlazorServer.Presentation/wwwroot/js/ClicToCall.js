function ClicToken(token, nombre) {

    let options = { debug: true }
    let latEl = document.querySelector('.duration'),
        infobipRTC = createInfobipRtc(token, options);
    infobipRTC.on('connected', function (e) {

        result = infobipRTC.callPhone("573007352844"); //Contact number --> Numero de contacto
        result.on('established', function (event1) {
            console.log(nombre + ' answered call!');
            document.getElementById('marcar').textContent = "Conectado";
            document.getElementById('imgMarcando').setAttribute('hidden', '');
            document.getElementById('remoteAudio').srcObject = event1.stream;
        });
        result.on('ringing', function (e1) {
            document.getElementById("marcar").textContent = "Marcando";
        });
        result.on('hangup', function (e2) {
            console.log(e2);
            document.getElementById('idLlamar').removeAttribute('hidden');
            document.getElementById('idColgar').setAttribute('hidden', 'hidden');
            document.getElementById('idLlamar').removeAttribute('disabled');
            if (e2.status.name == "NO_ERROR" || e2.status.name == "EC_DECLINE" || e2.status.name == "EC_CALL_TERMINATED") {//Call completed without error --> llamada finalizada sin ningun error
                document.getElementById("marcar").textContent = "LLamada finalizada";
                document.getElementById('imgMarcando').setAttribute('hidden', '');
                document.getElementById('idColgar').click();
            }
            else { //Call ended for any trouble --> Llamada finalizada debido a un error
                document.getElementById('imgMarcando').setAttribute('hidden', '');
                document.getElementById("marcar").textContent = "¡No se ha podido establecer conexión, vuelva intentarlo en un momento!";
            }
        });
        document.getElementById('imgMarcando').removeAttribute('hidden');
        document.getElementById('idColgar').removeAttribute('hidden');
        document.getElementById('idLlamar').setAttribute('hidden', '');
        document.getElementById("marcar").textContent = "Conectando...";

    });
    infobipRTC.connect();
    document.getElementById("idColgar").addEventListener('click', function () {
        result.hangup();
        let durationCall = result.duration();
        if (durationCall < 60) {
            latEl.value = durationCall + " segundos";
            let eventlat = new Event('change');
            latEl.dispatchEvent(eventlat);
        } else {
            durationMin = durationCall / 60;
            latEl.value = durationMin.toFixed(2) + " minutos";
            let eventlat = new Event('change');
            latEl.dispatchEvent(eventlat);
        }

    });
}
