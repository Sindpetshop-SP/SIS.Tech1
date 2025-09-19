jQuery.extend(jQuery.validator.methods, {
    date: function (value, element) {
        return this.optional(element) || /^\d\d?\/\d\d?\/\d\d\d?\d?$/.test(value);
    },
    number: function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
    }
});

function moeda(a, e, r, t) {
    let n = "",
        h = j = 0,
        u = tamanho2 = 0,
        l = ajd2 = "",
        o = window.Event ? t.which : t.keyCode;
    if (13 == o || 8 == o)
        return !0;
    if (n = String.fromCharCode(o),
        -1 == "0123456789".indexOf(n))
        return !1;
    for (u = a.value.length,
        h = 0; h < u && ("0" == a.value.charAt(h) || a.value.charAt(h) == r); h++);
    for (l = ""; h < u; h++) - 1 != "0123456789".indexOf(a.value.charAt(h)) && (l += a.value.charAt(h));
    if (l += n, 0 == (u = l.length) && (a.value = ""), 1 == u && (a.value = "0" + r + "0" + l), 2 == u && (a.value = "0" + r + l), u > 2) {
        for (ajd2 = "",
            j = 0,
            h = u - 3; h >= 0; h--)
            3 == j && (ajd2 += e,
                j = 0),
                ajd2 += l.charAt(h),
                j++;
        for (a.value = "",
            tamanho2 = ajd2.length,
            h = tamanho2 - 1; h >= 0; h--)
            a.value += ajd2.charAt(h);
        a.value += r + l.substr(u - 2, u)
    }
    return !1
}




const mascaraMoeda = (event) => {
    const onlyDigits = event.target.value
        .split("")
        .filter(s => /\d/.test(s))
        .join("")
        .padStart(3, "0")
    const digitsFloat = onlyDigits.slice(0, -2) + "." + onlyDigits.slice(-2)
    event.target.value = maskCurrency(digitsFloat)
}



const maskCurrency = (valor, locale = 'pt-BR', currency = 'BRL') => {
    return new Intl.NumberFormat(locale, {
        style: 'currency',
        currency
    }).format(valor)
}

 

//Máscara para datas

//const input = document.getElementById("campo");
//input.addEventListener("keyup", formatarData);
function formatarData(e) {

    var v = e.target.value.replace(/\D/g, "");

    v = v.replace(/(\d{2})(\d)/, "$1/$2")

    v = v.replace(/(\d{2})(\d)/, "$1/$2")

    e.target.value = v;

}


//Máscara para CPF

//const input = document.getElementById("campo");
//input.addEventListener("keyup", formatarCPF);

function formatarCPF(e) {

    var v = e.target.value.replace(/\D/g, "");

    v = v.replace(/(\d{3})(\d)/, "$1.$2");

    v = v.replace(/(\d{3})(\d)/, "$1.$2");

    v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2");

    e.target.value = v;

} 


//Máscara para CNPJ

//const input = document.getElementById("campo");
//input.addEventListener("keyup", formatarCNPJ);

function formatarCNPJ(e) {

    var v = e.target.value.replace(/\D/g, "");

    v = v.replace(/^(\d{2})(\d)/, "$1.$2");

    v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");

    v = v.replace(/\.(\d{3})(\d)/, ".$1/$2");

    v = v.replace(/(\d{4})(\d)/, "$1-$2");

    e.target.value = v;
}


//Máscara para CEP

//const input = document.getElementById("campo");
//input.addEventListener("keyup", formatarCep);

function formatarCep(e) {

    var v = e.target.value.replace(/\D/g, "")

    v = v.replace(/^(\d{5})(\d)/, "$1-$2")

    e.target.value = v;

}


//Máscara para Telefone

//const input = document.getElementById("campo");
//input.addEventListener("keyup", formatarTelefone);

function formatarTelefone(e) {

    var v = e.target.value.replace(/\D/g, "");

    v = v.replace(/^(\d\d)(\d)/g, "($1)$2");

    v = v.replace(/(\d{5})(\d)/, "$1-$2");

    e.target.value = v;
}


//const input = document.getElementById("campo");
//input.addEventListener("keyup", formatarTelefone);
//input.addEventListener("blur", validarTelefone);
function formatarTelefone(e) {

    var v = e.target.value.replace(/\D/g, "");

    v = v.replace(/^(\d\d)(\d)/g, "($1)$2");

    v = v.replace(/(\d{5})(\d)/, "$1-$2");

    e.target.value = v;

}


function validarTelefone(e) {

    var texto = e.target.value;

    var RegExp = /^\(\d{2}\)\d{5}-\d{4}/;

    if (texto.match(RegExp) != null) {

        alert("telefone válido");

    } else {

        alert("telefone inválido");

        e.target.value = "";

    }
}






function numberToReal(numero) {
    var numero = numero.toFixed(2).split('.');
    numero[0] = "R$ " + numero[0].split(/(?=(?:...)*$)/).join('.');
    return numero.join(',');
}
