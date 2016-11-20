// Sets up AJAX routine to get game state from server.
function GetGameState(steamId, url, callback) {
    $.ajax({
        url: url,
        method: "GET",
        timeout: 10000,
        data: {
            id: steamId,
        },
    })
    .done(function (data) {
        var gameStateObjects = data.GameStates;
        var teamWideAlerts = data.Alerts;

        // TODO: There is only one widget at the moment, so having a
        // a callback here doesn't really accomplish anything useful.
        // Just call the update function directly.
        UpdateNetworthWidgets(gameStateObjects, teamWideAlerts);

        if (callback != null) {
            callback(gameStateObjects);
        }
        
    })
    .fail(function (data) {

    })
    .always(function (data) {
        setTimeout(Timeout, TimeoutLengthMs);
    });
}

// Helpers to update widgets and set widget properties.
function UpdateWidgets(gameStateObjects, className, createCallback, updateCallback) {
    if (!gameStateObjects) {
        return;
    }

    // Find existing children in container.
    var parent = document.getElementById("baseWidgetBody");
    var children = parent.getElementsByClassName(className);

    // Convert HTMLCollection to array to allow pop() and push().
    // Can't use Array.from because not supported by IE11.
    var targetWidgets = [];
    for (var i = 0; i < children.length; i++) {
        targetWidgets.push(children[i]);
    }

    // Delete any existing widgets that are no longer needed.
    while (targetWidgets.length > gameStateObjects.length) {
        parent.removeChild(targetWidgets.pop());
    }

    // Create any new widgets that are needed.
    while (gameStateObjects.length > targetWidgets.length) {
        var newWidget = createCallback(targetWidgets.length);
        parent.appendChild(newWidget);
        targetWidgets.push(newWidget);
    }

    // Now that arrays are the same length, update each widget.
    for (var i = 0; i < gameStateObjects.length; i++) {
        // Update widget with new data.
        updateCallback(targetWidgets[i], gameStateObjects[i]);

        // Dim/hide the widgets.
        UpdateTransparency(targetWidgets[i], gameStateObjects[i]);
    }
}

function UpdateTransparency(widget, gameStateObject) {
    if (!widget) {
        return;
    }

    if (!gameStateObject) {
        widget.style.opacity = 0.5
    }
    else {
        widget.style.opacity = 1;
    }
}