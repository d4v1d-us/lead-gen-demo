function ShortDataValidation(theForm) {

    if (theForm.agree.checked != 1) {
        alert("You must agree to all Terms and Conditions.");
        theForm.agree.focus();
        return (false);
    }

    if (theForm.first_name.value == "") {
        alert("Please enter your First Name.");
        theForm.first_name.focus();
        return (false);
    }

    var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- \t\r\n\f";
    var checkStr = theForm.first_name.value;
    var allValid = true;
    var validGroups = true;
    var decPoints = 0;
    var allNum = "";
    for (i = 0; i < checkStr.length; i++) {
        ch = checkStr.charAt(i);
        for (j = 0; j < checkOK.length; j++)
            if (ch == checkOK.charAt(j))
            break;
        if (j == checkOK.length) {
            allValid = false;
            break;
        }
        allNum += ch;
    }
    if (!allValid) {
        alert("Please enter only letters in the First Name field.");
        theForm.first_name.focus();
        return (false);
    }

    if (theForm.last_name.value == "") {
        alert("Please enter your Last Name.");
        theForm.last_name.focus();
        return (false);
    }

    var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- \t\r\n\f";
    var checkStr = theForm.last_name.value;
    var allValid = true;
    var validGroups = true;
    var decPoints = 0;
    var allNum = "";
    for (i = 0; i < checkStr.length; i++) {
        ch = checkStr.charAt(i);
        for (j = 0; j < checkOK.length; j++)
            if (ch == checkOK.charAt(j))
            break;
        if (j == checkOK.length) {
            allValid = false;
            break;
        }
        allNum += ch;
    }
    if (!allValid) {
        alert("Please enter only letters in the Last Name field.");
        theForm.last_name.focus();
        return (false);
    }

    if (theForm.Email.value == "") {
        alert("Please enter your Email Address.");
        theForm.Email.focus();
        return (false);
    }

    var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-@-._";
    var checkStr = theForm.Email.value;
    var allValid = true;
    var validGroups = true;
    for (i = 0; i < checkStr.length; i++) {
        ch = checkStr.charAt(i);
        for (j = 0; j < checkOK.length; j++)
            if (ch == checkOK.charAt(j))
            break;
        if (j == checkOK.length) {
            allValid = false;
            break;
        }
    }
    if (!allValid) {
        alert("Please enter a valid Email Address.");
        theForm.Email.focus();
        return (false);
    }

    var checkStr = theForm.Email.value;
    if (checkStr.indexOf('@') == -1) {
        alert("Please enter a valid Email Address.");
        theForm.Email.focus();
        return (false);
    }

    var checkStr = theForm.Email.value;
    if (checkStr.indexOf('.') == -1) {
        alert("Please enter a valid Email Address.");
        theForm.Email.focus();
        return (false);
    }

//    if (theForm.state.selectedIndex == 0) {
//        alert("Please select your State.");
//        theForm.state.focus();
//        return (false);
//    }

    if (theForm.Zip.value == "") {
        alert("Please enter your Zip Code.");
        theForm.Zip.focus();
        return (false);
    }

    if (theForm.Zip.value.length < 5) {
        alert("Please enter 5 digits in the Zip Code field.");
        theForm.Zip.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.Zip.value;
    var allValid = true;
    var validGroups = true;
    var decPoints = 0;
    var allNum = "";
    for (i = 0; i < checkStr.length; i++) {
        ch = checkStr.charAt(i);
        for (j = 0; j < checkOK.length; j++)
            if (ch == checkOK.charAt(j))
            break;
        if (j == checkOK.length) {
            allValid = false;
            break;
        }
        allNum += ch;
    }
    if (!allValid) {
        alert("Please enter only digits in the Zip Code field.");
        theForm.Zip.focus();
        return (false);
    }
    
    return (true);
}