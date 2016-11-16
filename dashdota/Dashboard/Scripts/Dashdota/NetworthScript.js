// Update all networth widgets (for up to 5 players).
function UpdateNetworthWidgets(gameStateObjects) {
    // Currently, the Networth widget is the only widget available, so just
    // call Create and Update directly instead of routing through callbacks.
    //UpdateWidgets(gameStateObjects, "networthWidget", CreateNetworthWidget, UpdateNetworthWidget);

    if (!gameStateObjects) {
        return;
    }

    var className = "networthWidget";

    // Find existing children in container.
    var parent = document.getElementById("networthWidgetArea");
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
        var newWidget = CreateNetworthWidget(targetWidgets.length);
        parent.appendChild(newWidget);
        targetWidgets.push(newWidget);
    }

    var topNetworth = 0;

    // Now that arrays are the same length, update each widget.
    for (var i = 0; i < gameStateObjects.length; i++) {
        // Get the top networth from the first game state object.
        if (i == 0) {
            if (gameStateObjects[i].hasOwnProperty("Networth")) {
                topNetworth = gameStateObjects[i].Networth;
            }
        }
        // Update widget with new data.
        UpdateNetworthWidget(targetWidgets[i], gameStateObjects[i], topNetworth);
    }
}

// Update a single networth widget (for only one player).
function UpdateNetworthWidget(widget, gameState, topNetworth) {
    if (!widget || !gameState) {
        return;
    }

    // Set the player's username.
    if (gameState.hasOwnProperty("Name")) {
        widget.SetName(gameState.Name);
    }

    // Set the hero id.
    if (gameState.hasOwnProperty("Hero")) {
        widget.SetHero(gameState.Hero);
    }

    // Set the gold per minute.
    if (gameState.hasOwnProperty("GoldPerMinute")) {
        widget.SetGpm(gameState.GoldPerMinute);
    }

    // Set the experience per minute.
    if (gameState.hasOwnProperty("ExperiencePerMinute")) {
        widget.SetXpm(gameState.ExperiencePerMinute);
    }

    // Set the networth value.
    if (gameState.hasOwnProperty("Networth")) {
        widget.SetNetworth(gameState.Networth);
    }

    // Set the networth percentage relative to top networth.
    if (topNetworth > 0) {
        widget.SetNetworthPercentage(Math.floor((gameState.Networth / topNetworth) * 100));
    }
}

function CreateNetworthWidget(slotNumber) {

    var widget = NetworthWidget();

    return widget;
}