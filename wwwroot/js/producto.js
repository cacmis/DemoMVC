function showConfirmAcctionEdit(e,id) {
    e.preventDefault();
    //'Sure you want to delete the record?'
    Swal.fire({
        title: 'Estas seguro que quieres Editar el registro?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes'
    }).then((resultado) => {
        if (resultado.isConfirmed) {
            window.location.href = `/Producto/Edit/${id}`;
        }
    })
}

function showConfirmAcctionDelete(e, id) {
    e.preventDefault();
    //'Sure you want to delete the record?'
    Swal.fire({
        title: 'Estas seguro que quieres borrar el registro?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes'
    }).then((resultado) => {
        if (resultado.isConfirmed) {
            window.location.href = `/Producto/Delete/${id}`;
        }
    })
}






