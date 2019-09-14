

$(document).ready(function () {
    //si es verdadero es de registro
    // si es falso es de edicion
    var cod_cliente = null;

    ListarCliente();

    $('#cb_tipopersona').select2({
        //theme: "bootstrap4",
        placeholder: 'Seleciona tipo cliente.',
        width: '100%'
    });



    ListarCboGrupoCorporativo();
    $('#cb_grupo_corporativo').select2({
       // theme: "bootstrap4",
        placeholder: 'grupo corporativo documento...',
        allowClear: true,
        tags: true,
        maximumSelectionLength: 3,
        width: '100%'
    });



    ListarCboTipoDocIden();
    $('#cb_tipodocidentidad').select2({
       // theme: "bootstrap4",
        placeholder: 'Tipo documento...',
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




    $("#btn_GuardarMdfCliente").click(function () {

        
        var ib_geolocalizacionLocal;

        if ($("#defaultUnchecked").is(':checked')) {
            ib_geolocalizacionLocal = true;
        } else {
            ib_geolocalizacionLocal = false;
        }




        var data = {
            cod_cliente: cod_cliente,
            id_grupo_corp: $("#cb_grupo_corporativo").select2('val'),
            cod_tipdocidn: $("#cb_tipodocidentidad").select2('val'),
            ruc_empresa: $("#txt_nroDoc").val(),
            razon_social: $("#txt_razon_social").val(),
            nombre_comercial: $("#txt_nomcomercial").val(),
            nombre_interno: $("#txt_nominterno").val(),
            nombres: $("#txt_nombre_cliente").val(),
            ap_paterno: $("#txt_appaterno").val(),
            ap_materno: $("#txt_apmaterno").val(),
            direccion: $("#txt_direccion").val(),
            direccion2: $("#txt_direccion2").val(),
            ib_geolocalizacion:ib_geolocalizacionLocal,
            lng: $("#txt_lng").val(),
            lat: $("#txt_lat").val(),
            felefono: $("#txt_telefono").val(),
            color: $("#txt_color").val(),
            ibtip_cliente: $("#cb_tipopersona").select2('val') 
        };





        if (data.id_grupo_corp.length == 0) {
            swal("Selecione un Grupo corporativo.");
            return;
        }

        if (data.cod_tipdocidn.length == 0) {
            swal("Selecione  tipo doc. de identidad.");
            return;
        }

        if (data.ruc_empresa.length <8) {
            swal("Ingrese un nro  de documento valido.");
            return;
        }


        if (data.direccion.length== 0) {
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
                url: '/Cliente/Cliente_Crea/',
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


    //inicio google maps

  
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
    $('#myModal').on('show.bs.modal', function (event) {
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
    $('#myModal').on('shown.bs.modal', function () {
        google.maps.event.trigger(map, "resize");
        map.setCenter(myLatlng);
    });

*/

    function ListarCboTipoDocIden() {
        $.ajax({
            type: "GET",
            url: '/Cliente/ListarTipoDocIdn',
            dataType: "json",
            success: function (data) {
                alert('error');
                $.each(data, function (key, I) {
                    $("#cb_tipodocidentidad").append('<option value=' + I.cod_tipodocidn + '>' + I.descripcion + '</option>');
                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }

    function ListarCboGrupoCorporativo() {
        $.ajax({
            type: "GET",
            url: '/Cliente/CBListarGrupoCorporativo',
            dataType: "json",
            success: function (data) {
                $.each(data, function (key, I) {
                    $("#cb_grupo_corporativo").append('<option value=' + I.id_grupocorp + '>' + I.descripcion + '</option>');
                });
            },
            error: function (data) {
                alert("errorgrupo corp");
            }
        });

    }


    $(".idnfilacli").click(function () {

        swal("hola-" + cod_cliente);

    });


 
    
    var tablaCliente;
    function ListarCliente() {
         tablaCliente = $("#tbl_cliente").DataTable({
            "ajax": {
                "url": "/Cliente/ListarCliente",
                "type": "GET",
                "datatype": "json"
            },
            "responsive": "true",
            "columns": [
                { "data": "cod_cliente" },
                { "data": "grupo_corp" },
                { "data": "tipo_doc_idn" },
                { "data": "ruc" },
                { "data": "razon_social" },
                { "data": "nom_comercial" },
                { "data": "nom_interno" },
                { "data": "direccion" },
                { "data": "direccion2" },
                { "data": "ib_geolocalizacion", "render": function (data) {
                        if (data = true)
                            return "<input type='checkbox' class='js-switch' checked/>";
                        else
                            return "<input type='checkbox' class='js-switch' checked/>";
                    }
                },
                { "data": "fecha_mdf" },
                { "data": "usu_mdf" },
                { "data": "fecha_reg" },
                { "data": "usu_reg" },
                { "data": "telefono" },
                { "data": "color" },
                {
                    "data": "ib_tipocliente",
                    "render": function (data) {
                        if (data == true)
                            return "<span class='badge badge-primary'>PJ</span>";
                        else
                            return "<span class='badge badge-danger'>PN</span>";
                    }
                },
                { "data": "ib_estado",
                    "render": function (data) {
                        if (data == true)
                            return "<span class='badge badge-primary'>Activo</span>";
                        else
                            return "<span class='badge badge-danger'>Inactivo</span>";
                    }
                },
                {
                    "data": "cod_cliente",
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


    /*
    $(document).on('click', '.edit', function () {

        var id = $(this).attr("id");
        swal("hola-" + id);
    });
  */


    $("#tbl_cliente tbody").on("click", ".edit", function () {
        var cdcli = $(this).data("id")

        if (cdcli != null) {
            $.ajax({
                url: '/Cliente/Cliente_ConsUn?CodCliente='+ cdcli,
                type: 'GET',
                dataType: 'json',
                success: function (data) {

                    if (data != null) {    

                        cod_cliente = data.cod_cliente;
                        $('#cb_grupo_corporativo').val(data.id_grupo_corp); 
                        $('#cb_grupo_corporativo').trigger('change');

                        $('#cb_tipodocidentidad').val(data.cod_tipdocidn);
                        $('#cb_tipodocidentidad').trigger('change');
                      
                        $("#txt_nroDoc").val(data.ruc_empresa);
                        $("#txt_razon_social").val(data.razon_social);
                        $("#txt_nomcomercial").val(data.nombre_comercial);
                        $("#txt_nominterno").val(data.nombre_interno);
                        $("#txt_nombre_cliente").val(data.nombres);
                        $("#txt_appaterno").val(data.ap_paterno);
                        $("#txt_apmaterno").val(data.ap_materno);
                        $("#txt_direccion").val(data.direccion);
                        $("#txt_direccion2").val(data.direccion2);

                        if (data.ib_geolocalizacion) {
                            $("#defaultUnchecked").prop("checked", true);
                            ib_geolocalizacionLocal = true;
                        } else {
                            $("#defaultUnchecked").prop("checked", false);
                            ib_geolocalizacionLocal = false;
                        }

                        $("#txt_lng").val(data.lng);
                        $("#txt_lat").val(data.lat);
                        


                        $("#txt_telefono").val(data.felefono);
                        $("#txt_color").val(data.color);
                        //tipo persona

                       // console.log(data.cb_tipopersona);
                        if (data.ibtip_cliente==true) {
                            $('#cb_tipopersona').val(1);
                            $('#cb_tipopersona').trigger('change');
                        } else {
                            $('#cb_tipopersona').val(0);
                            $('#cb_tipopersona').trigger('change');

                        }

                    } else {

                        swal("No se pudo obtener los datos del cliente es null data", {
                            icon: "error",
                            timer: 2000
                        }); 
                    }


                    //abrir la ventana modal
                    $('#myModal').modal('show')

                    //evento al cerrar el modal
                    $('#myModal').on('hide.bs.modal', function (e) {
                        LimpiarFormulario();
                    })



                    /*
                    // Re-init map before show modal
                    $('#myModal').on('show.bs.modal', function (event) {
                        var button = $(event.relatedTarget);
                        initializeGMap(button.data('lat'), button.data('lng'));
                        $("#location-map").css("width", "100%");
                        $("#map_canvas").css("width", "100%");
                    });

                    // Trigger map resize event after modal shown
                    $('#myModal').on('shown.bs.modal', function () {
                        google.maps.event.trigger(map, "resize");
                        map.setCenter(myLatlng);
                    });

*/
                },
                error: function (err) {

                    swal("No se pudo obtener el codigo del cliente bad", {
                        icon: "error",
                        timer: 2000
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


    $("#tbl_cliente tbody").on("click", ".elim", function () {
        var id = $(this).data("id")

        if (id != null) {

                swal({
                    title: "Advertencia?",
                    text: "Esta seguro que desea  eliminar al cliente.",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                }).then((willDelete) => {
                    if (willDelete) {

                        $.ajax({
                            url: '/Cliente/Cliente_Elim?CodCliente='+id,
                            type: 'POST',
                            dataType: 'json',
                            success: function (data) {

                            

                                swal(data.data, {
                                    icon: "success"
                                });


                                    tablaCliente.ajax.reload();
                             
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

        alert($("#cb_tipopersona").select2('val'));

    });



    function LimpiarFormulario() {

        cod_cliente = null;
        $("#cb_tipopersona").select2('val','');
        $("#cb_grupo_corporativo").select2('val', '');
        $("#cb_tipodocidentidad").select2('val', '');
        $("#txt_nroDoc").val('');
        $("#txt_razon_social").val('');
        $("#txt_nomcomercial").val('');
        $("#txt_nominterno").val('');
        $("#txt_nombre_cliente").val('');
        $("#txt_appaterno").val('');
        $("#txt_apmaterno").val('');
        $("#txt_direccion").val('');
        $("#txt_direccion2").val('');
        $("#defaultUnchecked").prop("checked", false);
        $("#txt_lng").val('');
        $("#txt_lat").val('');
        $("#txt_telefono").val('');
        $("#txt_color").val('');     
    }


});











