$(document).ready(function () {
    var codigoFinanza;

    $('#FinanzasTabla').DataTable({
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

    $("#btnAgregarFinanza").click(function () {
        if (validarCamposFinanza()) {

            var codigoFinanza = document.getElementById("IDAgregarFinanzaCodigo").value;

            if (codigoFinanza == "") {

                $.ajax({
                    url: '/Finanza/AgregarFinanza',
                    type: 'POST',
                    data: {
                        totalMaterias: document.getElementById("IDAgregarFinanzaTotalMaterias").value,
                        cobroMatricula: document.getElementById("IDAgregarFinanzaCobroMatricula").value,
                        cobroPoliza: document.getElementById("IDAgregarFinanzaCobroPoliza").value,
                        cobroTechFee: document.getElementById("IDAgregarFinanzaCobroTechFee").value,
                        codigoMatricula: document.getElementById("IDAgregarFinanzaCodigoMatricula").value
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
                /*var e = document.getElementById("IDAgregarFinanzaEstado");
                var estadoSelect = e.value;*/
                $.ajax({
                    url: '/Finanza/EditarFinanza',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarFinanzaCodigo").value,
                        totalMaterias: document.getElementById("IDAgregarFinanzaTotalMaterias").value,
                        cobroMatricula: document.getElementById("IDAgregarFinanzaCobroMatricula").value,
                        cobroPoliza: document.getElementById("IDAgregarFinanzaCobroPoliza").value,
                        cobroTechFee: document.getElementById("IDAgregarFinanzaCobroTechFee").value,
                        codigoMatricula: document.getElementById("IDAgregarFinanzaCodigoMatricula").value,
                        /* estado: estadoSelect */
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

    $("#btnCancelarFinanza").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarFinanza']").click(function () {

        codigoFinanza = $(this).data("id");
        var verDetalle = VerDetalleFinanza(codigoFinanza);

    });

    $("a[name='btnEliminarFinanza']").click(function () {

        codigoFinanza = $(this).data("id");
        $('#modalVentanaEliminarFinanza').modal('show');
    });

    $("#btnAbrirDialogAgregarFinanza").click(function () {
        $('#modalAgregarFinanza').modal('show');
    });

    $("#btnAceptarEliminarFinanzaConfirmacion").click(function () {

        $.ajax({
            url: '/Finanza/EliminarFinanza',
            type: 'POST',
            data: {
                Codigo: codigoFinanza
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarFinanza').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarFinanzaConfirmacion").click(function () {
        $('#modalVentanaEliminarFinanza').modal('hide');
        location.reload();
    });

    $("#textoBuscarFinanza").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#FinanzasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarFinanza').modal('hide');

    document.getElementById("IDAgregarFinanzaCodigo").value = "";
    document.getElementById("IDAgregarFinanzaTotalMaterias").value = "";
    document.getElementById("IDAgregarFinanzaCobroMatricula").value = "";
    document.getElementById("IDAgregarFinanzaCobroPoliza").value = "";
    document.getElementById("IDAgregarFinanzaCobroTechFee").value = "";
    document.getElementById("IDAgregarFinanzaCodigoMatricula").value = "";

    $("IDAgregarFinanzaTotalMaterias").css('border', '1px solid #ced4da');
    $("IDAgregarFinanzaCobroMatricula").css('border', '1px solid #ced4da');
    $("IDAgregarFinanzaCobroPoliza").css('border', '1px solid #ced4da');
    $("IDAgregarFinanzaCobroTechFee").css('border', '1px solid #ced4da');
    $("IDAgregarFinanzaCodigoMatricula").css('border', '1px solid #ced4da');
}


function validarCamposFinanza() {
    var bandera = true;
    var agregarFinanzaTotalMaterias = document.getElementById("IDAgregarFinanzaTotalMaterias").value;
    var agregarFinanzaCobroMatricula = document.getElementById("IDAgregarFinanzaCobroMatricula").value;
    var agregarFinanzaCobroPoliza = document.getElementById("IDAgregarFinanzaCobroPoliza").value;
    var agregarFinanzaCobroTechFee = document.getElementById("IDAgregarFinanzaCobroTechFee").value;
    var agregarFinanzaCodigoMatricula = document.getElementById("IDAgregarFinanzaCodigoMatricula").value;

    if (agregarFinanzaTotalMaterias == "") {
        $("#IDAgregarFinanzaTotalMaterias").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarFinanzaTotalMaterias').css('border', '1px solid #ced4da');
    }

    if (agregarFinanzaCobroMatricula == "") {
        $("#IDAgregarFinanzaCobroMatricula").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarFinanzaCobroMatricula').css('border', '1px solid #ced4da');
    }

    if (agregarFinanzaCobroPoliza == "") {
        $("#IDAgregarFinanzaCobroPoliza").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarFinanzaCobroPoliza').css('border', '1px solid #ced4da');
    }

    if (agregarFinanzaCobroTechFee == "") {
        $("#IDAgregarFinanzaCobroTechFee").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarFinanzaCobroTechFee').css('border', '1px solid #ced4da');
    }

    if (agregarFinanzaCodigoMatricula == "") {
        $("#IDAgregarFinanzaCodigoMatricula").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarFinanzaCodigoMatricula').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleFinanza(codigo) {

    $.ajax({
        url: '/Finanza/VerDetalleFinanza',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarFinanzaCodigoMatricula").value = response.codigoMatricula;
            document.getElementById("IDAgregarFinanzaCobroTechFee").value = response.cobroTechFee;
            document.getElementById("IDAgregarFinanzaCobroPoliza").value = response.cobroPoliza;
            document.getElementById("IDAgregarFinanzaCobroMatricula").value = response.cobroMatricula;
            document.getElementById("IDAgregarFinanzaTotalMaterias").value = response.totalMaterias;
            document.getElementById("IDAgregarFinanzaCodigo").value = response.codigo;
            $('#modalAgregarFinanza').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}