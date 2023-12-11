$(document).ready(function () {
    var codigoProfesor;

    $('#ProfesoresTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitoso").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCampos();
        location.reload();
    });

    $("#btnAgregarProfesor").click(function () {
        if (validarCamposProfesor()) {

            var codigoProfesor = document.getElementById("IDAgregarProfesorCodigo").value;

            if (codigoProfesor == "") {

                $.ajax({
                    url: '/Profesor/AgregarProfesor',
                    type: 'POST',
                    data: {
                        identificacion: document.getElementById("IDAgregarProfesorIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarProfesorNombre").value,
                        correo: document.getElementById("IDAgregarProfesorCorreo").value,
                        codigoCurso: document.getElementById("IDAgregarProfesorCodigoCurso").value,
                        codigoFacultad: document.getElementById("IDAgregarProfesorCodigoFacultad").value,
                        estado: document.getElementById("IDAgregarProfesorEstado").value

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarProfesorEstado");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Profesor/EditarProfesor',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarProfesorCodigo").value,
                        identificacion: document.getElementById("IDAgregarProfesorIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarProfesorNombre").value,
                        correo: document.getElementById("IDAgregarProfesorCorreo").value,
                        codigoCurso: document.getElementById("IDAgregarProfesorCodigoCurso").value,
                        codigoFacultad: document.getElementById("IDAgregarProfesorCodigoFacultad").value,
                        estado: estadoSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarProfesor").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarProfesor']").click(function () {

        codigoProfesor = $(this).data("id");
        var verDetalle = VerDetalleProfesor(codigoProfesor);

    });

    $("a[name='btnEliminarProfesor']").click(function () {

        codigoProfesor = $(this).data("id");
        $('#modalVentanaEliminarProfesor').modal('show');
    });

    $("#btnAbrirDialogAgregarProfesor").click(function () {
        $('#modalAgregarProfesor').modal('show');
    });

    $("#btnAceptarEliminarProfesorConfirmacion").click(function () {

        $.ajax({
            url: '/Profesor/EliminarProfesor',
            type: 'POST',
            data: {
                Codigo: codigoProfesor
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarProfesor').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarProfesorConfirmacion").click(function () {
        $('#modalVentanaEliminarProfesor').modal('hide');
        location.reload();
    });

    $("#textoBuscarProfesor").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ProfesoresTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarProfesor').modal('hide');

    document.getElementById("IDAgregarProfesorCodigo").value = "";
    document.getElementById("IDAgregarProfesorIdentificacion").value = "";
    document.getElementById("IDAgregarProfesorNombre").value = "";
    document.getElementById("IDAgregarProfesorCorreo").value = "";
    document.getElementById("IDAgregarProfesorCodigoCurso").value = "";
    document.getElementById("IDAgregarProfesorCodigoFacultad").value = "";
    document.getElementById("IDAgregarProfesorEstado").value = "";

    $("IDAgregarProfesorIdentificacion").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorNombre").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorCorreo").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorCodigoCurso").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorCodigoFacultad").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorEstado").css('border', '1px solid #ced4da');
}


function validarCamposProfesor() {
    var bandera = true;
    var agregarProfesorIdentificacion = document.getElementById("IDAgregarProfesorIdentificacion").value;
    var agregarProfesorNombre = document.getElementById("IDAgregarProfesorNombre").value;
    var agregarProfesorCorreo = document.getElementById("IDAgregarProfesorCorreo").value;
    var agregarProfesorCodigoCurso = document.getElementById("IDAgregarProfesorCodigoCurso").value;
    var agregarProfesorCodigoFacultad = document.getElementById("IDAgregarProfesorCodigoFacultad").value;
    var agregarProfesorEstado = document.getElementById("IDAgregarProfesorEstado").value;

    if (agregarProfesorIdentificacion == "") {
        $("#IDAgregarProfesorIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorIdentificacion').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorNombre == "") {
        $("#IDAgregarProfesorNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorNombre').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorCorreo == "") {
        $("#IDAgregarProfesorCorreo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorCorreo').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorCodigoCurso == "") {
        $("#IDAgregarProfesorCodigoCurso").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorCodigoCurso').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorCodigoFacultad == "") {
        $("#IDAgregarProfesorCodigoFacultad").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorCodigoFacultad').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorEstado == "") {
        $("#IDAgregarProfesorEstado").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorEstado').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleProfesor(codigo) {

    $.ajax({
        url: '/Profesor/VerDetalleProfesor',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarProfesorEstado").value = response.estado;
            document.getElementById("IDAgregarProfesorCodigoCurso").value = response.codigoCurso;
            document.getElementById("IDAgregarProfesorCodigoFacultad").value = response.codigoFacultad;
            document.getElementById("IDAgregarProfesorNombre").value = response.nombreCompleto;
            document.getElementById("IDAgregarProfesorCorreo").value = response.correo;
            document.getElementById("IDAgregarProfesorIdentificacion").value = response.identificacion;
            document.getElementById("IDAgregarProfesorCodigo").value = response.codigo;
            $('#modalAgregarProfesor').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}