
/**
 *  Pages Authentication
 */
'use strict';

document.addEventListener('DOMContentLoaded', function () {
  (() => {
    const formAuthentication = document.querySelector('#formChangePassword');

    // Form validation for Add new record
    if (formAuthentication && typeof FormValidation !== 'undefined') {
      FormValidation.formValidation(formAuthentication, {
        fields: {
          Usuario: {
            validators: {
              notEmpty: {
                message: 'Por favor insira o nome de usuário'
              },
              stringLength: {
                min: 6,
                message: 'O nome de usuário deve ter 6 caracteres',
                max: 6,
                message: 'O nome de usuário deve ter 6 caracteres',
              }
            }
          },
          NomeUsuario: {
            validators: {
              notEmpty: {
                message: 'Por favor insira o nome de usuário'
              },
              stringLength: {
                min: 10,
                message: 'O nome de usuário deve ter mais de 10 caracteres',
                max: 50,
                message: 'O nome de usuário deve ter até 50 caracteres',
              }
            }
          },
          CodDepartamento: {
            validators: {
              notEmpty: {
                message: 'Por favor selecione um Departamento'
              }
            }
          },
          Cpf: {
            validators: {
              notEmpty: {
                message: 'Por favor insira o seu Cpf'
              }
            }
          },
          Senha: {
            validators: {
              notEmpty: {
                message: 'Por favor digite sua senha'
              },
              stringLength: {
                min: 1,
                message: 'A senha deve ter mais de 1 caracter'
              }
            }
          },
          Email: {
            validators: {
              notEmpty: {
                message: 'Por favor insira seu e-mail'
              },
              emailAddress: {
                message: 'Por favor, insira um endereço de e-mail válido'
              }
            }
          },
          'email-username': {
            validators: {
              notEmpty: {
                message: 'Por favor, insira e-mail / nome de usuário'
              },
              stringLength: {
                min: 6,
                message: 'O nome de usuário deve ter 6 caracteres',
                max: 6,
                message: 'O nome de usuário deve ter 6 caracteres',
              }
            }
          },
          VlrSenhaUsuario: {
            validators: {
              notEmpty: {
                message: 'Por favor digite sua senha'
              },
              stringLength: {
                min: 6,
                message: 'A senha deve ter mais de 6 caracteres'
              }
            }
          },
          'ConfirmSenha': {
            validators: {
              notEmpty: {
                message: 'Por favor confirme a senha'
              },
              identical: {
                compare: () => formAuthentication.querySelector('[name="VlrSenhaUsuario"]').value,
                message: 'A senha e sua confirmação não correspondem'
              },
              stringLength: {
                min: 6,
                message: 'A senha deve ter mais de 6 caracteres'
              }
            }
          },
          password: {
            validators: {
              notEmpty: {
                message: 'Por favor digite sua senha'
              },
              stringLength: {
                min: 6,
                message: 'A senha deve ter mais de 6 caracteres'
              }
            }
          },
          'confirm-password': {
            validators: {
              notEmpty: {
                message: 'Por favor confirme a senha'
              },
              identical: {
                compare: () => formAuthentication.querySelector('[name="password"]').value,
                message: 'A senha e sua confirmação não correspondem'
              },
              stringLength: {
                min: 6,
                message: 'A senha deve ter mais de 6 caracteres'
              }
            }
          },
          terms: {
            validators: {
              notEmpty: {
                message: 'Por favor, concorde com os termos e condições'
              }
            }
          }
        },
        plugins: {
          trigger: new FormValidation.plugins.Trigger(),
          bootstrap5: new FormValidation.plugins.Bootstrap5({
            eleValidClass: '',
            rowSelector: '.form-control-validation'
          }),
          submitButton: new FormValidation.plugins.SubmitButton(),
          defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
          autoFocus: new FormValidation.plugins.AutoFocus()
        },
        init: instance => {
          instance.on('plugins.message.placed', e => {
            if (e.element.parentElement.classList.contains('input-group')) {
              e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
            }
          });
        }
      });
    }

    // Two Steps Verification for numeral input mask
    const numeralMaskElements = document.querySelectorAll('.numeral-mask');

    // Format function for numeral mask
    const formatNumeral = value => value.replace(/\D/g, ''); // Only keep digits

    if (numeralMaskElements.length > 0) {
      numeralMaskElements.forEach(numeralMaskEl => {
        numeralMaskEl.addEventListener('input', event => {
          numeralMaskEl.value = formatNumeral(event.target.value);
        });
      });
    }
  })();
});
