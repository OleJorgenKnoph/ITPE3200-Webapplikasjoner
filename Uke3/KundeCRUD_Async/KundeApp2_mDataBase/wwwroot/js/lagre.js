function lagreKunden() {
    const kunde = {
        forNavn: $("#forNavnInput").val(),
        etterNavn: $("#etterNavnInput").val(),
        adresse: $("#adrInput").val(),
        postNr: $("#postNrInput").val(),
        postSted: $("#postStedInput").val()
    };

    console.table(kunde);

    $.post("Kunde/lagreKunde", kunde, function (OK) {
        if (OK) {
            window.location.href = "index.html";
        }
        else {
            $("#feil").html = "Feil i DB. Prøv igjen";
        }
    }    )
}