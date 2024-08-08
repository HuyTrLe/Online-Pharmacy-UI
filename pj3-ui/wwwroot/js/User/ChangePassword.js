$("#btnChange").on("click", function () {
    let oldPass = document.getElementById("OldPassword").value;
    let newPass = document.getElementById("Password").value;
    let ConfirmPassword = document.getElementById("ConfirmPassword").value;
    if (newPass == ConfirmPassword) {
        let PassValue = { Password: oldPass };
        $.ajax({
            type: "POST",
            url: "/User/CheckPassword",
            data: PassValue,
            dataType: 'json',

            success: function (result) {
                if (result > 0) {
                    let newPassValue = { Password: newPass };
                    $.ajax({
                        type: "POST",
                        url: "/User/UpdatePassword",
                        data: newPassValue,
                        dataType: 'json',

                        success: function (result) {
                            if (result > 0) {
                                Swal.fire({
                                    icon: 'sucess!',
                                    title: 'Update Success!',
                                    showConfirmButton: true
                                }).then((result) => {
                                    window.location = "/Home/Index";
                                })

                            }
                            else {
                                Swal.fire('Old Pass is not correct')
                            }

                        }
                    })

                }
                else {
                    Swal.fire('Old Pass is not correct')
                }

            }
        })
    }
    else {
        Swal.fire({
            title: 'Password and confirm password not match!',
            showConfirmButton: true
        }).then(() => {
            return;
        })
    }
    
})