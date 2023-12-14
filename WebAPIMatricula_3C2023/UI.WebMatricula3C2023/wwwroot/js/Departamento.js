$(document).ready(function () {
    var codigoDepartamento;

    $('#DepartamentosTabla').DataTable({
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

    $("#btnAgregarDepartamento").click(function () {
        if (validarCamposDepartamento()) {

            var codigoDepartamento = document.getElementById("IDAgregarDepartamentoCodigo").value;
            console.log(codigoDepartamento)
            if (codigoDepartamento == "") {

                $.ajax({
                    url: '/Departamento/AgregarDepartamento',
                    type: 'POST',
                    data: {
                        nombre: document.getElementById("IDAgregarDepartamentoNombre").value,
                        nombreDirector: document.getElementById("IDAgregarDepartamentoNombreDirector").value,
                        horarioAtencion: document.getElementById("IDAgregarDepartamentoHorarioAtencion").value,
                        aulaAtencion: document.getElementById("IDAgregarDepartamentoAulaAtencion").value,
                        codigoProfesor: document.getElementById("IDAgregarDepartamentoCodigoProfesor").value

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        console.log(data)
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarDepartamentoCodigoProfesor");
                $.ajax({
                    url: '/Departamento/EditarDepartamento',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarDepartamentoCodigo").value,
                        nombre: document.getElementById("IDAgregarDepartamentoNombre").value,
                        nombreDirector: document.getElementById("IDAgregarDepartamentoNombreDirector").value,
                        horarioAtencion: document.getElementById("IDAgregarDepartamentoHorarioAtencion").value,
                        aulaAtencion: document.getElementById("IDAgregarDepartamentoAulaAtencion").value,
                        codigoProfesor: document.getElementById("IDAgregarDepartamentoCodigoProfesor").value
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

    $("#btnCancelarDepartamento").click(function () {
        limpiarCampos();
    });
    $("a[name='btnEditarDepartamento']").click(function () {

        codigoDepartamento = $(this).data("id");
        var verDetalle = VerDetalleDepartamento(codigoDepartamento);

    });
    $("a[name='btnEliminarDepartamento']").click(function () {

        codigoDepartamento = $(this).data("id");
        $('#modalVentanaEliminarDepartamento').modal('show');
    });
    $("#btnAbrirDialogAgregarDepartamento").click(function () {
        $('#modalAgregarDepartamento').modal('show');
    });
    $("#btnAceptarEliminarDepartamentoConfirmacion").click(function () {

        $.ajax({
            url: '/Departamento/EliminarDepartamento',
            type: 'POST',
            data: {
                Codigo: codigoDepartamento
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarDepartamento').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarDepartamentoConfirmacion").click(function () {
        $('#modalVentanaEliminarDepartamento').modal('hide');
        location.reload();
    });

    $("#textoBuscarDepartamento").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#DepartamentosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});

function limpiarCampos() {
    $('#modalAgregarDepartamento').modal('hide');

    document.getElementById("IDAgregarDepartamentoCodigo").value = "";
    document.getElementById("IDAgregarDepartamentoNombre").value = "";
    document.getElementById("IDAgregarDepartamentoNombreDirector").value = "";
    document.getElementById("IDAgregarDepartamentoHorarioAtencion").value = 
    document.getElementById("IDAgregarDepartamentoAulaAtencion").value = "";
    document.getElementById("IDAgregarDepartamentoCodigoProfesor").value = "";

    $("IDAgregarDepartamentoNombre").css('border', '1px solid #ced4da');
    $("IDAgregarDepartamentoNombreDirector").css('border', '1px solid #ced4da');
    $("IDAgregarDepartamentoHorarioAtencion").css('border', '1px solid #ced4da');
    $("IDAgregarDepartamentoAulaAtencion").css('border', '1px solid #ced4da');
    $("IDAgregarDepartamentoCodigoProfesor").css('border', '1px solid #ced4da');
}

function validarCamposDepartamento() {
    var bandera = true;
    var agregarDepartamentoNombre = document.getElementById("IDAgregarDepartamentoNombre").value;
    var agregarDepartamentoNombreDirector = document.getElementById("IDAgregarDepartamentoNombreDirector").value;
    var agregarDepartamentoHorarioAtencion = document.getElementById("IDAgregarDepartamentoHorarioAtencion").value;
    var agregarDepartamentoAulaAtencion = document.getElementById("IDAgregarDepartamentoAulaAtencion").value;
    var agregarDepartamentoCodigoProfesor = document.getElementById("IDAgregarDepartamentoCodigoProfesor").value;

    if (agregarDepartamentoNombre == "") {
        $("#IDAgregarDepartamentoNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoNombre').css('border', '1px solid #ced4da');
    }

    if (agregarDepartamentoNombreDirector == "") {
        $("#IDagregarDepartamentoNombreDirector").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDagregarDepartamentoNombreDirector').css('border', '1px solid #ced4da');
    }

    if (agregarDepartamentoHorarioAtencion == "") {
        $("#IDagregarDepartamentoHorarioAtencion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoHorarioAtencion').css('border', '1px solid #ced4da');
    }

    if (agregarDepartamentoAulaAtencion == "") {
        $("#IDAgregarDepartamentoAulaAtencion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoAulaAtencion').css('border', '1px solid #ced4da');
    } 

    if (agregarDepartamentoCodigoProfesor == "") {
        $("#IDAgregarDepartamentoCodigoProfesor").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoCodigoProfesor').css('border', '1px solid #ced4da');
    }

    return bandera;

}
function VerDetalleDepartamento(codigo) {

    $.ajax({
        url: '/Departamento/VerDetalleDepartamento',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarDepartamentoCodigoProfesor").value = response.CodigoProfesor;
            document.getElementById("IDAgregarDepartamentoAulaAtencion").value = response.AulaAtencion;
            document.getElementById("IDAgregarDepartamentoHorarioAtencion").value = response.HorarioAtencion;
            document.getElementById("IDagregarDepartamentoNombreDirector").value = response.NombreDirector;
            document.getElementById("IDAgregarDepartamentoNombre").value = response.nombre;
            document.getElementById("IDAgregarDepartamentoCodigo").value = response.codigo;
            $('#modalAgregarDepartamento').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}