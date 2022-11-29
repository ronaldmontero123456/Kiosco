function alertError() {
    Swal.fire(
        'Cardnet Code Invalido',
        'Por favor insertar un cardnet code invalido',
        'question'
    )
}
function alertErrorForCertificaciones() {
    Swal.fire(
        'Cerficicacion Invalida',
        'Su perfil no posee certificaciones aún.',
        'question'
    )
}
function alertErrorForVolantesPagos() {
    Swal.fire(
        'Volante De Pago Invalido',
        'Su perfil no posee Volante De Pago aún.',
        'question'
    )
}