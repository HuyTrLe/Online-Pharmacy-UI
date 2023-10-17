$("#btnRegister").on("click", function () {
    let dataUser = {};
    dataUser.Username = document.getElementById("Username").value;
    dataUser.Email = document.getElementById("Email").value;
    dataUser.PhoneNumber = document.getElementById("PhoneNumber").value;
    dataUser.Address = document.getElementById("Address").value;
    dataUser.Password = document.getElementById("Password").value;
    dataUser.RetypePassword = document.getElementById("RetypePassword").value;
    let param = {
        user: dataUser
    }
    $.ajax({
        type: "POST",
        url: "/User/InsertUser",
        data: param,
        dataType: 'json',
        success: function (result) {
            if (result > 0) {
                Swal.fire({
                    icon: 'sucess!',
                    title: 'Insert Success!',
                    showConfirmButton: true
                }).then((result) => {
                    window.location = "/Home/Index";
                })

            }
            else {
                Swal.fire('Register fail, contact admin to fix!')
            }

        }
    })
   
})