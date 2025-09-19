
/*****************************/
/*         ONLOAD        */
/*****************************/


var codClienteAux = document.getElementById("hdnCodCliente").value;

if (codClienteAux == 0) {
    $("#btnNovoContato").attr("style", "display: none; ");
    $("#btnNovoEndereco").attr("style", "display: none; ");

}
else {
    $("#btnNovoContato").attr("style", "display: initial; ");
    $("#btnNovoEndereco").attr("style", "display: initial; ");
}

/*****************************/
/*         DATATABLES        */
/*****************************/

$('#dataTables-contatos').DataTable({
    //dom: '<"html5buttons"B>lTfgitp',
    responsive: true,
    rowReorder: {
        selector: 'td:nth-child(2)'
    },       
    buttons: [
        //{ extend: 'copy' },
        //{ extend: 'csv' },
        //{ extend: 'excel', title: 'ExampleFile' },
        { extend: 'pdf', title: 'ExampleFile' },

        {
            extend: 'print',
            customize: function (win) {
                $(win.document.body).addClass('white-bg');
                $(win.document.body).css('font-size', '10px');

                $(win.document.body).find('table')
                    .addClass('compact')
                    .css('font-size', 'inherit');
            }
        }
    ],

    "pageLength": 5,
    "lengthMenu": [[5, 10, 20, 50, -1], [5, 10, 20, 50, "Todos"]],

    "language": {
        "paginate": {
            "previous": "Anterior",
            "next": "Próximo"
        },

        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ resultados por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
    }

});


$('#dataTables-enderecos').DataTable({
    //dom: '<"html5buttons"B>lTfgitp',
    responsive: true,
    rowReorder: {
        selector: 'td:nth-child(2)'
    },       
    buttons: [
        //{ extend: 'copy' },
        //{ extend: 'csv' },
        //{ extend: 'excel', title: 'ExampleFile' },
        { extend: 'pdf', title: 'ExampleFile' },

        {
            extend: 'print',
            customize: function (win) {
                $(win.document.body).addClass('white-bg');
                $(win.document.body).css('font-size', '10px');

                $(win.document.body).find('table')
                    .addClass('compact')
                    .css('font-size', 'inherit');
            }
        }
    ],

    "pageLength": 5,
    "lengthMenu": [[5, 10, 20, 50, -1], [5, 10, 20, 50, "Todos"]],

    "language": {
        "paginate": {
            "previous": "Anterior",
            "next": "Próximo"
        },

        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ resultados por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
    }

});



/*****************************/
/*         POPUPS            */
/*****************************/



$(".insertContato").click(function () {

    var id = $(this).attr("data-id");
    var codContato = $(this).attr("data-dado");

    $("#myModal").load("InserirEditarContato?codClienteId=" + id + "&" + "codContatoId=" + codContato, function () {
        $("#myModal").modal("show");
    })
});


$(".editContato").click(function () {

    var id = $(this).attr("data-id");
    var codContato = $(this).attr("data-dado");

    $("#myModal").load("InserirEditarContato?codClienteId=" + id + "&" + "codContatoId=" + codContato, function () {
        $("#myModal").modal("show");
    })
});



function deleteContato(id) {

    $.ajax({
        type: 'GET',
        url: '/Cliente/ExcluirContato',
        cache: false,
        data: {
            codContatoId: id,
        },
        dataType: 'html',
        success: function (data) {
            ;
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}




$(".insertEndereco").click(function () {

    var id = $(this).attr("data-id");
    var codEndereco = $(this).attr("data-dado");

    $("#myModal").load("InserirEditarEndereco?codClienteId=" + id + "&" + "codEnderecoId=" + codEndereco, function () {
        $("#myModal").modal("show");
    })
});



$(".editEndereco").click(function () {

    var id = $(this).attr("data-id");
    var codEndereco = $(this).attr("data-dado");

    $("#myModal").load("InserirEditarEndereco?codClienteId=" + id + "&" + "codEnderecoId=" + codEndereco, function () {
        $("#myModal").modal("show");
    })
});



function deleteEndereco(id) {

    $.ajax({
        type: 'GET',
        url: '/Cliente/ExcluirEndereco',
        cache: false,
        data: {
            codEnderecoId: id,
        },
        dataType: 'html',
        success: function (data) {
            ;
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}




/*****************************/
/*         CONTROLES         */
/*****************************/


$('#dtaCadCliente').removeAttr("data-val-date");

$(document).ready(function () {

    $('#dtaCadCliente').datepicker({
        //defaultDate: "getDate()",
        format: 'dd/mm/yyyy',
        language: 'pt-BR',
        clearBtn: true
    }).datepicker("setDate", new Date());

});


var elem = document.querySelector('.js-switch');
var switchery = new Switchery(elem, { color: '#1AB394' });

var clienteId = document.getElementById("hdnCodCliente").value;

if (clienteId == 0) {

    document.getElementById("txtCpfCnpj").readOnly = false;

    $("#btnInserirContato").attr("style", "display: none; ");
    $("#btnInserirEndereco").attr("style", "display: none; ");
}
else {
    document.getElementById("txtCpfCnpj").readOnly = true;
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

