$("#btnSubmit").on("click", function () {
    let name = document.getElementById("name").value;
    let unit = document.getElementById("unit").value;

    if (!name || name.trim() === "") {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Name cannot be blank, empty, or null.'
        });
        return; // Exit the function if the name is invalid
    }

    if (unit.trim() === "") {
        unit = 'none';
    }
    var formData = new FormData();
    formData.append("Name", name);
    formData.append("Unit", unit);

    $.ajax({
        type: "POST",
        url: "/Specification/InsertSpecification",
        data: formData,
        dataType: 'json',
        processData: false,
        contentType: false,
        success: function (result) {
            if (result > 0) {
                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Create success!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = '/Specification/IndexAdmin';
                    }
                });
            } else {
                // Handle the error or show an error message.
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Create fail'
                });
            }
        }
    });
});
