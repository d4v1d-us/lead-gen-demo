function FullDataValidation(theForm) {

    if (theForm.accepted_terms.selectedIndex == 0) {
        alert("You must read, understand and agree to the" + '\t\n\t' + "Terms and Conditions" + '\t\n\t' + "Privacy Policy" + '\t\n\t');
        theForm.accepted_terms.focus();
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

    if (theForm.street_addr1.value == "") {
        alert("Please enter your Street Address.");
        theForm.street_addr1.focus();
        return (false);
    }

    if (theForm.city.value == "") {
        alert("Please enter your City.");
        theForm.city.focus();
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

//    if (theForm.months_at_address.value == "") {
//        alert("Please enter your Months at Address.");
//        theForm.months_at_address.focus();
//        return (false);
//    }

//    var checkOK = "0123456789";
//    var checkStr = theForm.months_at_address.value;
//    var allValid = true;
//    var validGroups = true;
//    var decPoints = 0;
//    var allNum = "";
//    for (i = 0; i < checkStr.length; i++) {
//        ch = checkStr.charAt(i);
//        for (j = 0; j < checkOK.length; j++)
//            if (ch == checkOK.charAt(j))
//            break;
//        if (j == checkOK.length) {
//            allValid = false;
//            break;
//        }
//        allNum += ch;
//    }
//    if (!allValid) {
//        alert("Please enter only digits in the Months at Address field.");
//        theForm.months_at_address.focus();
//        return (false);
//    }
    
    
    
    
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

    if (theForm.email_alternate.value != "") {

        var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-@-._";
        var checkStr = theForm.email_alternate.value;
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
            alert("Please enter a valid Alternate Email Address.");
            theForm.email_alternate.focus();
            return (false);
        }

        var checkStr = theForm.email_alternate.value;
        if (checkStr.indexOf('@') == -1) {
            alert("Please enter a valid Alternate Email Address.");
            theForm.email_alternate.focus();
            return (false);
        }

        var checkStr = theForm.email_alternate.value;
        if (checkStr.indexOf('.') == -1) {
            alert("Please enter a valid Alternate Email Address.");
            theForm.email_alternate.focus();
            return (false);
        }

    }

    //Cell Best Phone 
    if (theForm.phone_cell1.value == "") {
        alert("Please enter your Cell/Best Phone #");
        theForm.phone_cell1.focus();
        return (false);
    }

    if (theForm.phone_cell1.value.length < 3) {
        alert("Please enter 3 digits in the Cell/Best Phone # field.");
        theForm.phone_cell1.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_cell1.value;
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
        alert("Please enter only digits in the Cell/Best Phone # field.");
        theForm.phone_cell1.focus();
        return (false);
    }

    if (theForm.phone_cell2.value == "") {
        alert("Please enter your Cell/Best Phone #");
        theForm.phone_cell2.focus();
        return (false);
    }

    if (theForm.phone_cell2.value.length < 3) {
        alert("Please enter 3 digits in the Cell/Best Phone # field.");
        theForm.phone_cell2.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_cell2.value;
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
        alert("Please enter only digits in the Cell/Best Phone # field.");
        theForm.phone_cell2.focus();
        return (false);
    }

    if (theForm.phone_cell3.value == "") {
        alert("Please enter your Cell/Best Phone #");
        theForm.phone_cell3.focus();
        return (false);
    }

    if (theForm.phone_cell3.value.length < 4) {
        alert("Please enter 4 digits in the Cell/Best Phone # field.");
        theForm.phone_cell3.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_cell3.value;
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
        alert("Please enter only digits in the Cell/Best Phone # field.");
        theForm.phone_cell3.focus();
        return (false);
    }


    //Home Alternate Phone

    if (theForm.phone_home1.value == "") {
        alert("Please enter your Home/Alternate Phone #");
        theForm.phone_home1.focus();
        return (false);
    }

    if (theForm.phone_home1.value.length < 3) {
        alert("Please enter 3 digits in the Home/Alternate Phone # field.");
        theForm.phone_home1.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_home1.value;
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
        alert("Please enter only digits in the Home/Alternate Phone # field.");
        theForm.phone_home1.focus();
        return (false);
    }

    if (theForm.phone_home2.value == "") {
        alert("Please enter your Home/Alternate Phone #");
        theForm.phone_home2.focus();
        return (false);
    }

    if (theForm.phone_home2.value.length < 3) {
        alert("Please enter 3 digits in the Home/Alternate Phone # field.");
        theForm.phone_home2.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_home2.value;
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
        alert("Please enter only digits in the Home/Alternate Phone # field.");
        theForm.phone_home2.focus();
        return (false);
    }
    
    if (theForm.phone_home3.value == "") {
        alert("Please enter your Home/Alternate Phone #");
        theForm.phone_home3.focus();
        return (false);
    }

    if (theForm.phone_home3.value.length < 4) {
        alert("Please enter 4 digits in the Home/Alternate Phone # field.");
        theForm.phone_home3.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_home3.value;
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
        alert("Please enter only digits in the Home/Alternate Phone # field.");
        theForm.phone_home3.focus();
        return (false);
    }
    
    
    
    
    if (theForm.birth_dateM.selectedIndex == 0) {
        alert("Please select your Birthdate.");
        theForm.birth_dateM.focus();
        return (false);
    }

    if (theForm.birth_dateD.selectedIndex == 0) {
        alert("Please select your Birthdate.");
        theForm.birth_dateD.focus();
        return (false);
    }

    if (theForm.birth_dateY.value == "") {
        alert("Please enter your Birthdate.");
        theForm.birth_dateY.focus();
        return (false);
    }

    if (theForm.birth_dateY.value.length < 4) {
        alert("Please enter 4 digits in the Birthdate field.");
        theForm.birth_dateY.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.birth_dateY.value;
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
        alert("Please enter only digits in the Birthdate field.");
        theForm.birth_dateY.focus();
        return (false);
    }

    if (theForm.ref_01_name_full.value == "") {
        alert("Please enter your Reference Full Name.");
        theForm.ref_01_name_full.focus();
        return (false);
    }

    var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- \t\r\n\f";
    var checkStr = theForm.ref_01_name_full.value;
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
        alert("Please enter only letters in the Reference Full Name field.");
        theForm.ref_01_name_full.focus();
        return (false);
    }

    if (theForm.ref_01_phone_home1.value == "") {
        alert("Please enter your Reference Phone No.");
        theForm.ref_01_phone_home1.focus();
        return (false);
    }

    if (theForm.ref_01_phone_home1.value.length < 3) {
        alert("Please enter 3 digits in the Reference Phone No. field.");
        theForm.ref_01_phone_home1.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.ref_01_phone_home1.value;
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
        alert("Please enter only digits in the Reference Phone No. field.");
        theForm.ref_01_phone_home1.focus();
        return (false);
    }

    if (theForm.ref_01_phone_home2.value == "") {
        alert("Please enter your Reference Phone No.");
        theForm.ref_01_phone_home2.focus();
        return (false);
    }

    if (theForm.ref_01_phone_home2.value.length < 3) {
        alert("Please enter 3 digits in the Reference Phone No. field.");
        theForm.ref_01_phone_home2.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.ref_01_phone_home2.value;
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
        alert("Please enter only digits in the Reference Phone No. field.");
        theForm.ref_01_phone_home2.focus();
        return (false);
    }

    if (theForm.ref_01_phone_home3.value == "") {
        alert("Please enter your Reference Phone No.");
        theForm.ref_01_phone_home3.focus();
        return (false);
    }

    if (theForm.ref_01_phone_home3.value.length < 4) {
        alert("Please enter 4 digits in the Reference Phone No. field.");
        theForm.ref_01_phone_home3.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.ref_01_phone_home3.value;
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
        alert("Please enter only digits in the Reference Phone No. field.");
        theForm.ref_01_phone_home3.focus();
        return (false);
    }



//    if (theForm.ref_01_relationship.value == "") {
//        alert("Please enter your Reference Relationship.");
//        theForm.ref_01_relationship.focus();
//        return (false);
//    }

//    var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- \t\r\n\f";
//    var checkStr = theForm.ref_01_relationship.value;
//    var allValid = true;
//    var validGroups = true;
//    var decPoints = 0;
//    var allNum = "";
//    for (i = 0; i < checkStr.length; i++) {
//        ch = checkStr.charAt(i);
//        for (j = 0; j < checkOK.length; j++)
//            if (ch == checkOK.charAt(j))
//            break;
//        if (j == checkOK.length) {
//            allValid = false;
//            break;
//        }
//        allNum += ch;
//    }
//    if (!allValid) {
//        alert("Please enter only letters in the Reference Relationship field.");
//        theForm.ref_01_relationship.focus();
//        return (false);
//    }



    if (theForm.ref_02_name_full.value == "") {
        alert("Please enter your Reference Full Name.");
        theForm.ref_02_name_full.focus();
        return (false);
    }

    var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- \t\r\n\f";
    var checkStr = theForm.ref_02_name_full.value;
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
        alert("Please enter only letters in the Reference Full Name field.");
        theForm.ref_02_name_full.focus();
        return (false);
    }

    if (theForm.ref_02_phone_home1.value == "") {
        alert("Please enter your Reference Phone No.");
        theForm.ref_02_phone_home1.focus();
        return (false);
    }

    if (theForm.ref_02_phone_home1.value.length < 3) {
        alert("Please enter 3 digits in the Reference Phone No. field.");
        theForm.ref_02_phone_home1.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.ref_02_phone_home1.value;
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
        alert("Please enter only digits in the Reference Phone No. field.");
        theForm.ref_02_phone_home1.focus();
        return (false);
    }

    if (theForm.ref_02_phone_home2.value == "") {
        alert("Please enter your Reference Phone No.");
        theForm.ref_02_phone_home2.focus();
        return (false);
    }

    if (theForm.ref_02_phone_home2.value.length < 3) {
        alert("Please enter 3 digits in the Reference Phone No. field.");
        theForm.ref_02_phone_home2.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.ref_02_phone_home2.value;
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
        alert("Please enter only digits in the Reference Phone No. field.");
        theForm.ref_02_phone_home2.focus();
        return (false);
    }

    if (theForm.ref_02_phone_home3.value == "") {
        alert("Please enter your Reference Phone No.");
        theForm.ref_02_phone_home3.focus();
        return (false);
    }

    if (theForm.ref_02_phone_home3.value.length < 4) {
        alert("Please enter 4 digits in the Reference Phone No. field.");
        theForm.ref_02_phone_home3.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.ref_02_phone_home3.value;
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
        alert("Please enter only digits in the Reference Phone No. field.");
        theForm.ref_02_phone_home3.focus();
        return (false);
    }




//    if (theForm.ref_02_relationship.value == "") {
//        alert("Please enter your Reference Relationship.");
//        theForm.ref_02_relationship.focus();
//        return (false);
//    }

//    var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- \t\r\n\f";
//    var checkStr = theForm.ref_02_relationship.value;
//    var allValid = true;
//    var validGroups = true;
//    var decPoints = 0;
//    var allNum = "";
//    for (i = 0; i < checkStr.length; i++) {
//        ch = checkStr.charAt(i);
//        for (j = 0; j < checkOK.length; j++)
//            if (ch == checkOK.charAt(j))
//            break;
//        if (j == checkOK.length) {
//            allValid = false;
//            break;
//        }
//        allNum += ch;
//    }
//    if (!allValid) {
//        alert("Please enter only letters in the Reference Relationship field.");
//        theForm.ref_02_relationship.focus();
//        return (false);
//    }



    if (theForm.employer_name.value == "") {
        alert("Please enter your Employer Name.");
        theForm.employer_name.focus();
        return (false);
    }




//    if (theForm.months_employed.value == "") {
//        alert("Please enter your Months Employed.");
//        theForm.months_employed.focus();
//        return (false);
//    }

//    var checkOK = "0123456789";
//    var checkStr = theForm.months_employed.value;
//    var allValid = true;
//    var validGroups = true;
//    var decPoints = 0;
//    var allNum = "";
//    for (i = 0; i < checkStr.length; i++) {
//        ch = checkStr.charAt(i);
//        for (j = 0; j < checkOK.length; j++)
//            if (ch == checkOK.charAt(j))
//            break;
//        if (j == checkOK.length) {
//            allValid = false;
//            break;
//        }
//        allNum += ch;
//    }
//    if (!allValid) {
//        alert("Please enter only digits in the Months Employed field.");
//        theForm.months_employed.focus();
//        return (false);
//    }
    
    
    
    
    if (theForm.phone_work1.value == "") {
        alert("Please enter your Work Phone No.");
        theForm.phone_work1.focus();
        return (false);
    }

    if (theForm.phone_work1.value.length < 3) {
        alert("Please enter 3 digits in the Work Phone No. field.");
        theForm.phone_work1.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_work1.value;
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
        alert("Please enter only digits in the Work Phone No. field.");
        theForm.phone_work1.focus();
        return (false);
    }

    if (theForm.phone_work2.value == "") {
        alert("Please enter your Work Phone No.");
        theForm.phone_work2.focus();
        return (false);
    }

    if (theForm.phone_work2.value.length < 3) {
        alert("Please enter 3 digits in the Work Phone No. field.");
        theForm.phone_work2.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.phone_work2.value;
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
        alert("Please enter only digits in the Work Phone No. field.");
        theForm.phone_work2.focus();
        return (false);
    }
    
    if (theForm.phone_work3.value == "") {
        alert("Please enter your Work Phone No.");
        theForm.phone_work3.focus();
        return (false);
    }

    if (theForm.phone_work3.value.length < 4) {
        alert("Please enter 4 digits in the Work Phone No. field.");
        theForm.phone_work3.focus();
        return (false);
    }
    
    var checkOK = "0123456789";
    var checkStr = theForm.phone_work3.value;
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
        alert("Please enter only digits in the Work Phone No. field.");
        theForm.phone_work3.focus();
        return (false);
    }

    if (theForm.phone_work_ext.value != "") {

        var checkOK = "0123456789";
        var checkStr = theForm.phone_work_ext.value;
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
            alert("Please enter only digits in the Work Phone Ext. field.");
            theForm.phone_work_ext.focus();
            return (false);
        }
    }



//    if (theForm.pay_per_period.value == "") {
//        alert("Please enter your Pay per Period.");
//        theForm.pay_per_period.focus();
//        return (false);
//    }

//    var checkOK = "0123456789";
//    var checkStr = theForm.pay_per_period.value;
//    var allValid = true;
//    var validGroups = true;
//    var decPoints = 0;
//    var allNum = "";
//    for (i = 0; i < checkStr.length; i++) {
//        ch = checkStr.charAt(i);
//        for (j = 0; j < checkOK.length; j++)
//            if (ch == checkOK.charAt(j))
//            break;
//        if (j == checkOK.length) {
//            allValid = false;
//            break;
//        }
//        allNum += ch;
//    }
//    if (!allValid) {
//        alert("Please enter only digits in the Pay per Period field.");
//        theForm.pay_per_period.focus();
//        return (false);
//    }



//    if (theForm.income_monthly.value == "") {
//        alert("Please enter your Monthly Income.");
//        theForm.income_monthly.focus();
//        return (false);
//    }

//    var checkOK = "0123456789";
//    var checkStr = theForm.income_monthly.value;
//    var allValid = true;
//    var validGroups = true;
//    var decPoints = 0;
//    var allNum = "";
//    for (i = 0; i < checkStr.length; i++) {
//        ch = checkStr.charAt(i);
//        for (j = 0; j < checkOK.length; j++)
//            if (ch == checkOK.charAt(j))
//            break;
//        if (j == checkOK.length) {
//            allValid = false;
//            break;
//        }
//        allNum += ch;
//    }
//    if (!allValid) {
//        alert("Please enter only digits in the Monthly Income field.");
//        theForm.income_monthly.focus();
//        return (false);
//    }
    
    
    
  
   




    //var paydate1 = new Date(2005, 5, 1); // months run from 0 to 11, rather than 1 to 12
    //var paydate2 = new Date(2005, 5, 1); 
    //var today = new Date(); // creates a new Date representing today
    
    
    

    if (theForm.bank_name.value == "") {
        alert("Please enter your Bank Name.");
        theForm.bank_name.focus();
        return (false);
    }





//    if (theForm.months_at_bank.value == "") {
//        alert("Please enter your Months at Bank.");
//        theForm.months_at_bank.focus();
//        return (false);
//    }

//    var checkOK = "0123456789";
//    var checkStr = theForm.months_at_bank.value;
//    var allValid = true;
//    var validGroups = true;
//    var decPoints = 0;
//    var allNum = "";
//    for (i = 0; i < checkStr.length; i++) {
//        ch = checkStr.charAt(i);
//        for (j = 0; j < checkOK.length; j++)
//            if (ch == checkOK.charAt(j))
//            break;
//        if (j == checkOK.length) {
//            allValid = false;
//            break;
//        }
//        allNum += ch;
//    }
//    if (!allValid) {
//        alert("Please enter only digits in the Months at Bank field.");
//        theForm.months_at_bank.focus();
//        return (false);
//    }




    if (theForm.bank_aba.value == "") {
        alert("Please enter your Bank ABA No.");
        theForm.bank_aba.focus();
        return (false);
    }

    if (theForm.bank_aba.value.length < 9) {
        alert("Please enter 9 digits in the Bank ABA No. field.");
        theForm.bank_aba.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.bank_aba.value;
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
        alert("Please enter only digits in the Bank ABA No. field.");
        theForm.bank_aba.focus();
        return (false);
    }

    if (theForm.bank_account.value == "") {
        alert("Please enter your Bank Account No.");
        theForm.bank_account.focus();
        return (false);
    }

    if (theForm.bank_account.value.length < 2) {
        alert("Please enter at least 2 characters in the Bank Account No. field.");
        theForm.bank_account.focus();
        return (false);
    }

    if (theForm.social_security.value == "") {
        alert("Please enter your Social Security No.");
        theForm.social_security.focus();
        return (false);
    }

    if (theForm.social_security.value.length < 9) {
        alert("Please enter 9 digits in the Social Security No. field.");
        theForm.social_security.focus();
        return (false);
    }

    var checkOK = "0123456789";
    var checkStr = theForm.social_security.value;
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
        alert("Please enter only digits in the Social Security No. field.");
        theForm.social_security.focus();
        return (false);
    }

    if (theForm.drivers_license.value == "") {
        alert("Please enter your Drivers License No.");
        theForm.drivers_license.focus();
        return (false);
    }

    return (true);
}