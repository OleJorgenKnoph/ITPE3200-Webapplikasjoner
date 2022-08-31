//Ready function that get all exitsting customers.

$(function () {
    hentAlleKunder();
});

//The function is called from ready-func and get the customer through an get-req
//and pushes the gotten clients to another function which will format them.

function hentAlleKunder() {
    $.get("Kunde/HentAlle", function (kunder) {
        formaterKunder(kunder);
    });
}

//This function get all customer from the prev get-req and formats them for the client-side using bootstrap
function formaterKunder(kunder) {
    let ut =
        "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th>" + "<th>Adresse</th> <th></th>" +
        "</tr>";

    for (let kunde of kunder) {
        ut += "<tr>" +
            "<td>" + kunde.navn + "</td>" +
            "<td>" + kunde.adresse + "</td>" +
            "</tr>";
    }

    ut += "</table>";

    $("#kunde").html(ut);
}

