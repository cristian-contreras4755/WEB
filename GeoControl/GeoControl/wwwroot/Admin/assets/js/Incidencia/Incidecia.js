
$(document).ready(function () {
 //#region  variables
    var id_incidencia_global = null;
    var cod_cliente_global = null;
    var id_sucursal_global = null;


    var ib_geo_global = null;
    var lng_global = null;
    var lat_global = null;

    
   //#endregion

    initializeGMap(-12.091094622433621, -76.95789120349208);
    Listar_Incidencia_pendientes();
//#region Combobox

    
    $('#cb_ubicacion').select2({
        // theme: "bootstrap4",
        placeholder: 'Seleccionar Ubicación...',
        allowClear: true,
        tags: true,
        maximumSelectionLength: 3,
        width: '100%'
    });


      ListarCboTipoIncidencia();
    $('#cb_TipoIncidencia').select2({
        // theme: "bootstrap4",
        placeholder: 'Tipo Incidencia...',
        allowClear: true,
        tags: true,
        maximumSelectionLength: 3,
        width: '100%'
    });

    ListarCboNivelIncidencia();
    $('#cb_NivelIncidencia').select2({
        // theme: "bootstrap4",
        placeholder: 'Nivel Incidencia...',
        allowClear: true,
        tags: true,
        maximumSelectionLength: 3,
        width: '100%'
    });

    ListarCboMedioSol();
    $('#cb_MedioSol').select2({
        // theme: "bootstrap4",
        placeholder: 'Medio Solicitud...',
        allowClear: true,
        tags: true,
        maximumSelectionLength: 3,
        width: '100%'
    });


    ListarCboCliente();
    $('#cb_cliente').select2({
         
        placeholder: 'Medio Solicitud...',
        allowClear: true,
        tags: true,
        maximumSelectionLength: 3,
        width: '100%'
    });


    $('#cb_cliente').on('select2:select', function (e) {    
        let id = $("#cb_cliente").select2('val');

        if (id == null ) {
            swal("error al  obtener codigo cliente", {
                icon: "error",
                timer: 2000
            });
            return;

        } if (id == 0) {
            $("#cb_sucursal option").remove();
            return;
        } else {     
            ListarSucursalrxcodcliente(id);
        }
    });



    $('#cb_ubicacion').on('select2:select', function (e) {
        let id = $("#cb_ubicacion").select2('val');

        if (id == null) {
            swal("error al  obtener la ubicacion seleccionada", {
                icon: "error",
                timer: 2000
            });

             ib_geo_global = null;
             lng_global = null;
             lat_global = null;
            return;

        } if (id == 0) {
            ib_geo_global = null;
            lng_global = null;
            lat_global = null;
            return;

        } if (id == 1) {

            var id_cliente = $("#cb_cliente").select2('val');
            if (id_cliente == null || id_cliente == 0  ) {
                swal("Seleccione el cliente", {
                    icon: "error",
                    timer: 2000
                });
            }

            $.ajax({
                type: "GET",
                url: '/Cliente/Cliente_ConsUn?CodCliente=' + id_cliente,
                dataType: "json",
                success: function (data) {
                    alert("clientw" + data.ib_geolocalizacion + data.lng);

                    ib_geo_global = data.ib_geolocalizacion;
                    lng_global = data.lng;
                    lat_global = data.lat;
                },
                error: function (data) {
                    swal(data.data, {
                        icon: "error",
                        timer: 2000
                    });
                }
            });

            return;

        } if (id == 2) {

            var id_sucursall = $("#cb_sucursal").select2('val');

            if (id_sucursall == null || id_sucursall == 0) {
                swal("Seleccione el sucursal ", {
                    icon: "error",
                    timer: 2000
                });
            }

            $.ajax({
                type: "GET",
                url: '/Cliente/Sucursal_ConsUn?IdSucursal=' + id_sucursall,
                dataType: "json",
                success: function (data) {

                    alert("sucursal" + data.ib_geo + "-" + data.lng + "-" + data.lat);

                    ib_geo_global = data.ib_geo;
                    lng_global = data.lng;
                    lat_global = data.lat;
                },
                error: function (data) {

                    swal(data.data, {
                        icon: "error",
                        timer: 2000
                    });
                }
            });
            return;

        } if (id == 3) {
            ib_geo_global = null;
            lng_global = null;
            lat_global = null;
            return;
        }
    });



    

    function ListarCboTipoIncidencia() {
        $.ajax({
            type: "GET",
            url: '/Incidencia/TipoIncindencia_Cons',
            dataType: "json",
            success: function (data) {
           
                $.each(data.data, function (key, I) {
                    $("#cb_TipoIncidencia").append('<option value=' + I.id_tipoincidencia + '>' + I.descripcion + '</option>');
                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }

    function ListarCboNivelIncidencia() {
        $.ajax({
            type: "GET",
            url: '/Incidencia/Nivel_Cons',
            dataType: "json",
            success: function (data) {
            
                $.each(data.data, function (key, I) {
                    $("#cb_NivelIncidencia").append('<option value=' + I.id_nivel + '>' + I.descripcion + '</option>');
                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }

    function ListarCboMedioSol() {
        $.ajax({
            type: "GET",
            url: '/Incidencia/MedioSolicitud_Cons',
            dataType: "json",
            success: function (data) {
                $.each(data.data, function (key, I) {
                    $("#cb_MedioSol").append('<option value=' + I.id_medsol + '>' + I.descripcion + '</option>');
                });
            },
            error: function (data) {
                alert("errorgrupo corp");
            }
        });

    }

    function ListarCboCliente() {
        $.ajax({
            type: "GET",
            url: '/Cliente/ListarCliente',
            dataType: "json",
            success: function (data) {
                $.each(data.data, function (key, I) {
                    $("#cb_cliente").append('<option value=' + I.cod_cliente + '>' + I.razon_social + '</option>');
                });
            },
            error: function (data) {
                alert("errorgrupo corp");
            }
        });

    }

    function ListarSucursalrxcodcliente(codcliente) {
   
        $.ajax({
            type: "GET",
            url: '/Cliente/Sucursal_xcodclienteCons?CodCliente='+codcliente ,
            dataType: "json",
            success: function (data) {

                $("#cb_sucursal option").remove();
                $("#cb_sucursal").append('<option value="0">-- Selecione sucursal--</option>');   
                $.each(data.data, function (key, I) {
                    $("#cb_sucursal").append('<option value=' + I.id_sucursal + '>' + I.nom_sucursal + '</option>');
                });

                $('#cb_sucursal').select2({
                    placeholder: 'Selecciona Sucursal...',
                    allowClear: true,
                    tags: true,
                    maximumSelectionLength: 3,
                    width: '100%'
                });
               
            },
            error: function (data) {

                swal(data.data, {
                    icon: "error",
                    timer: 2000
                });
         
            }
        });

    }
//#endregion





    var tablaIncidenciaPendientes;
    function Listar_Incidencia_pendientes() {
        tablaIncidenciaPendientes = $("#tbl_incid_pendientes").DataTable({
            "ajax": {
                "url": "/Incidencia/ListarIncidencia/1",
                "type": "GET",
                "datatype": "json"
            },
            "responsive": "true",
            "columns": [
                { "data": "cod_incidencia" },
                { "data": "cliente" },
                { "data": "sucursal" },
                { "data": "tipo_incidencia" },
                { "data": "estado" },
                { "data": "fecha" },
                { "data": "contacto" },
                { "data": "usu_reg" },
                { "data": "usu_mdf" },
                {"data": "id_incidencia",
                    "render": function (data) {
                        return "<button class='btn btn-danger btn-sm editar' data-id='" + data + "' style='margin-left:5px'><i class='fa fa-pencil' ></i>Editar</button> <button  data-target='#myModal'   class='btn btn-success btn-sm derivar'    data-id='" + data + "'  style='margin-left:5px'><i class='fa fa-pencil'></i>Derivar</button>";
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








//#region  mantenimiento
    $("#btn_GuardarMdfIncidencia").click(function () {

        var pamatrosucursal = null;

        if ($("#cb_cliente").select2('val') == 0 || $("#cb_cliente").select2('val') == null) {
            swal("Selecione un Cliente.");
            return;
        }

        if ($("#cb_sucursal").select2('val') == 0) {
            swal({
                title: "Advertencia!",
                text: "Esta seguro que   que no que a incidencia  va dirigida a la instalaciones de cliente",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {

                    pamatrosucursal = null;
                } else {

                    swal("Por Favor seleccione sucursal", {
                        icon: "error",
                    });
                    return;
                }
            });
        } else {
            pamatrosucursal = $("#cb_sucursal").select2('val');
        }


        var data = {
            id_incidencia: id_incidencia_global,
            cod_cliente: $("#cb_cliente").select2('val'),
            id_sucursal: pamatrosucursal,
            id_estincidencia: null,
            id_tipoincidencia: $("#cb_TipoIncidencia").select2('val'),
            id_medsol: $("#cb_MedioSol").select2('val'),
            id_nivel: $("#cb_NivelIncidencia").select2('val'),

            resumen: $("#txt_resumen").val(),
            descripcion: $("#txt_descripcion").val(),
            descripcion_tec: $("#txt_descripcion_tec").val(),
            descripcion_cancel: $("#txt_descripcion_cancel").val(),
            nom_contacto: $("#txt_nom_contacto").val(),
            id_usuario: null,
            ib_geo: ib_geo_global,
            lng: lng_global,
            lat: lat_global
        };



        if (data.id_tipoincidencia == 0) {
            swal("Selecione  tipo incidencia.");
            return;
        }

        if (data.id_nivel == 0) {
            swal("Selecione  nivel incidencia");
            return;
        }


        if (data.id_medsol == 0) {
            swal("Selecione  medio solicitud");
            return;
        }


        if (data.descripcion.length == 0) {
            swal("Ingrese  descripcion de la incidencia");
            return;
        }

        if (data.descripcion_tec.length == 0) {
            swal("Ingrese  descripcion  tecnica");
            return;
        }


        if (data.resumen.length == 0) {
            swal("Ingrese resumen de la incidencia");
            return;
        }



        if (data.ib_geo == true) {

            if (data.lng.length == 0) {
                swal("no ha seleccionado  una ubicacion");
                return;
            }

            if (data.lat.length == 0) {
                swal("no ha seleccionado  una ubicacion");
                return;
            }
        } else {

            swal("Por favor seleccione  Localización de la incidencia");
            return;
        }



        $.ajax({
            url: '/Incidencia/Incidencia_CreaMdf/',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {
                swal(data.data, {
                    icon: "success",
                    timer: 2000
                });

              //  LimpiarFormulario();
          
            },
            error: function (data) {
                swal(data.responseJSON.data, {
                    icon: "error",
                    timer: 2000
                });
      
            }
        });



    });

    $("#btn_CancelarIncidencia").click(function () {


    });

//#endregion

 //#region  google maps
    function initializeGMap(lat, lng) {
        myLatlng = new google.maps.LatLng(lat, lng);

        var myOptions = {
            zoom: 12,
            zoomControl: true,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

       var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

        var marker = new google.maps.Marker({ position: map.getCenter(), map: map, draggable: true });

        google.maps.event.addListener(marker, 'dragend', function (event) {
            var Newlat = map.getCenter().lat();
            var Newlng = map.getCenter().lng();

             ib_geo_global = true;
             lng_global = Newlng;
            lat_global = Newlat;

            swal("Ubicación seleccionada", {
                icon: "success",
                timer: 1000
            });

        });


      var  geocoder = new google.maps.Geocoder();

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


        document.getElementById('btn_buscar_ubicacion').addEventListener('click', function () {
            geocodeAddress(geocoder, map);
        });

  

    }



    function geocodeAddress(geocoder, resultsMap) {
        var address = document.getElementById('txt_buscar_ubicacion').value;

        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status === 'OK') {
                resultsMap.setCenter(results[0].geometry.location);

/*
                var markerc = new google.maps.Marker({
                    map: resultsMap,
                    position: results[0].geometry.location
                });
                */


            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });
    }




    //#endregion


    function LimpiarFormulario() {
         id_incidencia_global = null;
         cod_cliente_global = null;
         id_sucursal_global = null;
         ib_geo_global = null;
         lng_global = null;
         lat_global = null;
    }





});
















