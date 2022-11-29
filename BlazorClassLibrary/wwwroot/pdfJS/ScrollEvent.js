
window.getscroll = () => {
    window.addEventListener("scroll", () => {
        let btnPDFShow = document.querySelector(".btn-pdf-show");
        btnPDFShow.classList.toggle("sticky", window.scrollY > 200);
        //btnPDFShow.classList.remove("hideNoScroll", window.scrollY > 200);
        //btnPDFShow.classList.toggle("hideNoScroll", window.scrollY < 200);

    });
}

