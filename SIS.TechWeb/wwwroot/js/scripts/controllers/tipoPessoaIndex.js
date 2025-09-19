

$('#dataTables-TipoPessoa').DataTable({
    /*dom: '<"html5buttons"B>lTfgitp',*/
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



function loadModal(id) {

    $.ajax({
        type: 'GET',
        url: '/TipoPessoa/Delete',
        cache: false,
        data: {
            codTipoPessoa: id,
        },
        dataType: 'html',
        success: function (data) {
            ;
            $("#myModal").html(data);
            $("#myModal").modal("show");
        }
    });

}