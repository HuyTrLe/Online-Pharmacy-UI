$(document).ready(function () {

    $("#btnAddEducation").on("click", function () {
        let index = GetIndexHighest();
        var newIndex = index; // Lấy số lượng phần tử đã có trong "Edu."
        newIndex++;
        var newEducationHTML = `
            <div class="borderDetail row mt-3 school_${newIndex}">
               <input type="text" class="form-control" id="ID" value="@item.ID" hidden>
                <div class="col-md-6"><label class="labels">School Name</label><input type="text" class="form-control" id="SchoolName" value=""></div>
                <div class="col-md-3"><label class="labels">Type</label><input type="text" class="form-control" id="SchoolType" value=""></div>
                <div class="col-md-3"><label class="labels">Degree</label><input type="text" class="form-control" id="Degree" value=""></div>
                <div class="col-md-6"><label class="labels">From</label><input type="date" class="form-control" id="From" value=""></div>
                <div class="col-md-6"><label class="labels">To</label><input type="date" class="form-control" id="To" value=""></div>
            </div>
        `;

        // Append đoạn mã HTML mới vào phần tử "Edu."
        $("#Edu").append(newEducationHTML);
    });
    $("#btnSaveProfile").on("click", function () {
        //Education
        let index = GetIndexHighest();
        var ListEducation = [];
       
        for (var i = 0; i <= index; i++) {
            let valuesEdu = {};
            var schoolElement = document.querySelector(".school_" + i);
            valuesEdu.ID = schoolElement.querySelector("input#ID").value;
            valuesEdu.SchoolName = schoolElement.querySelector("input#SchoolName").value;
            valuesEdu.SchoolType = schoolElement.querySelector("input#SchoolType").value;
            valuesEdu.Degree = schoolElement.querySelector("input#Degree").value;
            valuesEdu.From = schoolElement.querySelector("input#From").value;
            valuesEdu.To = schoolElement.querySelector("input#To").value;
            ListEducation.push(valuesEdu);
        }
        //
        let valueUser = {};
        valueUser.ID = document.getElementById("ID").value;
        valueUser.UserName = document.getElementById("UserName").value;
        valueUser.Email = document.getElementById("Email").value;
        valueUser.PhoneNumber = document.getElementById("PhoneNumber").value;
        valueUser.Address = document.getElementById("Address").value;
        let param = {
            UserModel: valueUser,
            Education: ListEducation
        }
        //User Infor
        $.ajax({
            type: "POST",
            url: "/User/UpdateUser",
            data: param,
            dataType: 'json',
            success: function (result) {
                if (result != null && result.id > 0) {
                    Swal.fire({
                        icon: 'sucess!',
                        title: 'Login Success!',
                        showConfirmButton: true
                    }).then((result) => {
                        window.location = "/Home/Index";
                    })

                }
                else {
                    Swal.fire('Email or Password is incorrect')
                }

            }
        })


        
    });
});

function GetIndexHighest() {

    var highestIndex = -1;
    $("[class^='borderDetail row mt-3 school_']").each(function () {
        var classList = this.className.split(" ");
        for (var i = 0; i < classList.length; i++) {
            if (classList[i].startsWith("school_")) {
                // Lấy chỉ số từ class và so sánh với chỉ số cao nhất.
                var index = parseInt(classList[i].substring(7));
                if (index > highestIndex) {
                    highestIndex = index;
                }
            }
        }
    });
    return highestIndex;
}