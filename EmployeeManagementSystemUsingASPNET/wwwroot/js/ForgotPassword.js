function ForgotPasswordValidation() {

    var emailRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var mobileRegex = /^(?:(?:\+|0{0,2})91(\s*|[\-])?|[0]?)?([6789]\d{2}([ -]?)\d{3}([ -]?)\d{4})$/
    if (!emailRegex.test(document.ForgotPassword.email.value)) {
        alert("Please provide valid Email!");
        document.ForgotPassword.email.focus();
        return false;
    }
    if (!mobileRegex.test(document.ForgotPassword.mobileNumber.value)) {
        alert("Please provide a phone Number in the format of 10 digit mobile number. ");
        document.ForgotPassword.mobileNumber.focus();
        return false;
    }
    return (true);
}
