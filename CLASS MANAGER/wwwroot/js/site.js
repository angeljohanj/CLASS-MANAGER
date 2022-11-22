// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//this function will evaluate in the front-end if the user and pass are empty----->
function validator() {
    var user = document.getElementById("exampleInputEmail1").value
    var pass = document.getElementById("exampleInputPassword1").value

    if (user != "" && pass != "") {
        document.getElementById("login").submit()
    } else if (user == "" && pass != "") {
        alert("Please input username");
    } else if (user != "" && pass == "") {
        alert("Please input password")
    } else {
        alert("input username and password to log in");
    }   
}


//To validate new user fields in the front-end-------->

function ValidateNewUser() {

    var newUser = [
        user = document.getElementById("usernameInput").value,
        pass = document.getElementById("passwordInput").value,
        name = document.getElementById("nameInput").value,
        lastname = document.getElementById("lastnameInput").value,
        age = document.getElementById("ageInput").value,
        cedula = document.getElementById("cedulaInput").value,
        address = document.getElementById("addressInput").value,
        telephone = document.getElementById("telephoneInput").value,
        email = document.getElementById("emailINput").value
    ]
    if (newUser[0] == "") {
        alert("Username is required");
    } else if (newUser[1] == "") {
        alert("Password is required");
    }
    else if (newUser[2] == "") {
        alert("Name is required");
    }
    else if (newUser[3] == "") {
        alert("Lastname is required");
    }
    else if (newUser[4] == "") {
        alert("Age is required");
    }
    else if (newUser[5] == "") {
        alert("Cedula is required");
    }
    else if (newUser[6] == "") {
        alert("Address is required");
    }
    else if (newUser[7] == "") {
        alert("Telephone is required");
    }
    else if (newUser[8] == "") {
        alert("Email is required");
    } else {
        document.getElementById("newUser").submit();
    }


  /*  var newUser= [
        user = document.getElementById("usernameInput").value,
        pass = document.getElementById("passwordInput").value,
        name = document.getElementById("nameInput").value,
        lastname = document.getElementById("lastnameInput").value,
        age = document.getElementById("ageInput").value,
        cedula = document.getElementById("cedulaInput").value,
        address = document.getElementById("addressInput").value,
        telephone = document.getElementById("telephoneInput").value,
        email = document.getElementById("emailINput").value
        ]
    
       
    switch (newUser[0,1,2,3,4,5,6,7,8]) {

        case (newUser[0] == ""):
            alert("this is a string");
            break;
        case (newUser[1] == ""):
            alert("Password is mandatory");
            break;
        case (newUser[2] == ""):
            alert("Name is mandatory");
            break;
        case (newUser[3] == ""):
            alert("Lastname is mandatory");
            break;
        case (newUser[4] == ""):
            alert("Age is mandatory");
            break;
        case (newUser[5] == ""):
            alert("Cedula is mandatory");
            break;
        case (newUser[6] == ""):
            alert("Address is mandatory");
            break;
        case (newUser[7] == ""):
            alert("Telephone is mandatory");
            break;
        case (newUser[8] == ""):
            alert("Email is mandatory");
            break;
    }*/
}
