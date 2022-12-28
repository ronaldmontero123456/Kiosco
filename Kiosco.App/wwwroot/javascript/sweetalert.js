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

function alertErrorForResumenHorasExtras() {
    Swal.fire(
        'Resumen Horas Extras',
        'Su perfil no posee Resumen Horas Extras.',
        'question'
    )
}
function alertErrorForCartas() {
    Swal.fire(
        'Carta Consular Invalida',
        'Para continuar debe seleccionar la embajada.',
        'question'
    )
}
function alertErrorForVacantesInternas() {
    Swal.fire(
        'Error enviando vacante',
        'Por favor intentar mas tarde.',
        'question'
    )
}
async function alertForVacantesInternas() {
    await Swal.fire(
        'Exito enviando vacante',
        'Se envió de forma correcta la vacante al supervisor.',
        'question'
    )
}

async function alertForValidLogout(formvalidate) {

    await Swal.fire({
        title: 'Estas Seguro?',
        text: "Se procedera a cerrar sesion!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar'
    }).then((result) => {
        formvalidate = result.isConfirmed;
    })

    return formvalidate;
}

async function alertForVacantesInternasAdding() {
    await Swal.fire(
        'Error Agregando Vacante',
        'Usted ya aplico para esta vacante.',
        'question'
    )
}

//function alertForValidLogout(time) {
//    let timerInterval
//Swal.fire({
//    title: 'Auto close alert!',
//    html: 'I will close in <b></b> milliseconds.',
//    timer: time,
//    timerProgressBar: true,
//    didOpen: () => {
//        Swal.showLoading()
//        const b = Swal.getHtmlContainer().querySelector('b')
//        timerInterval = setInterval(() => {
//            b.textContent = Swal.getTimerLeft()
//        }, 100)
//    },
//    willClose: () => {
//        clearInterval(timerInterval)
//    }
//}).then((result) => {
//    /* Read more about handling dismissals below */
//    if (result.dismiss === Swal.DismissReason.timer) {
//        console.log('I was closed by the timer')
//    }
//})
//}

//let timerInterval
//Swal.fire({
//    title: 'Auto close alert!',
//    html: 'I will close in <b></b> milliseconds.',
//    timer: 2000,
//    timerProgressBar: true,
//    didOpen: () => {
//        Swal.showLoading()
//        const b = Swal.getHtmlContainer().querySelector('b')
//        timerInterval = setInterval(() => {
//            b.textContent = Swal.getTimerLeft()
//        }, 100)
//    },
//    willClose: () => {
//        clearInterval(timerInterval)
//    }
//}).then((result) => {
//    /* Read more about handling dismissals below */
//    if (result.dismiss === Swal.DismissReason.timer) {
//        console.log('I was closed by the timer')
//    }
//})