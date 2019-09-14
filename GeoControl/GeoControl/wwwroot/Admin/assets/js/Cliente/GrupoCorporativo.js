
$(document).ready(function () {

    ListarGrupoCorporativo();
});
function ListarGrupoCorporativo() {
    var tablaGrupoCorp = $("#tbl_grcorp").DataTable({
        "ajax": {
            "url": "/Cliente/ListarGrupoCorporativo",
            "type": "GET",
            "datatype": "json"
        },
        "responsive": "true",
        "columns": [
            { "data": "descripcion" },
            { "data": "color" },
            {
                "data": "estado", "render": function (data) {
                    if (data = true)
                        return "<span class='badge badge-primary'>Activo</span>";
                    else
                        return "<span class='badge badge-danger'>Inactivo</span>";
                }
            },
            {
                "data": "id_grupocorp",
                "render": function (data) {
                    return "<button class='btn btn-danger btn-sm' style='margin-left:5px' OnClick='EliminaGrupo(" + data + ");'><i class='fa fa-pencil' ></i></button><button class='btn btn-success btn-sm' style='margin-left:5px' OnClick='EliminaGrupo(" + data + ");'><i class='fa fa-pencil'></i></button>";
                }
            }],
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });


}

