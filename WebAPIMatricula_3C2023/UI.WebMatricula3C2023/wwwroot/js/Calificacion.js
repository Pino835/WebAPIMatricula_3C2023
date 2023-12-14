$(document).ready(function () {
    var codigoCalificacion;

    $('#CalificacionesTabla').DataTable({
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

    $("#btnAgregarCalificacion").click(function () {
        if (validarCamposCalificacion()) {

            var codigoCalificacion = document.getElementById("IDAgregarCalificacionCodigo").value;

            if (codigoCalificacion == "") {

                $.ajax({
                    url: '/Calificacion/AgregarCalificacion',
                    type: 'POST',
                    data: {
                        notaProyecto: document.getElementById("IDAgregarCalificacionNotaProyecto").value,
                        notaTareas: document.getElementById("IDAgregarCalificacionNotaTareas").value,
                        notaTrabajoCotidiano: document.getElementById("IDAgregarCalificacionNotaTrabajoCotidiano").value,
                        codigoEstudiante: document.getElementById("IDAgregarCalificacionCodigoEstudiante").value,
                        codigoProfesor: document.getElementById("IDAgregarCalificacionCodigoProfesor").value,
                        codigoCurso: document.getElementById("IDAgregarCalificacionCodigoCurso").value
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
                //var e = document.getElementById("IDAgregarCalificacionEstado");
                //var estadoSelect = e.value;
                $.ajax({
                    url: '/Calificacion/EditarCalificacion',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarCalificacionCodigo").value,
                        notaProyecto: document.getElementById("IDAgregarCalificacionNotaProyecto").value,
                        notaTareas: document.getElementById("IDAgregarCalificacionNotaTareas").value,
                        notaTrabajoCotidiano: document.getElementById("IDAgregarCalificacionNotaTrabajoCotidiano").value,
                        codigoEstudiante: document.getElementById("IDAgregarCalificacionCodigoEstudiante").value,
                        codigoProfesor: document.getElementById("IDAgregarCalificacionCodigoProfesor").value,
                        codigoCurso: document.getElementById("IDAgregarCalificacionCodigoCurso").value
                        //estado: estadoSelect
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

    $("#btnCancelarCalificacion").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarCalificacion']").click(function () {

        codigoCalificacion = $(this).data("id");
        var verDetalle = VerDetalleCalificacion(codigoCalificacion);

    });

    $("a[name='btnEliminarCalificacion']").click(function () {

        codigoCalificacion = $(this).data("id");
        $('#modalVentanaEliminarCalificacion').modal('show');
    });

    $("#btnAbrirDialogAgregarCalificacion").click(function () {
        $('#modalAgregarCalificacion').modal('show');
    });

    $("#btnAceptarEliminarCalificacionConfirmacion").click(function () {

        $.ajax({
            url: '/Calificacion/EliminarCalificacion',
            type: 'POST',
            data: {
                Codigo: codigoCalificacion
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarCalificacion').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarCalificacionConfirmacion").click(function () {
        $('#modalVentanaEliminarCalificacion').modal('hide');
        location.reload();
    });

    $("#textoBuscarCalificacion").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#CalificacionesTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarCalificacion').modal('hide');

    document.getElementById("IDAgregarCalificacionCodigo").value = "";
    document.getElementById("IDAgregarCalificacionNotaProyecto").value = "";
    document.getElementById("IDAgregarCalificacionNotaTareas").value = "";
    document.getElementById("IDAgregarCalificacionNotaTrabajoCotidiano").value = "";
    document.getElementById("IDAgregarCalificacionCodigoEstudiante").value = "";
    document.getElementById("IDAgregarCalificacionCodigoProfesor").value = "";
    document.getElementById("IDAgregarCalificacionCodigoCurso").value = "";

    $("IDAgregarCalificacionNotaProyecto").css('border', '1px solid #ced4da');
    $("IDAgregarCalificacionNotaTareas").css('border', '1px solid #ced4da');
    $("IDAgregarCalificacionNotaTrabajoCotidiano").css('border', '1px solid #ced4da');
    $("IDAgregarCalificacionCodigoEstudiante").css('border', '1px solid #ced4da');
    $("IDAgregarCalificacionCodigoProfesor").css('border', '1px solid #ced4da');
    $("IDAgregarCalificacionCodigoCurso").css('border', '1px solid #ced4da');
}


function validarCamposCalificacion() {
    var bandera = true;
    var agregarCalificacionNotaProyecto = document.getElementById("IDAgregarCalificacionNotaProyecto").value;
    var agregarCalificacionNotaTareas = document.getElementById("IDAgregarCalificacionNotaTareas").value;
    var agregarCalificacionNotaTrabajoCotidiano = document.getElementById("IDAgregarCalificacionNotaTrabajoCotidiano").value;
    var agregarCalificacionCodigoEstudiante = document.getElementById("IDAgregarCalificacionCodigoEstudiante").value;
    var agregarCalificacionCodigoProfesor = document.getElementById("IDAgregarCalificacionCodigoProfesor").value;
    var agregarCalificacionCodigoCurso = document.getElementById("IDAgregarCalificacionCodigoCurso").value;

    if (agregarCalificacionNotaProyecto == "") {
        $("#IDAgregarCalificacionNotaProyecto").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCalificacionNotaProyecto').css('border', '1px solid #ced4da');
    }

    if (agregarCalificacionNotaTareas == "") {
        $("#IDAgregarCalificacionNotaTareas").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCalificacionNotaTareas').css('border', '1px solid #ced4da');
    }

    if (agregarCalificacionNotaTrabajoCotidiano == "") {
        $("#IDAgregarCalificacionNotaTrabajoCotidiano").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCalificacionNotaTrabajoCotidiano').css('border', '1px solid #ced4da');
    }

    if (agregarCalificacionCodigoEstudiante == "") {
        $("#IDAgregarCalificacionCodigoEstudiante").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCalificacionCodigoEstudiante').css('border', '1px solid #ced4da');
    }

    if (agregarCalificacionCodigoProfesor == "") {
        $("#IDAgregarCalificacionCodigoProfesor").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCalificacionCodigoProfesor').css('border', '1px solid #ced4da');
    }

    if (agregarCalificacionCodigoCurso == "") {
        $("#IDAgregarCalificacionCodigoCurso").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCalificacionCodigoCurso').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleCalificacion(codigo) {

    $.ajax({
        url: '/Calificacion/VerDetalleCalificacion',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarCalificacionCodigoCurso").value = response.codigoCurso;
            document.getElementById("IDAgregarCalificacionCodigoProfesor").value = response.codigoProfesor;
            document.getElementById("IDAgregarCalificacionCodigoEstudiante").value = response.codigoEstudiante;
            document.getElementById("IDAgregarCalificacionNotaTrabajoCotidiano").value = response.notaTrabajoCotidiano;
            document.getElementById("IDAgregarCalificacionNotaTareas").value = response.notaTareas;
            document.getElementById("IDAgregarCalificacionNotaProyecto").value = response.notaProyecto;
            document.getElementById("IDAgregarCalificacionCodigo").value = response.codigo;
            $('#modalAgregarCalificacion').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}