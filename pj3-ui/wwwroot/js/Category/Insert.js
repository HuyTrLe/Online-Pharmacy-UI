$("#btnSubmit").on("click", function () {
    let nameElement = document.getElementById("name");
    let name = nameElement.value.trim();

    if (!name || name.trim() === "") {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Name cannot be blank, empty, or null.'
        });
        return; // Exit the function if the name is invalid
    }

   
    let categoryModel = {};
    categoryModel.Name = name;

    let nameArr = { spec: categoryModel };
    // Check for uniqueness using AJAX
    $.ajax({
        type: "POST",
        url: "/Specification/CheckUniqueByName",
        data: nameArr,
        dataType: 'json',
        success: function (result) {
            if (result == -1) {
                // The name is not unique, show an error message
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Name is already in use.'
                });
            } else {
                // The name is unique, proceed with creating the specification
                var formData = new FormData();
                formData.append("Name", nameElement.value); // Change this line

                $.ajax({
                    type: "POST",
                    url: "/Category/InsertCategory",
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
                                    window.location.href = '/Category/IndexAdmin';
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
            }
        }
    });
});
