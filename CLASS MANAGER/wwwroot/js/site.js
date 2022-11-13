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