$(document).ready(function () {
    var codigoPrograma;

    $('#ProgramasTabla').DataTable({
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

    $("#btnAgregarPrograma").click(function () {
        if (validarCamposPrograma()) {

            var codigoPrograma = document.getElementById("IDAgregarProgramaCodigo").value;

            if (codigoPrograma == "") {

                $.ajax({
                    url: '/Programa/AgregarPrograma',
                    type: 'POST',
                    data: {
                        NombreCarrera: document.getElementById("IDAgregarProgramaNombreCarrera").value,
                        Modalidad: document.getElementById("IDAgregarProgramaModalidad").value,
                        Idioma: document.getElementById("IDAgregarProgramaIdioma").value,
                        CantidadCuatrimestres: document.getElementById("IDAgregarProgramaCantidadCuatrimestres").value,
                        CodigoDepartamento: document.getElementById("IDAgregarProgramaCodigoDepartamento").value

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
                var e = document.getElementById("IDAgregarProgramaCodigoDepartamento");
                $.ajax({
                    url: '/Programa/EditarPrograma',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarProgramaCodigo").value,
                        NombreCarrera: document.getElementById("IDAgregarProgramaNombreCarrera").value,
                        Modalidad: document.getElementById("IDAgregarProgramaModalidad").value,
                        Idioma: document.getElementById("IDAgregarProgramaIdioma").value,
                        CantidadCuatrimestres: document.getElementById("IDAgregarProgramaCantidadCuatrimestres").value,
                        CodigoDepartamento: document.getElementById("IDAgregarProgramaCodigoDepartamento").value
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

    $("#btnCancelarPrograma").click(function () {
        limpiarCampos();
    });
    $("a[name='btnEditarPrograma']").click(function () {

        codigoPrograma = $(this).data("id");
        var verDetalle = VerDetallePrograma(codigoPrograma);

    });
    $("a[name='btnEliminarPrograma']").click(function () {

        codigoPrograma = $(this).data("id");
        $('#modalVentanaEliminarPrograma').modal('show');
    });
    $("#btnAbrirDialogAgregarPrograma").click(function () {
        $('#modalAgregarPrograma').modal('show');
    });
    $("#btnAceptarEliminarProgramaConfirmacion").click(function () {

        $.ajax({
            url: '/Programa/EliminarPrograma',
            type: 'POST',
            data: {
                Codigo: codigoPrograma
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarPrograma').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarProgramaConfirmacion").click(function () {
        $('#modalVentanaEliminarPrograma').modal('hide');
        location.reload();
    });

    $("#textoBuscarPrograma").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ProgramasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});

function limpiarCampos() {
    $('#modalAgregarPrograma').modal('hide');

    document.getElementById("IDAgregarProgramaCodigo").value = "";
    document.getElementById("IDAgregarProgramaNombreCarrera").value = "";
    document.getElementById("IDAgregarProgramaModalidad").value = "";
    document.getElementById("IDAgregarProgramaIdioma").value = 
    document.getElementById("IDAgregarProgramaCantidadCuatrimestres").value = "";
    document.getElementById("IDAgregarProgramaCodigoDepartamento").value = "";

    $("IDAgregarProgramaNombreCarrera").css('border', '1px solid #ced4da');
    $("IDAgregarProgramaModalidad").css('border', '1px solid #ced4da');
    $("IDAgregarProgramaIdioma").css('border', '1px solid #ced4da');
    $("IDAgregarProgramaCantidadCuatrimestres").css('border', '1px solid #ced4da');
    $("IDAgregarProgramaCodigoDepartamento").css('border', '1px solid #ced4da');
}

function validarCamposPrograma() {
    var bandera = true;
    var agregarProgramaNombreCarrera = document.getElementById("IDAgregarProgramaNombreCarrera").value;
    var agregarProgramaModalidad = document.getElementById("IDAgregarProgramaModalidad").value;
    var agregarProgramaIdioma = document.getElementById("IDAgregarProgramaIdioma").value;
    var agregarProgramaCantidadCuatrimestres = document.getElementById("IDAgregarProgramaCantidadCuatrimestres").value;
    var agregarProgramaCodigoDepartamento = document.getElementById("IDAgregarProgramaCodigoDepartamento").value;

    if (agregarProgramaNombreCarrera == "") {
        $("#IDAgregarProgramaNombreCarrera").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProgramaNombreCarrera').css('border', '1px solid #ced4da');
    }

    if (agregarProgramaModalidad == "") {
        $("#IDagregarProgramaModalidad").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDagregarProgramaModalidad').css('border', '1px solid #ced4da');
    }

    if (agregarProgramaIdioma == "") {
        $("#IDagregarProgramaIdioma").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProgramaIdioma').css('border', '1px solid #ced4da');
    }

    if (agregarProgramaCantidadCuatrimestres == "") {
        $("#IDAgregarProgramaCantidadCuatrimestres").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProgramaCantidadCuatrimestres').css('border', '1px solid #ced4da');
    } 

    if (agregarProgramaCodigoDepartamento == "") {
        $("#IDAgregarProgramaCodigoDepartamento").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProgramaCodigoDepartamento').css('border', '1px solid #ced4da');
    }

    return bandera;

}
function VerDetallePrograma(codigo) {

    $.ajax({
        url: '/Programa/VerDetallePrograma',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarProgramaCodigoDepartamento").value = response.CodigoDepartamento;
            document.getElementById("IDAgregarProgramaCantidadCuatrimestres").value = response.CantidadCuatrimestres;
            document.getElementById("IDAgregarProgramaIdioma").value = response.Idioma;
            document.getElementById("IDagregarProgramaModalidad").value = response.Modalidad;
            document.getElementById("IDAgregarProgramaNombreCarrera").value = response.NombreCarrera;
            document.getElementById("IDAgregarProgramaCodigo").value = response.codigo;
            $('#modalAgregarPrograma').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}