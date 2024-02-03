$(document).ready(function () {
    // Initialize game button click event
    $('#initGameBtn').click(function () {
        $.get('https://localhost:7016/v1/battleship/init')
            .done(function (data) {
                showMessage(data.message);
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                showMessage('Error initializing game: ' + errorThrown);
            });
    });

    // Fire missile button click event
    $('#fireBtn').click(function () {
        var coordinates = $('#coordinatesInput').val().toUpperCase();
        if (coordinates) {

            var settings = {
                "url": "https://localhost:7016/v1/battleship/fire",
                "method": "POST",
                "timeout": 0,
                "headers": {
                    "Content-Type": "application/json"
                },
                "data": JSON.stringify(coordinates),
            };

            $.ajax(settings)
                .done(function (data) {
                    showMessage(data.message);
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    showMessage('Error firing missile: ' + errorThrown);
                });
        } else {
            showMessage('Please enter coordinates.');
        }
    });

    // Function to display game messages
    function showMessage(message) {
        $('#gameMessage').text(message).removeClass('d-none');
    }
});
