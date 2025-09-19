/**
 * Enable OTP
 */

'use strict';

document.addEventListener('DOMContentLoaded', function (e) {
  (function () {

    // Enable OTP form validation
    FormValidation.formValidation(document.getElementById('formEditEmpresa'),
      {
        fields: {

          banana: {
            validators: {
              notEmpty: {
                message: 'Campo obrigatório'
              },
              regexp: {
                regexp: /^[a-zA-Zs]+$/,
                message: 'O nome só pode consistir em letras alfabéticas'
              },
              stringLength: {
                min: 5,
                max: 100,
                message: 'O nome deve ter mais de 5 e menos de 100 caracteres'
              }
            }
          },
          AnoVigenciaInicial: {
            validators: {
              notEmpty: {
                message: 'Campo obrigatório'
              },
              stringLength: {
                min: 4,
                max: 4,
                message: 'O ano deve ter 4 caracteres'
              }
            }
          },
          AnoVigenciaFinal: {
            validators: {
              notEmpty: {
                message: 'Campo obrigatório'
              },
              stringLength: {
                min: 4,
                max: 4,
                message: 'O ano deve ter 4 caracteres'
              }
            }
          }  
        },
        plugins: {

          trigger: new FormValidation.plugins.Trigger(),

          bootstrap5: new FormValidation.plugins.Bootstrap5({
            // Use this for enabling/changing valid/invalid class
            // eleInvalidClass: '',
            eleValidClass: '',
            rowSelector: '.form-control-validation'
          }),

          submitButton: new FormValidation.plugins.SubmitButton(),

          // Submit the form when all fields are valid
          defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
          autoFocus: new FormValidation.plugins.AutoFocus()

        },
        init: instance => {

          instance.on('plugins.message.placed', function (e) {
            //* Move the error message out of the `input-group` element
            if (e.element.parentElement.classList.contains('input-group')) {
              e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
            }
          });

        }
      });
  })();
});

// Select2 (jquery)
$(function () {
  const select2 = $('.select2');

  // Select2 Country
  if (select2.length) {
    select2.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>').select2({
        placeholder: 'Select value',
        dropdownParent: $this.parent()
      });
    });
  }
});

function loadModalEmpresa(id) {

  $.ajax({
    type: 'GET',
    url: '/Empresa/InsertEdit',
    cache: false,
    data: {
      convencaoId: id,
    },
    dataType: 'html',
    success: function (data) {

      $('#modalInsertEditEmpresa').html(data);
      $('#modalInsertEditEmpresa > .modal').modal('show');
      $('#modalInsertEditEmpresa').modal("show");
      
    }
  });

}
function closeModalConvencao() {

  $('#modalInsertEditEmpresa > .modal').modal('hide');
  $('#modalInsertEditEmpresa').modal("hide");

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

