
 
/*****************************/
/*         CONTROLES         */
/*****************************/

var elem = document.querySelector('.js-switch');
var switchery = new Switchery(elem, { color: '#1AB394' });

var codTpPessoa = document.getElementById("ddlTipoPessoa").value;

var PessoaId = document.getElementById("hdnCodPessoa").value;

if (PessoaId > 0) {
    
    document.getElementById("ddlTipoPessoa").disabled = true;
    document.getElementById("txtCpfCnpj").readOnly = true;
    
}
else {
    document.getElementById("ddlTipoPessoa").disabled = false;
    document.getElementById("txtCpfCnpj").readOnly = false;

    
}



/*****************************/
/*      METODOS CHANGE       */
/*****************************/


$('#ddlTipoPessoa').change(function () {

    document.getElementById("txtCpfCnpj").value = "";

    var codTipoPessoa = $(this).val();

    if (codTipoPessoa == 1) {

        $('input#txtCpfCnpj').attr('maxLength', '11').keypress(limitMe);
    }
    else {
        $('input#txtCpfCnpj').attr('maxLength', '14').keypress(limitMe);
    }

    function limitMe(e) {
        if (e.keyCode == 8) { return true; }
        return this.value.length < $(this).attr("maxLength");
    }

});
