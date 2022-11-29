function sendEmail() {
    Swal.fire({
        title: 'SUCCESS!',
        text:'PDF generado y enviado por correo',
        icon : 'success',
        showDenyButton: false,
        showCancelButton: false,
        confirmButtonText: 'Ok',
        denyButtonText: `Don't save`,
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = "home";
        } else if (result.isDenied) {
            window.location.href = "home";
        }
    })
}

function emailAlreadyExist(cuerpo) {
    Swal.fire({
        icon: 'warning',
        title: 'Oops...',
        text: 'Este PDF ya fue generado',
    })

    console.log(cuerpo);
}

