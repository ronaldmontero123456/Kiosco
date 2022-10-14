function alradyDelete(message) {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: `${message}`,
    })
}

function deleted(expediente) {
    Swal.fire({
        icon: 'success',
        title: 'DELETED!',
        text: `Expedient ${expediente} Eliminado.`
    })
}