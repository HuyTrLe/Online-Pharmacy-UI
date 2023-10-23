$("#btnlogin").on("click", function () {
    let email = document.getElementById("Email").value;
    let password = document.getElementById("Password").value;
    var formData = new FormData();
    formData.append("Email", email);
    formData.append("Password", password);
    $.ajax({
        type: "POST",
        url: "/Home/Login",
        data: formData,
        dataType: 'json',
        processData: false, 
        contentType: false,
        success: function (result) {
            if (result != null && result.id > 0) {
                Swal.fire({
                    icon: 'success',
                    title: 'Login Success!',
                    showConfirmButton: false,
                    timer: 2000
                }).then((result) => {
                    window.location = "/Home/Index";
                })    
            }
            else {
                Swal.fire('Email or Password is incorrect')
            }

        },
       
    })
})