/**
 * Enable OTP
 */

'use strict';

document.addEventListener('DOMContentLoaded', function (e) {
  (function () {
     
    // Enable OTP form validation
    FormValidation.formValidation(document.getElementById('formEditConvencao'), {
      fields: {
        modalEnableOTPPhone: {
          validators: {
            notEmpty: {
              message: 'Chupeta'
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
        // defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
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
      $("#convencaoInsertEditModal").modal("show");
    }
  });
}


