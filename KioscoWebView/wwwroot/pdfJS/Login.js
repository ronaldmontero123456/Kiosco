
window.login = (userName, Password, loged) => {
    const errorInput = document.querySelector(".error-input");
    

    if (loged) {

        Swal.fire({

            icon: 'success',
            color: '#000',
            iconColor: '#001E6C', 
            title: 'Welcome!',
            text: `${userName}`,
            showConfirmButton: false,
            timer: 1800
        })
        window.location.href = "home";
    } else if (!loged) {

        errorInput.innerHTML = "Usuario no autorizado";
        userName = "";
        return
    }

}