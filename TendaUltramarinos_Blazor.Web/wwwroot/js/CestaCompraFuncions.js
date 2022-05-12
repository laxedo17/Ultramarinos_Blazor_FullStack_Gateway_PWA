function ActualizarBotonCantidadeVisible(id, visible) {
    const actualizarCtdBoton = document.querySelector("button[datos-itemId='" + id + "']");

    if (visible == true) {
        actualizarCtdBoton.style.display = "inline-block";
    }
    else {
        actualizarCtdBoton.style.display = "none";
    }
}