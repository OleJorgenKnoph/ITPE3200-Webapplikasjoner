$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet

    const id = window.location.search.substring(1);
    console.log(id);
    const url = "Kunde/HentEnKunde";
    $.get(url, id, function (kunde) {
        $("#id").val(kunde.id); // må ha med id inn skjemaet, hidden i html
        $("#navnInput").val(kunde.navn);
        $("#adrInput").val(kunde.adresse);
    });
});

function endreKunde() {
    const innKunde = {
        id: $("#id").val(),
        navn: $("#navnInput").val(),
        adresse: $("#adrInput").val()
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



