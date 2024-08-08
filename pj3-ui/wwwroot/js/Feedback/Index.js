$("#btnSubmit").on("click", function () {
    let email = document.getElementById("Email").value;
    let fullName = document.getElementById("FullName").value;
    let companyName = document.getElementById("CompanyName").value;
    let phoneNumber = document.getElementById("PhoneNumber").value;
    let subject = document.getElementById("Subject").value;
    let comment = document.getElementById("Comment").value;

    if (!validData()) {
        return; // If validation fails, exit without submitting the form
    }
    var formData = new FormData();
    formData.append("Email", email);
    formData.append("FullName", fullName);
    formData.append("CompanyName", companyName);
    formData.append("PhoneNumber", phoneNumber);
    formData.append("Subject", subject);
    formData.append("Comment", comment);

    $.ajax({
        type: "POST",
        url: "/Feedback/InsertFeedback",
        data: formData,
        dataType: 'json',
        processData: false, 
        contentType: false,
        success: function (result) {
            if (result > 0) {
                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Thanks for your feedback, we will contact you if it necessary!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = '/';
                    }
                });             
            }
        }
    })
})
function validData() {
    let email = document.getElementById("Email");
    let fullName = document.getElementById("FullName");
    let companyName = document.getElementById("CompanyName");
    let phoneNumber = document.getElementById("PhoneNumber");
    let subject = document.getElementById("Subject");
    let comment = document.getElementById("Comment");

    let emailVal = email.value;
    let fullNameVal = fullName.value;
    let companyNameVal = companyName.value;
    let phoneNumberVal = phoneNumber.value;
    let subjectVal = subject.value;
    let commentVal = comment.value;
    var valid = true;


    if (fullNameVal == '') {
        setError(fullName, 'Name is required');
        valid = false;
    } else if (!/^[a-zA-Z\s]+$/.test(fullNameVal)) {
        setError(fullName, 'Name must be only characters');
        valid = false;
    } else if (fullNameVal.length > 50) {
        setError(fullName, 'Max 50 characters');
        valid = false;
    } else {
        setDefault(fullName);
    }

    if (companyNameVal == '') {
        setError(companyName, 'Company Name is required');
        valid = false;
    } else if (!/^[a-zA-Z\s]+$/.test(companyNameVal)) {
        setError(companyName, 'Company Name must be only characters');
        valid = false;
    } else if (companyNameVal.length > 50) {
        setError(companyName, 'Max 50 characters');
        valid = false;
    } else {
        setDefault(companyName);
    }

    if (emailVal == '') {
        setError(email, 'Email is required');
        valid = false;
    } else if (!isValidEmail(emailVal)) {
        setError(email, 'Provide a valid email address');
        valid = false;
    } else if (emailVal.length > 150) {
        setError(email, 'Max 150 characters');
        valid = false;
    } else {
        setDefault(email);
    }

    if (phoneNumberVal == '') {
        setError(phoneNumber, 'Phone is required');
        valid = false;
    } else if (!isValidNumber(phoneNumberVal)) {
        setError(phoneNumber, 'Please enter valid phone number which is max 13 and min 10 digits include 0 at start');
        valid = false;
    } else {
        setDefault(phoneNumber);
    }

    if (subjectVal == '') {
        setError(subject, 'Subject is required');
        valid = false;
    } else if (subjectVal.length > 200) {
        setError(subject, 'Max 200 characters');
        valid = false;
    } else {
        setDefault(subject);
    }

    if (commentVal == '') {
        setError(comment, 'Message is required');
        valid = false;
    } else if (commentVal.length > 500) {
        setError(comment, 'Message max 500 characters');
        valid = false;
    } else {
        setDefault(comment);
    }

    return valid;
}
function setError(element, message) {
    var inputControl = element.parentElement;
    var errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = message;
    inputControl.classList.add('error');
    inputControl.classList.remove('success')
}

function setDefault(element) {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = '';
    inputControl.classList.remove('error');
};

function isValidEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

//Valid number will match phone numbers that start with 0, have between 9 and 12 digits, and do not contain any digit that repeats more than 8 times in a row. 
function isValidNumber(number) {
    const pattern = /^0(?!.*(\d)\1{8})\d{9,12}$/;
    return pattern.test(number);
}