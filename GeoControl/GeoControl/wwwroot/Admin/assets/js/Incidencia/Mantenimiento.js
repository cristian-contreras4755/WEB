$(document).ready(function () {
    var id_estinc_global = null;
    var id_nivel_global = null;
    var id_medsol_global = null;
    var id_tipoincidencia_global = null;
    
  
    ListarEstadoIncidencia();
    ListarNivel();
    ListarTipoIncidencia();
    ListarMedioSol();


    $("#btn_GuardarMdfEstInc").click(function () {
        
     
        if (id_estinc_global == null) {
            id_estinc_global = 0;
        }

        alert(id_estinc_global);
        var data = {
            id_estinc: id_estinc_global,
            descripcion: $("#txt_Descripcion_EstInc").val().toUpperCase()
        }

        if (data.descripcion.length == 0) {
            swal("Ingrese descripcion de estado incidencia");
            return;
        }


        $.ajax({
            url: '/Incidencia/EstadoIncidencia_CreaMdf/',
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
                $("#tbl_EstInc tbody  tr").remove();
                ListarEstadoIncidencia();
            },
            error: function (result) {
                swal(result, {
                    icon: "error",
                    timer: 2000
                });
            }
        });



    });
    $("#btn_GuardarMdfNivInc").click(function () {


        if (id_nivel_global == null) {
            id_nivel_global = 0;
        }

        var data = {
            id_nivel: id_nivel_global,
            descripcion: $("#txt_Descripcion_NivInc").val().toUpperCase()
        }

        if (data.descripcion.length == 0) {
            swal("Ingrese descripcion del nivel Incidencia");
            return;
        }


        $.ajax({
            url: '/Incidencia/Nivel_CreaMdf/',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {

                swal(data.data, {
                    icon: "success",
                    timer: 2000
                });

                LimpiarFormulario();
                $("#tbl_NivInc tbody  tr").remove();
                ListarNivel();

            },
            error: function (result) {
                swal(result, {
                    icon: "error",
                    timer: 2000
                });
            }
        });



    });
    $("#btn_GuardarMdfTipInc").click(function () {

        if (id_tipoincidencia_global == null) {
            id_tipoincidencia_global = 0;
        }

        var data = {
            id_tipoincidencia: id_tipoincidencia_global,
            descripcion: $("#txt_Descripcion_TipInc").val().toUpperCase()
        }

        if (data.descripcion.length == 0) {
            swal("Ingrese descripcion del Tipo Incidencia");
            return;
        }


        $.ajax({
            url: '/Incidencia/TipoIncindencia_CreaMdf/',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {

                swal(data.data, {
                    icon: "success",
                    timer: 2000
                });

                LimpiarFormulario();
                $("#tbl_TipInc tbody  tr").remove();
                ListarTipoIncidencia();

            },
            error: function (result) {
                swal(result, {
                    icon: "error",
                    timer: 2000
                });
            }
        });


    });
    $("#btn_GuardarMdfMedSol").click(function () {

        if (id_medsol_global == null) {
            id_medsol_global = 0;
        }

        var data = {
            id_medsol: id_medsol_global,
            descripcion: $("#txt_Descripcion_MedSol").val().toUpperCase()
        }

        if (data.descripcion.length == 0) {
            swal("Ingrese descripcion del Medio solicitud");
            return;
        }


        $.ajax({
            url: '/Incidencia/MedioSolicitud_CreaMdf/',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {

                swal(data.data, {
                    icon: "success",
                    timer: 2000
                });

                LimpiarFormulario();
                $("#tbl_MedSol tbody  tr").remove();
                ListarMedioSol();

            },
            error: function (result) {
                swal(result, {
                    icon: "error",
                    timer: 2000
                });
            }
        });



    });
    
    function ListarEstadoIncidencia() {
        $.ajax({
            type: "GET",
            url: '/Incidencia/EstadoIncidencia_Cons',
            dataType: "json",
            success: function (data) {
 
                $.each(data.data, function (key, I) {
                    var btn = '<button class="btn btn-danger btn-sm elimestinc" data-id=' + I.id_estinc + ' style="margin-left:5px"><i class="fa fa-trash" ></i></button> <button    class="btn btn-success btn-sm editestinc"    data-id=' + I.id_estinc + '  style="margin-left:5px"><i class="fa fa-pencil"></i></button>';
                    $("#tbl_EstInc").append('<tr> <th scope="row">' + I.id_estinc + '</th>I.razon_social <td>' + I.descripcion + '</td><td> ' + btn + ' </td></tr>');
         
                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }
    function ListarNivel() {
        $.ajax({
            type: "GET",
            url: '/Incidencia/Nivel_Cons',
            dataType: "json",
            success: function (data) {
                $.each(data.data, function (key, I) {
                    var btn = '<button class="btn btn-danger btn-sm elimniv" data-id=' + I.id_nivel + ' style="margin-left:5px"><i class="fa fa-trash" ></i></button> <button    class="btn btn-success btn-sm editniv"    data-id=' + I.id_nivel + '  style="margin-left:5px"><i class="fa fa-pencil"></i></button>';
                    $("#tbl_NivInc").append('<tr> <th scope="row">' + I.id_nivel + '</th>I.razon_social <td>' + I.descripcion + '</td><td> ' + btn + ' </td></tr>');

                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }
    function ListarMedioSol() {
        $.ajax({
            type: "GET",
            url: '/Incidencia/MedioSolicitud_Cons',
            dataType: "json",
            success: function (data) {

                $.each(data.data, function (key, I) {
                    var btn = '<button class="btn btn-danger btn-sm elimmedsol" data-id=' + I.id_medsol + ' style="margin-left:5px"><i class="fa fa-trash" ></i></button> <button    class="btn btn-success btn-sm editmedsol"    data-id=' + I.id_medsol + '  style="margin-left:5px"><i class="fa fa-pencil"></i></button>';
                    $("#tbl_MedSol").append('<tr> <th scope="row">' + I.id_medsol + '</th>I.razon_social <td>' + I.descripcion + '</td><td> ' + btn + ' </td></tr>');

                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }
    function ListarTipoIncidencia() {
        $.ajax({
            type: "GET",
            url: '/Incidencia/TipoIncindencia_Cons',
            dataType: "json",
            success: function (data) {

                $.each(data.data, function (key, I) {
                    var btn = '<button class="btn btn-danger btn-sm elimtipin" data-id=' + I.id_tipoincidencia + ' style="margin-left:5px"><i class="fa fa-trash" ></i></button> <button    class="btn btn-success btn-sm edittipin"    data-id=' + I.id_tipoincidencia + '  style="margin-left:5px"><i class="fa fa-pencil"></i></button>';
                    $("#tbl_TipInc").append('<tr> <th scope="row">' + I.id_tipoincidencia + '</th>I.razon_social <td>' + I.descripcion + '</td><td> ' + btn + ' </td></tr>');

                });
            },
            error: function (data) {
                alert("errortipodoc");
            }

        });
    }

 

    $("#tbl_EstInc tbody").on("click", ".editestinc", function () {
        var cdcli = $(this).data("id")

        if (cdcli != null) {
            $.ajax({
                url: '/Incidencia/EstadoIncidencia_ConsUn?IdEstIncidencia=' + cdcli,
                type: 'GET',
                dataType: 'json',
                success: function (data) {

                    if (data != null) {
                    
                        id_estinc_global= data.id_estinc;
                        $('#txt_Descripcion_EstInc').val(data.descripcion);
                    } else {

                        swal("No se pudo obtener los datos del estado.", {
                            icon: "error",
                            timer: 2000
                        });
                    }

                },
                error: function (err) {

                    swal("No se pudo obtener el codigo del estado", {
                        icon: "error",
                        timer: 2000
                    });
                }
            });
        } else {


            swal("No se pudo obtener el codigo del estado", {
                icon: "error",
                timer: 2000
            });
        }


    });
    $("#tbl_EstInc tbody").on("click", ".elimestinc", function () {
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
                        url: '/Incidencia/EstadoIncidencia_Elim?IdEstIncidencia=' + id,
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {



                            swal(data.data, {
                                icon: "success"
                            });

                            LimpiarFormulario();
                            $("#tbl_EstInc tbody  tr").remove(); 
                            ListarEstadoIncidencia();
                           

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

    $("#tbl_TipInc tbody").on("click", ".edittipin", function () {
        var cdcli = $(this).data("id")

        if (cdcli != null) {
            $.ajax({
                url: '/Incidencia/TipoIncindencia_ConsUn?IdTipoIncidencia=' + cdcli,
                type: 'GET',
                dataType: 'json',
                success: function (data) {

                    if (data != null) {

                        id_tipoincidencia_global = data.id_tipoincidencia;
                        $('#txt_Descripcion_TipInc').val(data.descripcion);
                    } else {

                        swal("No se pudo obtener los datos del tipo incidencia", {
                            icon: "error",
                            timer: 2000
                        });
                    }

                },
                error: function (err) {

                    swal("No se pudo obtener el codigo tipo incidencia", {
                        icon: "error",
                        timer: 2000
                    });
                }
            });
        } else {


            swal("No se pudo obtener el codigo del tipo incidencia", {
                icon: "error",
                timer: 2000
            });
        }


    });
    $("#tbl_TipInc tbody").on("click", ".elimtipin", function () {
        var id = $(this).data("id")

        if (id != null) {

            swal({
                title: "Advertencia?",
                text: "Esta seguro que desea  tipo de incidencia",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {

                    $.ajax({
                        url: '/Incidencia/TipoIncindencia_Elim?IdTipoIncidencia=' + id,
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {


                            swal(data.data, {
                                icon: "success"
                            });

                            LimpiarFormulario();
                            $("#tbl_TipInc tbody  tr").remove();
                            ListarTipoIncidencia();

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
            swal("No se pudo obtener el codigo del tipo incidencia", {
                icon: "error",
                timer: 2000
            });
        }





    });

    $("#tbl_NivInc tbody").on("click", ".editniv", function () {
        var cdcli = $(this).data("id")

        if (cdcli != null) {
            $.ajax({
                url: '/Incidencia/Nivel_ConsUn?IdNivel=' + cdcli,
                type: 'GET',
                dataType: 'json',
                success: function (data) {

                    if (data != null) {

                        id_nivel_global = data.id_nivel;
                        $('#txt_Descripcion_NivInc').val(data.descripcion);
                     
                    } else {

                        swal("No se pudo obtener los datos del nivel de incidencia", {
                            icon: "error",
                            timer: 2000
                        });
                    }

                },
                error: function (err) {

                    swal("No se pudo obtener el codigo de la sucursal bad", {
                        icon: "error",
                        timer: 2000
                    });
                }
            });
        } else {

            swal("No se pudo obtener el codigo del nivel de incidencia", {
                icon: "error",
                timer: 2000
            });
        }


    });
    $("#tbl_NivInc tbody").on("click", ".elimniv", function () {
        var id = $(this).data("id")

        if (id != null) {

            swal({
                title: "Advertencia?",
                text: "Esta seguro que desea  eliminar el nivel",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {

                    $.ajax({
                        url: '/Incidencia/Nivel_Elim?IdNivel=' + id,
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {
                            swal(data.data, {
                                icon: "success"
                            });
                            LimpiarFormulario();
                            $("#tbl_NivInc tbody  tr").remove();
                            ListarNivel();

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

    $("#tbl_MedSol tbody").on("click", ".editmedsol", function () {
        var cdcli = $(this).data("id")

        if (cdcli != null) {
            $.ajax({
                url: '/Incidencia/MedioSolicitud_ConsUn?IdMedSol=' + cdcli,
                type: 'GET',
                dataType: 'json',
                success: function (data) {

                    if (data != null) {

                        id_medsol_global = data.id_medsol;
                        $('#txt_Descripcion_MedSol').val(data.descripcion);

                    } else {

                        swal("No se pudo obtener los datos del medio solicitud", {
                            icon: "error",
                            timer: 2000
                        });
                    }

                },
                error: function (err) {

                    swal("No se pudo obtener el codigo de medio solicitud", {
                        icon: "error",
                        timer: 2000
                    });
                }
            });
        } else {

            swal("No se pudo obtener el codigo del medio solicitud", {
                icon: "error",
                timer: 2000
            });
        }


    });
    $("#tbl_MedSol tbody").on("click", ".elimmedsol", function () {
        var id = $(this).data("id")

        if (id != null) {

            swal({
                title: "Advertencia?",
                text: "Esta seguro que desea  medio solicitud?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {

                    $.ajax({
                        url: '/Incidencia/MedioSolicitud_Elim?IdMedSol=' + id,
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {
                            swal(data.data, {
                                icon: "success"
                            });

                            LimpiarFormulario();
                            $("#tbl_MedSol tbody  tr").remove();
                            ListarMedioSol();

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
            swal("No se pudo obtener el codigo de medio solicitud", {
                icon: "error",
                timer: 2000
            });
        }





    });



    function LimpiarFormulario() {
        id_estinc_global = null;
        id_nivel_global = null;
        id_medsol_global = null;
        id_tipoincidencia_global = null;

        $("#txt_Descripcion_EstInc").val('');
        $("#txt_Descripcion_TipInc").val('');
        $("#txt_Descripcion_NivInc").val('');
        $("#txt_Descripcion_MedSol").val('');  
    }


});