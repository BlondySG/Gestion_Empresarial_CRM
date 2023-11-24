// confirmarEliminar.js

function enviarFormulario(e) {
    e.preventDefault();
    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonColor: '#0EA01C',
        confirmButtonText: '¡Sí, bórralo!'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                '¡Eliminado!',
                'Su archivo ha sido eliminado.',
                'success'
            );
            // Espera 2 segundos
            window.setTimeout(() => {
                const formulario = document.getElementById('formulario');
                formulario.submit();
            }, 2000);
        }
    });
}