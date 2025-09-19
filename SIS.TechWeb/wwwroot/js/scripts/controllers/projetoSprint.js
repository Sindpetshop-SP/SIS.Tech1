
$('#DtInicioPrevistoSprint').removeAttr("data-val-date");
$('#DtTerminoPrevistoSprint').removeAttr("data-val-date");
$('#DtInicioRealizadoSprint').removeAttr("data-val-date");
$('#DtTerminoRealizadoSprint').removeAttr("data-val-date");


$('#DtInicioPrevistoSprint').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
}).datepicker("setDate", new Date());

$('#DtTerminoPrevistoSprint').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
}).datepicker("setDate", new Date());


$('#DtInicioRealizadoSprint').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
});

$('#DtTerminoRealizadoSprint').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
});

