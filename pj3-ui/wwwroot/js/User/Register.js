$("#btnRegister").on("click", function () {
    let dataUser = {};
    dataUser.UserName = document.getElementById("UserName").value;
    dataUser.Email = document.getElementById("Email").value;
    dataUser.PhoneNumber = document.getElementById("PhoneNumber").value;
    dataUser.Address = document.getElementById("Address").value;
    dataUser.Password = document.getElementById("Password").value;
    dataUser.ConfirmPassword = document.getElementById("ConfirmPassword").value;
    if (!checkValid(dataUser)) {
        Swal.fire({
            title: 'All field is required',
            showConfirmButton: true
        }).then((result) => {
            return;
        })
    }
    else {
        if (dataUser.Password == dataUser.ConfirmPassword) {
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
                    else if (result == -1) {
                        Swal.fire('Register fail, This email address is already used !')
                    }
                    else {
                        Swal.fire('Register fail, contact admin to fix!')
                    }

                }
            })
        }
        else {
            Swal.fire({
                title: 'Password and Confirm Password not match',
                showConfirmButton: true
            }).then((result) => {
                return;
            })
        }
        
    }
    
   
})
function checkValid(dataUser) {
    if (dataUser.UserName == "" || dataUser.Email == "" || dataUser.PhoneNumber == "" || dataUser.Address == "")
        return false;
    if (dataUser.UserName == undefined || dataUser.Email == undefined || dataUser.PhoneNumber == undefined || dataUser.Address == undefined)
        return false;
    return true
}