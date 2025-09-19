/**
 * Page User List
 */

'use strict';

// Datatable (js)
document.addEventListener('DOMContentLoaded', function (e) {

  let borderColor, bodyBg, headingColor;

  borderColor = config.colors.borderColor;
  bodyBg = config.colors.bodyBg;
  headingColor = config.colors.headingColor;

  // Variable declaration for table
  const dt_user_table = document.querySelector('.datatables-generic');

  // Users datatable
  if (dt_user_table) {

    const dt_user = new DataTable(dt_user_table,
      {
        select: {
          style: 'multi',
          selector: 'td:nth-child(2)'
        },

        order: [[1, 'asc']],


        layout:
        {
          topStart:
          {
            rowClass: 'row m-3 my-0 justify-content-between',
            features: [
              {
                pageLength: {
                  menu: [10, 25, 50, 100],
                  text: '_MENU_'
                }
              }
            ]
          },

          topEnd:
          {
            features: [
              {
                search: {
                  placeholder: 'Pesquisar',
                  text: '_INPUT_'
                }
              }
            ]
          },

          bottomStart: {
            rowClass: 'row mx-3 justify-content-between',
            features: ['info']
          },
          bottomEnd: 'paging'
        },


        language: {
          sLengthMenu: '_MENU_',
          search: '',
          searchPlaceholder: 'Pesquisar',
          paginate: {
            next: '<i class="icon-base ti tabler-chevron-right scaleX-n1-rtl icon-18px"></i>',
            previous: '<i class="icon-base ti tabler-chevron-left scaleX-n1-rtl icon-18px"></i>',
            first: '<i class="icon-base ti tabler-chevrons-left scaleX-n1-rtl icon-18px"></i>',
            last: '<i class="icon-base ti tabler-chevrons-right scaleX-n1-rtl icon-18px"></i>'
          },
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
        },


        // For responsive popup
        responsive: {
          details: {
            display: DataTable.Responsive.display.modal({
              header: function (row) {
                const data = row.data();
                return 'Details of ' + data['full_name'];
              }
            }),
            type: 'column',
            renderer: function (api, rowIdx, columns) {
              const data = columns
                .map(function (col) {
                  return col.title !== '' // Do not show row in modal popup if title is blank (for check box)
                    ? `<tr data-dt-row="${col.rowIndex}" data-dt-column="${col.columnIndex}">
                      <td>${col.title}:</td>
                      <td>${col.data}</td>
                    </tr>`
                    : '';
                })
                .join('');

              if (data) {
                const div = document.createElement('div');
                div.classList.add('table-responsive');
                const table = document.createElement('table');
                div.appendChild(table);
                table.classList.add('table');
                const tbody = document.createElement('tbody');
                tbody.innerHTML = data;
                table.appendChild(tbody);
                return div;
              }
              return false;
            }
          }
        }
      });

  }

  // Filter form control to default size
  // ? setTimeout used for user-list table initialization
  setTimeout(() => {
    const elementsToModify = [
      { selector: '.dt-buttons .btn', classToRemove: 'btn-secondary' },
      { selector: '.dt-search .form-control', classToRemove: 'form-control-sm' },
      { selector: '.dt-length .form-select', classToRemove: 'form-select-sm', classToAdd: 'ms-0' },
      { selector: '.dt-length', classToAdd: 'mb-md-6 mb-0' },
      {
        selector: '.dt-layout-end',
        classToRemove: 'justify-content-between',
        classToAdd: 'd-flex gap-md-4 justify-content-md-between justify-content-center gap-2 flex-wrap'
      },
      { selector: '.dt-buttons', classToAdd: 'd-flex gap-4 mb-md-0 mb-4' },
      { selector: '.dt-layout-table', classToRemove: 'row mt-2' },
      { selector: '.dt-layout-full', classToRemove: 'col-md col-12', classToAdd: 'table-responsive' }
    ];

    // Delete record
    elementsToModify.forEach(({ selector, classToRemove, classToAdd }) => {
      document.querySelectorAll(selector).forEach(element => {
        if (classToRemove) {
          classToRemove.split(' ').forEach(className => element.classList.remove(className));
        }
        if (classToAdd) {
          classToAdd.split(' ').forEach(className => element.classList.add(className));
        }
      });
    });
  }, 100);




});



function loadModalConvencao(id) {

    $.ajax({
        type: 'GET',
        url: '/Convencao/InsertEdit',
        cache: false,
        data: {
            convencaoId: id,
        },
        dataType: 'html',
        success: function (data) {

            $('#convencaoInsertEditModal').html(data);
            $('#convencaoInsertEditModal > .modal').modal('show');
            $('#convencaoInsertEditModal').modal("show");

        }
    });

}

function closeModalConvencao() {

    $('#convencaoInsertEditModal > .modal').modal('hide');
    $('#convencaoInsertEditModal').modal("hide");

}


function loadModalDeleteConvencao(id) {

    $.ajax({
        type: 'GET',
        url: '/Convencao/Delete',
        cache: false,
        data: {
            convencaoId: id
        },
        dataType: 'html',
        success: function (data) {
            $('#convencaoDeleteModal').html(data);
            $('#convencaoDeleteModal > .modal').modal('show');
            $('#convencaoDeleteModal').modal("show");
        }
    });

}

function closeModalDeleteConvencao() {

    $('#convencaoDeleteModal > .modal').modal('hide');
    $('#convencaoDeleteModal').modal("hide");

}


