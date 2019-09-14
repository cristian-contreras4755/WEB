$(document).ready(function () {


    var Id_sucursal = 0;

    ListarSucursal();

    ListarClienteCb();
    $('#cb_cliente').select2({
        theme: "bootstrap4",
        placeholder: 'Seleciona tipo cliente.',

        allowClear: true,
        tags: true,
        maximumSelectionLength: 3,
        width: '100%'
    });




    $("#defaultUnchecked").click(function () {
        if ($(this).is(':checked')) {

        } else {
            //   $("#btn_mostrar_mapa").prop('disabled', true);
            $("#txt_lng").val("");
            $("#txt_lat").val("");
        }
    });


    $("#btn_GuardarMdfSucursal").click(function () {

        var ib_geolocalizacionLocal;
        var ib_es_principal;


        if ($("#chk_esprincipal").is(':checked')) {
            ib_es_principal = true;
        } else {
            ib_es_principal = false;
        }



        if ($("#defaultUnchecked").is(':checked')) {
            ib_geolocalizacionLocal = true;
        } else {
            ib_geolocalizacionLocal = false;
        }


        var data = {
            id_cliente: Id_sucursal,
            cod_cliente: $("#cb_cliente").select2('val'),
            nom_int: $("#txt_nom_int").val(),
            dir: $("#txt_dir").val(),
            tlf: $("#txt_tlf").val(),
            tlf2: $("#txt_tlf2").val(),
            correo: $("#txt_correo").val(),
            ib_geo: ib_geolocalizacionLocal,
            lng: $("#txt_lng").val(),
            lat: $("#txt_lat").val(),
            ib_esprin: ib_es_principal
        };



        if (data.cod_cliente.length == 0) {
            swal("Selecione  Cliente a quien pertenesca el sucursal");
            return;
        }


        if (data.nom_int.length == 0) {
            swal("Ingrese nombre sucursal");
            return;
        }

        if (data.dir.length < 8) {
            swal("Ingrese Direccion  sucursal");
            return;
        }


        if (data.tlf.length == 0) {
            swal("Ingrese telefono sucursal");
            return;
        }


        if (data.correo.length == 0) {
            swal("Ingrese correo sucursal");
            return;
        }


        if (data.ib_geolocalizacion == true) {

            if (data.lng.length == 0 || data.lat.length == 0) {
                swal("Selecciona  locacalizacion en mapa.");
                return;
            }
        }



        $.ajax({
            url: '/Cliente/Sucursal_Crea/',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {

                swal(data.data, {
                    icon: "success",
                    timer: 2000
                });

                //limpiar luego de registrar
                LimpiarFormulario();
                $('#FomModalSucursal').modal('hide')
                tablaSucursal.ajax.reload();

            },
            error: function (result) {
                swal(result, {
                    icon: "error",
                    timer: 2000
                });
            }
        });



    });


    var map = null;
    var myMarker;
    var myLatlng;

    function initializeGMap(lat, lng) {
        myLatlng = new google.maps.LatLng(lat, lng);

        var myOptions = {
            zoom: 12,
            zoomControl: true,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

        var marker = new google.maps.Marker({ position: map.getCenter(), map: map, draggable: true });

        google.maps.event.addListener(marker, 'dragend', function (event) {

            var Newlat = map.getCenter().lat();
            var Newlng = map.getCenter().lng();
            $("#txt_lng").val(Newlng);
            $("#txt_lat").val(Newlat);

        });


        geocoder = new google.maps.Geocoder();
        infowindow = new google.maps.InfoWindow();
        google.maps.event.addListener(map, 'click', function () {

            var html = "<table>" +
                "<tr><td>Name:</td> <td><input type='text' id='name'/> </td> </tr>" +
                "<tr><td>Time:</td> <td><input type='text' id='time'/> </td> </tr>" +
                "<tr><td>Bus Id:</td> <td><input type='text' id='busId'/> </td> </tr>" +
                "<tr><td>Device Id:</td> <td><input type='text' id='deviceId'/> </td> </tr>" +
                "<tr><td></td><td><input type='button' value='Save & Close' onclick='saveData()'/></td></tr>";

            var infowindow = new google.maps.InfoWindow({
                content: html
            });

            infowindow.open(map, marker);

        });


    }


    // Re-init map before show modal
    $('#FomModalSucursal').on('show.bs.modal', function (event) {
        //  var button = $(event.relatedTarget);

        if ($("#txt_lng").val() != null && $("#txt_lat").val() != null) {

            initializeGMap($("#txt_lat").val(), $("#txt_lng").val());
        } else {

            //POR DEFECTO
            initializeGMap('-12.0440916', '-76.9259649');
        }

        //initializeGMap(button.data('lat'), button.data('lng'));
        $("#location-map").css("width", "100%");
        $("#map_canvas").css("width", "100%");
    });

    // Trigger map resize event after modal shown

    /*
    $('#FomModalSucursal').on('shown.bs.modal', function () {
        google.maps.event.trigger(map, "resize");
        map.setCenter(myLatlng);
    });

*/


    function ListarClienteCb() {
        $.ajax({
            type: "GET",
            url: '/Cliente/ListarCliente',
            dataType: "json",
            success: function (data) {
                $.each(data.data, function (key, I) {

                    // alert(I.razon_social + "" + I.cod_cliente);
                    $("#cb_cliente").append('<option value=' + I.cod_cliente + '>' + I.razon_social + '</option>');
                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }




    var tablaSucursal;

    function ListarSucursal() {
        tablaSucursal = $("#tbl_sucursal").DataTable({
            "ajax": {
                "url": "/Cliente/ListarSucursal",
                "type": "GET",
                "datatype": "json"
            },
            "responsive": "true",
            "columns": [
                { "data": "nom_cliente" },
                { "data": "nom_sucursal" },
                { "data": "dir" },
                { "data": "tel" },
                { "data": "tel2" },
                { "data": "correo" },
                { "data": "ib_geo", "render": function (data) {
                    if (data == true)

                        return "<div class='custom-control custom-checkbox'><input type='checkbox' class='custom-control-input' id='ib_geo' checked><label class='custom-control-label' for='ib_geo'></label></div >";
                          //  return "<input type='checkbox' class='js-switch' checked/>";
                        else
                        return "<div class='custom-control custom-checkbox'><input type='checkbox' class='custom-control-input' id='ib_geo' ><label class='custom-control-label' for='ib_geo'></label></div >";
                    }
                },
                {"data": "ib_esprim", "render": function (data) {

                        if (data = true)
                            return "<span class='badge badge-primary'>Principal</span>";
                        else
                            return "<span class='badge badge-danger'>Secundario</span>";
                    }
                },

                { "data": "usu_reg" },
                { "data": "fec_reg" },
                { "data": "usu_mdf" },
                { "data": "fec_mdf" },
                { "data": "estado",
                    "render": function (data) {
                        if (data == true)
                            return "<span class='badge badge-primary'>Activo</span>";
                        else
                            return "<span class='badge badge-danger'>Inactivo</span>";
                    }
                },
                {"data": "id_sucursal",
                    "render": function (data) {
                        return "<button class='btn btn-danger btn-sm elim' data-id='" + data + "' style='margin-left:5px'><i class='fa fa-pencil' ></i></button> <button  data-target='#myModal'   class='btn btn-success btn-sm edit'    data-id='" + data + "'  style='margin-left:5px'><i class='fa fa-pencil'></i></button>";
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



    $("#tbl_sucursal tbody").on("click", ".edit", function () {
        var cdcli = $(this).data("id")

        if (cdcli != null) {
            $.ajax({
                url: '/Cliente/Sucursal_ConsUn?IdSucursal=' + cdcli,
                type: 'GET',
                dataType: 'json',
                success: function (data) {

                    if (data != null) {

                        Id_sucursal = data.id_cliente;
                        $('#cb_cliente').val(data.cod_cliente);
                        $('#cb_cliente').trigger('change');

                        $("#txt_nom_int").val(data.nom_int);
                        $("#txt_dir").val(data.dir);
                        $("#txt_tlf").val(data.tlf);
                        $("#txt_tlf2").val(data.tlf2);
                        $("#txt_correo").val(data.correo);
                        $("#txt_lng").val(data.lng);
                        $("#txt_lat").val(data.lat);


                        if (data.ib_geo) {
                            $("#defaultUnchecked").prop("checked", true);
                            ib_geolocalizacionLocal = true;
                        } else {
                            $("#defaultUnchecked").prop("checked", false);
                            ib_geolocalizacionLocal = false;
                        }


                        if (data.ib_esprin) {
                            $("#chk_esprincipal").prop("checked", true);
                            ib_es_principal = true;
                        } else {
                            $("#chk_esprincipal").prop("checked", false);
                            ib_es_principal = false;
                        }


                    } else {

                        swal("No se pudo obtener los datos de la sucursal es null data", {
                            icon: "error",
                            timer: 2000
                        });
                    }


                    //abrir la ventana modal
                    $('#FomModalSucursal').modal('show')

                    //evento al cerrar el modal
                    $('#FomModalSucursal').on('hide.bs.modal', function (e) {
                        LimpiarFormulario();
                    })



                    /*
                    // Re-init map before show modal
                    $('#FomModalSucursal').on('show.bs.modal', function (event) {
                        var button = $(event.relatedTarget);
                        initializeGMap(button.data('lat'), button.data('lng'));
                        $("#location-map").css("width", "100%");
                        $("#map_canvas").css("width", "100%");
                    });

                    // Trigger map resize event after modal shown
                    $('#FomModalSucursal').on('shown.bs.modal', function () {
                        google.maps.event.trigger(map, "resize");
                        map.setCenter(myLatlng);
                    });

*/
                },
                error: function (err) {

                    swal("No se pudo obtener el codigo de la sucursal bad", {
                        icon: "error",
                        timer: 2000
                    });
                }
            });
        } else {

            swal("No se pudo obtener el codigo de la sucursal", {
                icon: "error",
                timer: 2000
            });
        }


    });

    $("#tbl_sucursal tbody").on("click", ".elim", function () {
        var id = $(this).data("id")

        if (id != null) {

            swal({
                title: "Advertencia?",
                text: "Esta seguro que desea  eliminar la sucursal.",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {

                    $.ajax({
                        url: '/Cliente/Sucursal_Elim?IdSucursal=' + id,
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {



                            swal(data.data, {
                                icon: "success"
                            });


                            tablaSucursal.ajax.reload();

                        },
                        error: function (data) {

                            swal(data.data, {
                                icon: "error",
                                timer: 1000
                            });
                        }
                    });

                } else {

                    swal("La Operacion fue cancelada!", {
                        icon: "error",
                    });

                }
            });

        } else {
            swal("No se pudo obtener el codigo del cliente", {
                icon: "error",
                timer: 2000
            });
        }





    });

    $("#btn_pruebas").click(function () {

        alert($("#cb_cliente").select2('val'));

    });

    function LimpiarFormulario() {
        Id_sucursal = 0;
        $("#cb_cliente").select2('val');
        $("#txt_nom_int").val('');
        $("#txt_dir").val('');
        $("#txt_tlf").val('');
        $("#txt_tlf2").val('');
        $("#txt_correo").val('');
        $("#defaultUnchecked").prop("checked", false);
        $("#txt_lng").val('');
        $("#txt_lat").val('');
        $("#chk_esprincipal").prop("checked", false);

    }





});