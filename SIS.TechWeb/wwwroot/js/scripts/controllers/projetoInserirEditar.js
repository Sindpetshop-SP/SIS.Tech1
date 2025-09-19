/********************/
/*    CONTROLES     */
/********************/

$('[data-toggle="tooltip"]').tooltip();



/********************/
/*    DATATABLES    */
/********************/

$('#dataTables-ProjetoSprint').DataTable({
    //dom: '<"html5buttons"B>lTfgitp',
    order: [[1, 'asc']],
    //columnDefs: [
    //    {
    //        "targets": [0],
    //        "visible": false,
    //        "searchable": false
    //    }
    //],   
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
 

$('#dataTables-ProjetoEquipe').DataTable({
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
/*         ONLOAD        */
/*****************************/

var codProjetoAux = document.getElementById("hdnCodProjeto").value;

if (codProjetoAux == 0) {

    $("#btnNovoMembro").attr("style", "display: none; ");
    $("#btnNovaTarefa").attr("style", "display: none; ");
    $("#btnNovoDocumento").attr("style", "display: none; ");

}
else {

    $("#btnNovoMembro").attr("style", "display: initial; ");
    $("#btnNovaTarefa").attr("style", "display: initial; ");
    $("#btnNovoDocumento").attr("style", "display: initial; ");

}




/*****************************/
/*         CONTROLES         */
/*****************************/

var elem = document.querySelector('.js-switch');
var switchery = new Switchery(elem, { color: '#1AB394' });


$('#DtCadastro').removeAttr("data-val-date");
$('#DtInicioPrevisto').removeAttr("data-val-date");
$('#DtTerminoPrevisto').removeAttr("data-val-date");
$('#DtInicioRealizado').removeAttr("data-val-date");
$('#DtTerminoRealizado').removeAttr("data-val-date");


$('#ValorPrevisto').removeAttr("data-val-number");
$('#ValorPrevisto').removeAttr("data-val");

$('#ValorRealizado').removeAttr("data-val-number");
$('#ValorRealizado').removeAttr("data-val");



$('#DtCadastro').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
}).datepicker("setDate", new Date());

$('#DtInicioPrevisto').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
});

$('#DtTerminoPrevisto').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
});

$('#DtInicioRealizado').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
});

$('#DtTerminoRealizado').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
});


$(".insertEquipe").click(function () {

    var id = $(this).attr("data-id");
    /*var codContato = $(this).attr("data-dado");*/

    $("#myModal").load("InserirEquipe?codProjetoId=" + id, function () { //+ "&" + "codContatoId=" + codContato
        $("#myModal").modal("show");
    })
});






$(".insertSprint").click(function () {

    var id = $(this).attr("data-id");
    /*var codContato = $(this).attr("data-dado");*/

    $("#myModal").load("InsertEditSprint?codProjetoId=" + id, function () {  
        $("#myModal").modal("show");
    })
});


function editarSprint(id, idSprint) {

    $.ajax({
        type: 'GET',
        url: '/Projeto/InsertEditSprint',
        cache: false,
        data: {
            codProjetoId: id,
            codProjetoSprintId: idSprint
        },
        dataType: 'html',
        success: function (data) {            
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}
 
function excluirSprint(id, idSprint) {

    $.ajax({
        type: 'GET',
        url: '/Projeto/ExcluirSprint',
        cache: false,
        data: {
            codProjetoSprint: id,
            codProj: idSprint
        },
        dataType: 'html',
        success: function (data) {           
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}



$(".insertTarefa").click(function () {

    var Id = $(this).attr("data-id");
    var IdSprint = $(this).attr("data-dado");


    $("#myModal").load("InsertEditTarefa?codProjetoId=" + Id + "&" + "codProjetoSprintId=" + IdSprint, function () {
        $("#myModal").modal("show");
    })

});



function editarTarefa(id, idSprint, idTarefa) {

    $.ajax({
        type: 'GET',
        url: '/Projeto/InsertEditTarefa',
        cache: false,
        data: {
            codProjetoId: id,
            codProjetoSprintId: idSprint,
            codProjetoTarefaId: idTarefa
        },
        dataType: 'html',
        success: function (data) {
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}

function excluirTarefa(id, idSprint, idTarefa) {

    $.ajax({
        type: 'GET',
        url: '/Projeto/ExcluirTarefa',
        cache: false,
        data: {
            codProjetoId: id,
            codProjetoSprintId: idSprint,
            codProjetoTarefaId: idTarefa
        },
        dataType: 'html',
        success: function (data) {
            //$("#myModal").html(data);
            //$("#myModal").modal("show");
        }
    });

}


/********************/
/*    ARQUIVOS      */
/********************/


function ObterArquivosTarefa(idProj, idProjSprint, idProjTarefa) {

    $.ajax({
        type: 'GET',
        url: '/Projeto/ObterArquivosTarefa',
        cache: false,
        data: {
            codProjetoId: idProj,
            codProjetoSprintId: idProjSprint,
            codProjetoTarefaId: idProjTarefa
        },
        dataType: 'html',
        success: function (data) {
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}

function InsertArquivoProjeto(idProj, idProjSprint, idProjTarefa) {

    $.ajax({
        type: 'GET',
        url: '/Projeto/InsertArquivoProjeto',
        cache: false,
        data: {
            codProjetoId: idProj,
            codProjetoSprintId: idProjSprint,
            codProjetoTarefaId: idProjTarefa
        },
        dataType: 'html',
        success: function (data) {
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}


function deleteArquivoProjeto(id, idProj) {

    $.ajax({
        type: 'GET',
        url: '/Projeto/DeleteProjetoArquivo',
        cache: false,
        data: {
            codProjetoArquivo: id,
            codProjetoId: idProj
        },
        dataType: 'html',
        success: function (data) {
            //;
            //$("#myModal").html(data);
            //$("#myModal").modal("show");

            //location.reload();
        }
    });

}
