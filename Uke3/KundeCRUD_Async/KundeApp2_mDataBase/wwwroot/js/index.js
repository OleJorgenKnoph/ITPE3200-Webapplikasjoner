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
        "<th>Fornavn</th> <th>Etternavn</th> <th>Adresse</th> <th>Postnummer</th> <th>Poststed</th> <th></th> <th></th>" +
        "</tr>";

    for (let kunde of kunder) {
        ut += "<tr>" +
                "<td>" + kunde.forNavn + "</td>" +
                "<td>" + kunde.etterNavn + "</td>" +
                "<td>" + kunde.adresse + "</td>" +
                "<td>" + kunde.postNr + "</td>" +
                "<td>" + kunde.postSted + "</td>" +
                "<td> <a href='endre.html?id=" + kunde.id + "' class='btn btn-outline-secondary'> Endre opplysninger </a> </td>" +
                "<td> <button class='btn btn-outline-danger' onclick='slettKunde(" + kunde.id +")'> Slett </button> </td>" +
            "</tr>";
    }

    ut += "</table><a href='lagre.html' class='btn btn-outline-success m-3'>Lagre en ny kunde</a>";

    $("#container").html(ut);
}

function slettKunde(id) {
    const url = "Kunde/Slett?id=" + id;

    $.get(url, function (OK) {
        if (OK) {
            window.location.href = "index.html";
        }
        else {
            $("#feil").html("Feil i DB. Prøv på nytt")
        }
    })
}

