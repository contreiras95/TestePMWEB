var JSController = {
    GetData: function (type, url, jsonData, callbackSucesso, async) {

        var asyncTemp = true;

        if (async !== null && async !== undefined) {
            asyncTemp = async;
        }

        $.ajax({
            type: type,
            async: asyncTemp,
            data: jsonData,
            url: window.location.protocol + "//" + window.location.host + "/" + url,
            success: function (resposta) {
             
                callbackSucesso(resposta);
               
            },
            error: function (resposta) {
                console.log("ERRO:" + JSON.stringify(resposta));
                
            }
        });
    }
}

function AlertField(id, mensagem) {
    $("#Campo" + id).addClass('error-input');
    $("#Campo" + id + " > span").html(mensagem);
}

function RestaureField() {

    $("#Formulario Div").each(function (index, item) {
        $(this).removeClass('error-input');
        $(this).children("span").html("");
    });

    
}

function abreviacao(s) {
    return /^([A-Z]\.)+$/.test(s);
}

function numeralRomano(s) {
    return /^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$/.test(s);
}

function capitalize(texto) {
    let prepos = ["da", "do", "das", "dos", "a", "e", "de"];
    return texto.split(' ') // quebra o texto em palavras
        .map((palavra) => { // para cada palavra
            if (abreviacao(palavra) || numeralRomano(palavra)) {
                return palavra;
            }

            palavra = palavra.toLowerCase();
            if (prepos.includes(palavra)) {
                return palavra;
            }
            return palavra.charAt(0).toUpperCase() + palavra.slice(1);
        })
        .join(' '); // junta as palavras novamente
}