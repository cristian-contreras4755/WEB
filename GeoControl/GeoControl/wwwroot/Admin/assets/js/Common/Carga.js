
$(document).ready(function () {
 //#region  variables
    var id_incidencia_global = null;
    var cod_cliente_global = null;
    var id_sucursal_global = null;

    var ib_geo_global = null;
    var id_lng_global = null;
    var id_lat_global = null;

    
   //#endregion

    initializeGMap(-12.091094622433621, -76.95789120349208);
//#region Combobox

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

    $('#cb_sucursal').on('select2:select', function (e) {
        let id = $("#cb_sucursal").select2('val');

        if (id == null) {
            swal("error al  obtener el codigo de sucursal", {
                icon: "error",
                timer: 2000
            });
            return;

        } if (id == 0) {
            return;
        } else {

            ObtenerSucursalporid(id) 
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


    function ObtenerSucursalporid(id) {
        $.ajax({
            type: "GET",
            url: '/Cliente/Sucursal_ConsUn?IdSucursal=' + id,
            dataType: "json",
            success: function (data) {
                alert(data.lng);
                 ib_geo_global = data.ib_geo;
                 id_lng_global = data.lng;
                 id_lat_global = data.lat;                       
            },
            error: function (data) {
                alert(data.data);
            }
        });

    }

//#endregion

//#region  mantenimiento
    $("#btn_RegistrarIncidencia").click(function () {

        var data = {
            id_incidencia: $("#txt_razon_social").val(),
            cod_cliente: $("#txt_razon_social").val(),
            id_sucursal: $("#txt_razon_social").val(),
               
            id_estincidencia: null,
            id_tipoincidencia: $("#cb_TipoIncidencia").select2('val'),
            id_medsol: $("#cb_MedioSol").select2('val'),
            id_nivel: $("#cb_NivelIncidencia").select2('val'),

            resumen: $("#txt_resumen").val(),
            descripcion: $("#txt_descripcion").val(),
            descripcion_tec: $("#txt_descripcion_tec").val(),
            id_usuario: null,
            ib_geo: $("#txt_razon_social").val(),
            lng: $("#txt_razon_social").val(),
            lat: $("#txt_razon_social").val()
        };





        if (data.id_grupo_corp.length == 0) {
            swal("Selecione un Grupo corporativo.");
            return;
        }

        if (data.cod_tipdocidn.length == 0) {
            swal("Selecione  tipo doc. de identidad.");
            return;
        }

        if (data.ruc_empresa.length < 8) {
            swal("Ingrese un nro  de documento valido.");
            return;
        }


        if (data.direccion.length == 0) {
            swal("Ingrese la dirección");
            return;
        }

        if (data.ib_geolocalizacion == true) {

            if (data.lng.length == 0 || data.lat.length == 0) {
                swal("Selecciona  locacalizacion en mapa.");
                return;
            }
        }



        if (data.felefono.length == 0) {
            swal("Ingrese El  Telefono de la empresa");
            return;
        }


        if (data.color.length == 0) {
            swal("Ingrese El  color corporativo asignado al cliente. (RGB)");
            return;
        }



        if (data.ibtip_cliente = 0) {

            alert("tipo cliente 0");

            if (nombres.length == 0 || ap_paterno == 0 || ap_materno == 0) {
                swal("Ingrese el  nombres y  apellidos del cliente ");
                return;
            }


        } else if (data.ibtip_cliente = 1) {
            alert("tipo cliente 1");

            if (data.razon_social.length == 0 || data.nombre_comercial == 0 || data.nombre_interno == 0) {
                swal("Ingrese Razon social,nombre comercial y  nombre  interno. ");
                return;
            }

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

                //limpiar luego de registrar
                LimpiarFormulario();
                $('#myModal').modal('hide')
                tablaCliente.ajax.reload();

            },
            error: function (result) {
                swal(result, {
                    icon: "error",
                    timer: 2000
                });
            }
        });



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
            $("#txt_lng").val(Newlng);
            $("#txt_lat").val(Newlat);

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
                var markerc = new google.maps.Marker({
                    map: resultsMap,
                    position: results[0].geometry.location
                });
            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });
    }




    //#endregion







});
















