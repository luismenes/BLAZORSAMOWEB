window.mostrarConfirmacion = (options) => {
    return Swal.fire({
        title: options.title,
        text: options.text,
        icon: options.icon,
        showCancelButton: options.showCancelButton,
        confirmButtonColor: options.confirmButtonColor,
        cancelButtonColor: options.cancelButtonColor,
        confirmButtonText: options.confirmButtonText
    }).then((result) => {
        return result.isConfirmed; // Devuelve un booleano en lugar de un objeto
    });
};
