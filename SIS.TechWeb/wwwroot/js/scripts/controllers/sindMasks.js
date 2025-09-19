
/*****************************/
/*     SOMENTE NUMEROS       */
/*****************************/


//Máscara que aceite apenas números
//const input = document.getElementById("campo");
//input.addEventListener("keypress", somenteNumeros);

function somenteNumeros(e) {
    var charCode = e.charCode ? e.charCode : e.keyCode;
    // charCode 8 = backspace
    // charCode 9 = tab
    if (charCode != 8 && charCode != 9) {
        // charCode 48 equivale a 0
        // charCode 57 equivale a 9
        if (charCode < 48 || charCode > 57) {
            return false;
        }
    }
}


/*****************************/
/*         CPF CNPJ          */
/*****************************/

function retirarFormatacao(campoTexto) {
    campoTexto.value = campoTexto.value.replace(/(\.|\/|\-)/g, "");
}


function formatarCampo(campoTexto) {
    if (campoTexto.value.length <= 11) {
        campoTexto.value = mascaraCpf(campoTexto.value);
    } else {
        campoTexto.value = mascaraCnpj(campoTexto.value);
    }
}


function mascaraCpf(valor) {
    return valor.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "\$1.\$2.\$3\-\$4");
}


function mascaraCnpj(valor) {
    return valor.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/g, "\$1.\$2.\$3\/\$4\-\$5");
}





/*****************************/
/*         TELEFONE          */
/*****************************/

function mascaraTelefone(event) {
    let tecla = event.key;
    let telefone = event.target.value.replace(/\D+/g, "");

    if (/^[0-9]$/i.test(tecla)) {
        telefone = telefone + tecla;
        let tamanho = telefone.length;

        if (tamanho >= 12) {
            return false;
        }

        if (tamanho > 10) {
            telefone = telefone.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
        } else if (tamanho > 5) {
            telefone = telefone.replace(/^(\d\d)(\d{4})(\d{0,4}).*/, "($1) $2-$3");
        } else if (tamanho > 2) {
            telefone = telefone.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
        } else {
            telefone = telefone.replace(/^(\d*)/, "($1");
        }

        event.target.value = telefone;
    }

    if (!["Backspace", "Delete"].includes(tecla)) {
        return false;
    }
}




/*****************************/
/*           CEP             */
/*****************************/


function mascara(o, f) {
    v_obj = o
    v_fun = f
    setTimeout("execmascara()", 1)
}


function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}


function leech(v) {
    v = v.replace(/o/gi, "0")
    v = v.replace(/i/gi, "1")
    v = v.replace(/z/gi, "2")
    v = v.replace(/e/gi, "3")
    v = v.replace(/a/gi, "4")
    v = v.replace(/s/gi, "5")
    v = v.replace(/t/gi, "7")
    return v
}


function soNumeros(v) {
    return v.replace(/\D/g, "")
}


function telefone(v) {
    v = v.replace(/\D/g, "")                 //Remove tudo o que não é dígito
    v = v.replace(/^(\d\d)(\d)/g, "($1) $2") //Coloca parênteses em volta dos dois primeiros dígitos
    v = v.replace(/(\d{4})(\d)/, "$1-$2")    //Coloca hífen entre o quarto e o quinto dígitos
    return v
}


function cpf(v) {
    v = v.replace(/\D/g, "")                    //Remove tudo o que não é dígito
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    //de novo (para o segundo bloco de números)
    v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2") //Coloca um hífen entre o terceiro e o quarto dígitos
    return v
}


function cep(v) {
    v = v.replace(/D/g, "")                //Remove tudo o que não é dígito
    v = v.replace(/^(\d{5})(\d)/, "$1-$2") //Esse é tão fácil que não merece explicações
    return v
}

function soNumeros(v) {
    return v.replace(/\D/g, "")
}

function telefone(v) {
    v = v.replace(/\D/g, "")                 //Remove tudo o que não é dígito
    v = v.replace(/^(\d\d)(\d)/g, "($1) $2") //Coloca parênteses em volta dos dois primeiros dígitos
    v = v.replace(/(\d{4})(\d)/, "$1-$2")    //Coloca hífen entre o quarto e o quinto dígitos
    return v
}

function cpf(v) {
    v = v.replace(/\D/g, "")                    //Remove tudo o que não é dígito
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    //de novo (para o segundo bloco de números)
    v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2") //Coloca um hífen entre o terceiro e o quarto dígitos
    return v
}

function mdata(v) {
    v = v.replace(/\D/g, "");
    v = v.replace(/(\d{2})(\d)/, "$1/$2");
    v = v.replace(/(\d{2})(\d)/, "$1/$2");

    v = v.replace(/(\d{2})(\d{2})$/, "$1$2");
    return v;
}

function mcc(v) {
    v = v.replace(/\D/g, "");
    v = v.replace(/^(\d{4})(\d)/g, "$1 $2");
    v = v.replace(/^(\d{4})\s(\d{4})(\d)/g, "$1 $2 $3");
    v = v.replace(/^(\d{4})\s(\d{4})\s(\d{4})(\d)/g, "$1 $2 $3 $4");
    return v;
}



/*****************************/
/*           MOEDA             */
/*****************************/



//Máscara para valores de moeda

//const input = document.getElementById("campo");
//input.addEventListener("keyup", formatarMoeda);
function formatarMoeda(e) {

    var v = e.target.value.replace(/\D/g, "");
    v = (v / 100).toFixed(2) + "";
    v = v.replace(".", ",");
    v = v.replace(/(\d)(\d{3})(\d{3}),/g, "$1.$2.$3,");

    v = v.replace(/(\d)(\d{3}),/g, "$1.$2,");

    e.target.value = v;

}


function moeda1(z) {
    v = z.value;
    v = v.replace(/\D/g, "") //permite digitar apenas números
    v = v.replace(/[0-9]{15}/, "inválido") //limita pra máximo 999.999.999,99
    v = v.replace(/(\d{1})(\d{13})$/, "$1.$2") //coloca ponto antes dos últimos 13 digitos
    v = v.replace(/(\d{1})(\d{10})$/, "$1.$2") //coloca ponto antes dos últimos 10 digitos
    v = v.replace(/(\d{1})(\d{7})$/, "$1.$2") //coloca ponto antes dos últimos 7 digitos
    v = v.replace(/(\d{1})(\d{1,4})$/, "$1,$2") //coloca virgula antes dos últimos 4 digitos
    z.value = v;
}




    


//Telefone: <input type="text" name="telefone" id="telefone" /><br />
//Celular: <input type="text" name="celular" id="celular" /><br />
//Telefone / Celular: <input type="text" name="telcel" id="telcel" /><br />
//CEP: <input type="text" name="cep" id="cep" /><br />
//CPF / CNPJ: <input type="text" name="cpfcnpj" id="cpfcnpj" /><br />
//Inscrição Estadual: <input type="text" name="estadual" id="estadual" />


//$(document).keydown(function () {
//    $("#telefone").mask("99 9999-9999");
//    $("#celular").mask("99 9 9999-9999");
//    $("#cep").mask("99.999-999");
//    $("#estadual").mask("999.999.999/9999");

//    var tamanhocpfcnpj = $("#cpfcnpj").val().length;
//    if (tamanhocpfcnpj < 14) {
//        $("#cpfcnpj").mask("999.999.999-99");
//    } else if (tamanhocpfcnpj >= 14) {
//        $("#cpfcnpj").mask("99.999.999/9999-99");
//    }

//    var tamanhotelcel = $("#telcel").val().length;
//    if (tamanhotelcel <= 12) {
//        $("#telcel").mask("99 9999-9999");
//    } else if (tamanhotelcel > 12) {
//        $("#telcel").mask("99 99999-9999");
//    }

//});
