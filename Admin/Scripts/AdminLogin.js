
    $(document).ready(function () {
        $("#forgot-link").click(function () {
            $("#popup-container").fadeIn(500);
        });
        $("#btnCancel").click(function () {
            $("#popup-container").fadeOut(500);
        });
        $("#popup-cross").click(function () {
            $("#popup-container").fadeOut(500);
        });

    });
