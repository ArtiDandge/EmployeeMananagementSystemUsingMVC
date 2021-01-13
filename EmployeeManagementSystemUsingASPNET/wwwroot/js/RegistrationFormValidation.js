
function validate() {

    var nameRegex = /^[A-Z]{1}[a-zA-Z]{2,}/;
    var emailRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var mobileRegex = /^(?:(?:\+|0{0,2})91(\s*|[\-])?|[0]?)?([6789]\d{2}([ -]?)\d{3}([ -]?)\d{4})$/
    var passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;

    if (!nameRegex.test(document.registrationForm.firstName.value)) {
        alert("Please provide your valid  first name! Name should have atleast 3 characters");
        document.registrationForm.firstName.focus();
        return false;
    }
    if (!nameRegex.test(document.registrationForm.lastName.value)) {
        alert("Please provide your valid  last name! Name should have atleast 3 characters");
        document.registrationForm.lastName.focus();
        return false;
    }
    if (document.registrationForm.address.value == "") {
        alert("Please provide your valid  City!");
        return false;
    }
    if (document.registrationForm.city.value == "") {
        alert("Please provide your valid  City!");
        return false;
    }
    if (document.registrationForm.state.value == "") {
        alert("Please provide your valid  State!");
        return false;
    }
    if (document.registrationForm.zip.value == "" ||
        isNaN(document.registrationForm.zip.value) ||
        document.registrationForm.zip.value.length != 6) {
        alert("Please provide a valid zip");
        document.registrationForm.zip.focus();
        return false;
    }
    if (!mobileRegex.test(document.registrationForm.phoneNumber.value)) {
        alert("Please provide a phone Number in the format of 10 digit mobile number. ");
        document.registrationForm.phoneNumber.focus();
        return false;
    }
    if (!emailRegex.test(document.registrationForm.email.value)) {
        alert("Please provide valid Email!");
        document.registrationForm.email.focus();
        return false;
    }
    if (!passwordRegex.test(document.registrationForm.password.value)) {
        alert("Please provide valid password in given format");
        document.registrationForm.password.focus();
        return false;
    }

    alert("Registration Successfull !");
    window.location.href = "https://localhost:44358/HTML/Login.html";
    return true;
}

var check = function () {
    if (document.getElementById('password').value ==
        document.getElementById('Confirmpassword').value) {
        document.getElementById('message').style.color = 'green';
        document.getElementById('message').innerHTML = 'matching';
    } else {
        document.getElementById('message').style.color = 'red';
        document.getElementById('message').innerHTML = 'not matching';
    }
}

