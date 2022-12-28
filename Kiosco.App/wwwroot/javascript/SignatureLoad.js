//signature pad 
window.loadCanvas = () => {
    const form = document.querySelector(".signature-pad-form");
    const clearButton = document.querySelector('.clear-button');
    const canvas = document.querySelector("canvas");
    const ctx = canvas.getContext('2d');
    let writeingMode = false;
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        const imgURL = canvas.toDataURL();
        const image = document.createElement('img');
        image.src = imgURL;
        image.height = canvas.height;
        image.width = canvas.width;
        image.style.display = 'block';
        form.appendChild(image);
        clearPad();
        console.log(imgURL)
    });
    const clearPad = () => {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }
    clearButton.addEventListener('click', (e) => {
        e.preventDefault();
        clearPad();
    })
    const getTargetPosition = (event) => {
        positionX = event.clientX - event.target.getBoundingClientRect().x;
        positionY = event.clientY - event.target.getBoundingClientRect().y;
        return [positionX, positionY];
    }
    const handlePointerMove = (e) => {
        if (!writeingMode) return;
        const [positionX, positionY] = getTargetPosition(e);
        ctx.lineTo(positionX, positionY);
        ctx.stroke();
    }
    const handlePointerUp = () => {
        writeingMode = false;
    }
    const handlePointerDown = (e) => {
        writeingMode = true;
        ctx.beginPath();
        const [positionX, positionY] = getTargetPosition(e);
        ctx.moveTo(positionX, positionY);
    }
    ctx.lineWidth = 3;
    ctx.lineJoin = ctx.lineCap = 'round';
    canvas.addEventListener('pointerdown', handlePointerDown, { passive: true });
    canvas.addEventListener('pointerup', handlePointerUp, { passive: true });
    canvas.addEventListener('pointermove', handlePointerMove, { passive: true });
}