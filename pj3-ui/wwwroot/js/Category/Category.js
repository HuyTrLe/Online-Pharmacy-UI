$(#btnCategoryById).on("click", function () {
    let Name = document.getCategoryById("Name").value;
    var formData = new FormData();
    formData.append("Name", email);
    $.ajax({
        type: "POST",
        url: "/Home/Product",
        data: formData,
        dataType: 'json',
        processData: false,
        contentType: false,
        //success: function (result) {
        //    if (result != null && result.id > 0) {
        //        Swal.fire({
        //            icon: 'sucess!',
        //            title: 'Login Success!',
        //            showConfirmButton: true
        //        }).then((result) => {
        //            window.location = "/Home/Index";
        //        })

        //    }
        //    else {
        //        Swal.fire('Email or Password is incorrect')
        //    }

        //}
    })
})