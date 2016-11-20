// Update all networth widgets (for up to 5 players).
function UpdateNetworthWidgets(gameStateObjects, teamWideAlerts) {
    // Currently, the Networth widget is the only widget available, so just
    // call Create and Update directly instead of routing through callbacks.
    //UpdateWidgets(gameStateObjects, "networthWidget", CreateNetworthWidget, UpdateNetworthWidget);

    if (!gameStateObjects || !teamWideAlerts) {
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
        // Update widget and any sub-widgets with new data.
        UpdateNetworthWidget(targetWidgets[i], gameStateObjects[i], teamWideAlerts, topNetworth);
    }
}

// Update a single networth widget (for only one player).
function UpdateNetworthWidget(widget, gameState, teamWideAlerts, topNetworth) {
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

    // Set the hero level.
    if (gameState.hasOwnProperty("Level")) {
        widget.SetLevel(gameState.Level);
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

    // Set item slots.
    if (gameState.hasOwnProperty("Item0")) {
        widget.SetItemSlot0(gameState.Item0);
    }

    if (gameState.hasOwnProperty("Item1")) {
        widget.SetItemSlot1(gameState.Item1);
    }

    if (gameState.hasOwnProperty("Item2")) {
        widget.SetItemSlot2(gameState.Item2);
    }

    if (gameState.hasOwnProperty("Item3")) {
        widget.SetItemSlot3(gameState.Item3);
    }

    if (gameState.hasOwnProperty("Item4")) {
        widget.SetItemSlot4(gameState.Item4);
    }

    if (gameState.hasOwnProperty("Item5")) {
        widget.SetItemSlot5(gameState.Item5);
    }

    // Set Alerts sub-widget.
    if (teamWideAlerts.hasOwnProperty("NoDetection")) {
        widget.SetDetectionAlert(teamWideAlerts.NoDetection);
    }

    if (teamWideAlerts.hasOwnProperty("ObsOffCooldown")) {
        widget.SetWardAlert(teamWideAlerts.ObsOffCooldown);
    }

    if (gameState.hasOwnProperty("NoTp")) {
        widget.SetTpAlert(gameState.NoTp);
    }

    if (gameState.hasOwnProperty("NoUlt")) {
        widget.SetUltAlert(gameState.NoUlt);
    }

    if (gameState.hasOwnProperty("MidasOffCooldown")) {
        widget.SetMidasAlert(gameState.MidasOffCooldown);
    }
    
    if (gameState.hasOwnProperty("LowHealth")) {
        widget.SetHealthAlert(gameState.LowHealth);
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