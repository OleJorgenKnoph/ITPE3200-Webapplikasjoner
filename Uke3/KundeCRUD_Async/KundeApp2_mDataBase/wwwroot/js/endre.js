$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet

    const id = window.location.search.substring(1);
    console.log(id);
    const url = "Kunde/HentEnKunde";
    $.get(url, id, function (kunde) {
        $("#id").val(kunde.id); // må ha med id inn skjemaet, hidden i html
        $("#forNavnInput").val(kunde.forNavn);
        $("#etterNavnInput").val(kunde.etterNavn);
        $("#adrInput").val(kunde.adresse);
        $("#postNrInput").val(kunde.postNr);
        $("#postStedInput").val(kunde.postSted);
    });
});

function endreKunde() {
    const innKunde = {
        id: $("#id").val(),
        forNavn: $("#forNavnInput").val(),
        etterNavn: $("#etterNavnInput").val(),
        adresse: $("#adrInput").val(),
        postNr: $("#postNrInput").val(),
        postSted: $("#postStedInput").val()
    }

    $.post("Kunde/oppdaterKunde", innKunde, function (OK) {
        if (OK) {
            window.location.href = "index.html";
        }
        else {
            $("#feil").html = "Feil i DB";
        }
    })
};



