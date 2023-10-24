$(document).ready(function () {
    $(document).on("click", ".btnSubmit", function () {
        // Get the specId from the data attribute of the clicked button
        var specId = $(this).data("spec-id");
        var modal = $("#detailModal_" + specId);
        var productID = modal.find("#ProductID_" + specId).val();

        var formData = new FormData();
        formData.append("ID", specId);
        formData.append("ProductID", productID);
        var imageInput = document.getElementById("productImage_" + specId);

        if (imageInput.files.length > 0) {
            formData.append("productImages", imageInput.files[0]);
        }

        $.ajax({
            type: "POST",
            url: "/ProductImage/Update", // Modify the URL to match your controller action
            data: formData,
            dataType: 'json',
            processData: false,
            contentType: false,
            success: function (result) {
                if (result > 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Success',
                        text: 'Update success!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = '/ProductImage/IndexAdmin';
                        }
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Update failed'
                    });
                }   
            }
        });
        error: function error(xhr, status, error) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: error
            });
        }
    });
});