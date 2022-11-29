async function errorSendDispatch(){
    await Swal.fire({
        icon: 'error',
        iconColor: '#EB1D36',
        title: 'Oops...',
        text: 'Algo salio mal, si el problema perciste contactar el equipo de IT',
        showConfirmButton: false,
        timer: 2800

    })
    window.location.href = "home";
}




async function errorDriverh() {
    await Swal.fire({
        icon: 'error',
        iconColor: '#EB1D36',
        title: 'Oops...',
        text: 'Algo salio mal, si el problema perciste contactar el equipo de IT',
        showConfirmButton: false,
        timer: 2800

    })
    window.localStorage.clear();
    window.location.href = "/";
}


async function errorFirstRender() {
    await Swal.fire({
        icon: 'error',
        iconColor: '#EB1D36',
        title: 'Oops...',
        text: 'Algo salio mal, comprueba to conexion a internet,  si el problema perciste contactar el equipo de IT',
        showConfirmButton: false,
        timer: 2800
    })
    window.localStorage.clear();
    window.location.href = "/";
}


async function errorClientApi() {
    await Swal.fire({
        icon: 'error',
        iconColor: '#EB1D36',
        title: 'Oops...',
        text: 'Algo salio mal, comprueba to conexion a internet,  si el problema perciste contactar el equipo de IT',
        showConfirmButton: false,
        timer: 3500
    })
    window.localStorage.clear();
    window.location.href = "/";
    
}


//let code = "DPWL01944";
//async function test() {
//    await Swal.fire({
//        title: 'Do you want to save the changes?',
//        showDenyButton: true,
//        showCancelButton: true,
//        confirmButtonText: 'Save',
//        denyButtonText: `Don't save`,
//        html:
            
//            '<a href=`/generate-pdf/${code}`>PDF</a> ',
//    }).then((result) => {
//        /* Read more about isConfirmed, isDenied below */
//        if (result.isConfirmed) {
//            Swal.fire('Saved!', '', 'success', )
//        } else if (result.isDenied) {
//            Swal.fire('Changes are not saved', '', 'info')
//        }
//    })
//    window.location.href = `/generate-pdf/${code}`;
//}