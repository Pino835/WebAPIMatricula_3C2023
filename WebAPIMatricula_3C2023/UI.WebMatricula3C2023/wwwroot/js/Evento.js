$(document).ready(function () {
    var codigoEvento;

    $('#EventosTabla').DataTable({
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

    $("#btnAgregarEvento").click(function () {
        if (validarCamposEvento()) {

            var codigoEvento = document.getElementById("IDAgregarEventoCodigo").value;

            if (codigoEvento == "") {

                $.ajax({
                    url: '/Evento/AgregarEvento',
                    type: 'POST',
                    data: {
                        nombreEvento: document.getElementById("IDAgregarEventoNombreEvento").value,
                        nombreInvitado: document.getElementById("IDAgregarEventoNombreInvitado").value,
                        horario: document.getElementById("IDAgregarEventoHorario").value,
                        lugar: document.getElementById("IDAgregarEventoLugar").value,
                        tipoSello: document.getElementById("IDAgregarEventoTipoSello").value,
                        codigoDepartamento: document.getElementById("IDAgregarEventoCodigoDepartamento").value
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
                //var e = document.getElementById("IDAgregarEventoEstado");
                //var estadoSelect = e.value;
                $.ajax({
                    url: '/Evento/EditarEvento',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarEventoCodigo").value,
                        nombreEvento: document.getElementById("IDAgregarEventoNombreEvento").value,
                        nombreInvitado: document.getElementById("IDAgregarEventoNombreInvitado").value,
                        horario: document.getElementById("IDAgregarEventoHorario").value,
                        lugar: document.getElementById("IDAgregarEventoLugar").value,
                        tipoSello: document.getElementById("IDAgregarEventoTipoSello").value,
                        codigoDepartamento: document.getElementById("IDAgregarEventoCodigoDepartamento").value,
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

    $("#btnCancelarEvento").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarEvento']").click(function () {

        codigoEvento = $(this).data("id");
        var verDetalle = VerDetalleEvento(codigoEvento);

    });

    $("a[name='btnEliminarEvento']").click(function () {

        codigoEvento = $(this).data("id");
        $('#modalVentanaEliminarEvento').modal('show');
    });

    $("#btnAbrirDialogAgregarEvento").click(function () {
        $('#modalAgregarEvento').modal('show');
    });

    $("#btnAceptarEliminarEventoConfirmacion").click(function () {

        $.ajax({
            url: '/Evento/EliminarEvento',
            type: 'POST',
            data: {
                Codigo: codigoEvento
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarEvento').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarEventoConfirmacion").click(function () {
        $('#modalVentanaEliminarEvento').modal('hide');
        location.reload();
    });

    $("#textoBuscarEvento").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#EventosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarEvento').modal('hide');

    document.getElementById("IDAgregarEventoCodigo").value = "";
    document.getElementById("IDAgregarEventoNombreEvento").value = "";
    document.getElementById("IDAgregarEventoNombreInvitado").value = "";
    document.getElementById("IDAgregarEventoHorario").value = "";
    document.getElementById("IDAgregarEventoLugar").value = "";
    document.getElementById("IDAgregarEventoTipoSello").value = "";
    document.getElementById("IDAgregarEventoCodigoDepartamento").value = "";

    $("IDAgregarEventoNombreEvento").css('border', '1px solid #ced4da');
    $("IDAgregarEventoNombreInvitado").css('border', '1px solid #ced4da');
    $("IDAgregarEventoHorario").css('border', '1px solid #ced4da');
    $("IDAgregarEventoLugar").css('border', '1px solid #ced4da');
    $("IDAgregarEventoTipoSello").css('border', '1px solid #ced4da');
    $("IDAgregarEventoCodigoDepartamento").css('border', '1px solid #ced4da');
}


function validarCamposEvento() {
    var bandera = true;
    var agregarEventoNombreEvento = document.getElementById("IDAgregarEventoNombreEvento").value;
    var agregarEventoNombreInvitado = document.getElementById("IDAgregarEventoNombreInvitado").value;
    var agregarEventoHorario = document.getElementById("IDAgregarEventoHorario").value;
    var agregarEventoLugar = document.getElementById("IDAgregarEventoLugar").value;
    var agregarEventoTipoSello = document.getElementById("IDAgregarEventoTipoSello").value;
    var agregarEventoCodigoDepartamento = document.getElementById("IDAgregarEventoCodigoDepartamento").value;

    if (agregarEventoNombreEvento == "") {
        $("#IDAgregarEventoNombreEvento").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEventoNombreEvento').css('border', '1px solid #ced4da');
    }

    if (agregarEventoNombreInvitado == "") {
        $("#IDAgregarEventoNombreInvitado").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEventoNombreInvitado').css('border', '1px solid #ced4da');
    }

    if (agregarEventoHorario == "") {
        $("#IDAgregarEventoHorario").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEventoHorario').css('border', '1px solid #ced4da');
    }

    if (agregarEventoLugar == "") {
        $("#IDAgregarEventoLugar").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEventoLugar').css('border', '1px solid #ced4da');
    }

    if (agregarEventoTipoSello == "") {
        $("#IDAgregarEventoTipoSello").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEventoTipoSello').css('border', '1px solid #ced4da');
    }

    if (agregarEventoCodigoDepartamento == "") {
        $("#IDAgregarEventoCodigoDepartamento").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEventoCodigoDepartamento').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleEvento(codigo) {

    $.ajax({
        url: '/Evento/VerDetalleEvento',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarEventoCodigoDepartamento").value = response.codigoDepartamento;
            document.getElementById("IDAgregarEventoTipoSello").value = response.tipoSello;
            document.getElementById("IDAgregarEventoLugar").value = response.lugar;
            document.getElementById("IDAgregarEventoHorario").value = response.horario;
            document.getElementById("IDAgregarEventoNombreInvitado").value = response.nombreInvitado;
            document.getElementById("IDAgregarEventoNombreEvento").value = response.nombreEvento;
            document.getElementById("IDAgregarEventoCodigo").value = response.codigo;
            $('#modalAgregarEvento').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}