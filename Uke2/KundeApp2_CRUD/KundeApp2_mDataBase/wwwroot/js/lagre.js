function lagreKunden() {
    const kunde = {
        navn: $("#navnInput").val(),
        adresse: $("#adrInput").val()
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