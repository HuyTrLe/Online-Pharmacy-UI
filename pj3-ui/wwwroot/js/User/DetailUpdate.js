var listDelete = [];
var listIndex = [];
$(document).ready(function () {
    
    document.getElementById("chooseFileButton").addEventListener("click", function () {
        document.getElementById("fileInput").click();
    });

    document.getElementById("fileInput").addEventListener("change", function () {
        const pdfViewer = document.getElementById("pdfViewer");
        const fileInput = document.getElementById("fileInput");

        if (fileInput.files && fileInput.files[0]) {
            const pdfFile = fileInput.files[0];
            const fileURL = URL.createObjectURL(pdfFile);

            pdfViewer.src = fileURL;
        }

    });

    function SaveUploadFile() {
        const fileInput = document.getElementById("fileInput");
        var pdfFile = fileInput.files[0];
        var pdf = new FormData();
        pdf.append("PdfFile", pdfFile);
        $.ajax({
            type: "POST",
            url: "/User/UploadFile",
            data: pdf,
            dataType: 'json',
            processData: false,
            contentType: false,
            success: function () {
               
            }
        })

    }
   
    $("#btnAddEducation").on("click", function () {
        let index = GetIndexHighestInsert();
        var newIndex = index; // Lấy số lượng phần tử đã có trong "Edu."
        newIndex++;
        var newEducationHTML = `
            <div class="borderDetail row mt-3 school_${newIndex}">
               <input type="text" class="form-control" id="ID" value="@item.ID" hidden>
                <div class="col-md-6"><label class="labels">School Name</label><input type="text" class="form-control" id="SchoolName" value=""></div>
                <div class="col-md-3"><label class="labels">Type</label>
                  <div>
                                            <select class="form-control" id="SchoolType">
                                                <option value="College " selected>College</option>
                                                <option value="University ">University</option>
                                                <option value="Master">Master</option>
                                            </select>
                                        </div>
                </div>
                <div class="col-md-3"><label class="labels">Degree</label> <div>
                                            <select class="form-control" id="Degree" >
                                                <option value="Associate" selected>Associate</option>
                                                <option value="Bachelor">Bachelor</option>
                                                <option value="Master">Master</option>
                                                <option value="Doctoral">Doctoral</option>
                                            </select>
                                        </div>
                </div>
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

        for (var i = 0; i < listIndex.length; i++) {
            let valuesEdu = {};
            var schoolElement = document.querySelector(".school_" + listIndex[i]);
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
        if (validateEducation(ListEducation, index)) {

            if (validateUser) {
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
                        if (result > 0) {
                            SaveUploadFile();
                            DeleteEducation();
                            Swal.fire({
                                icon: 'sucess!',
                                title: 'Update Success!',
                                showConfirmButton: true
                            }).then((result) => {
                                window.location = "/Home/Index";
                            })

                        }
                        else {
                            Swal.fire('Update fail')
                        }

                    }
                })
            }
            else {
                Swal.fire({
                    title: 'Please fill all field User',
                    showConfirmButton: true
                }).then(() => {
                    return;
                })
            }
            
        }
        else {
            Swal.fire({
                title: 'Please fill all field Education',
                showConfirmButton: true
            }).then(() => {
                return;
            })
        }
        
    });
});
$(".btnDelete").on("click", function () {
    var ID = $(this).data("id");
    var index = $(this).data("index");
    $(".school_" + index).remove();
    listDelete.push(ID);
})
function DeleteEducation() {
    if (listDelete.length > 0) {           
        $.ajax({
            type: "POST",
            url: "/User/DeleteEducation",
            data: { id: listDelete },
            dataType: 'json'
        })
    }

}
function validateEducation(ListEducation, index) {
    for (var i = 0; i < index; i++) {
        if (ListEducation[i].SchoolName == "" || ListEducation[i].SchoolType == "" || ListEducation[i].Degree == "" || ListEducation[i].From == "" || ListEducation[i].To == "")
            return false;
        if (ListEducation[i].SchoolName == undefined || ListEducation[i].SchoolType == undefined || ListEducation[i].Degree == undefined || ListEducation[i].From == undefined || ListEducation[i].To == undefined)
            return false;
    }
    return true;

}
function validateUser(UserName, Email, PhoneNumber, Address) {
    if (UserName == "" || Email == "" || PhoneNumber == "" || Address == "" )
        return false;
    if (UserName == undefined || Email == undefined || PhoneNumber == undefined || Address == undefined )
        return false;

    return true;

}
function GetIndexHighest() {

    var highestIndex = 0;
    $("[class^='borderDetail row mt-3 school_']").each(function () {
        var classList = this.className.split(" ");
        for (var i = 0; i < classList.length; i++) {
            if (classList[i].startsWith("school_")) {
                // Lấy chỉ số từ class và so sánh với chỉ số cao nhất.
                var index = parseInt(classList[i].substring(7));
                listIndex.push(index);
                highestIndex++;
            }
        }
    });
    return highestIndex;
}
function GetIndexHighestInsert() {

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