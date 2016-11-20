// Icons further left are more common/relevant.
const Position1 = "0px";
const Position2 = "90px";
const Position3 = "180px";
const Position4 = "270px";
const Position5 = "360px";
const Position6 = "450px";

function AlertWidget(parent, left, top, zIndex) {

    var container = document.createElement("div");
    container.className = "alertWidget";
    container.style.position = "absolute";
    container.style.zIndex = zIndex;
    container.style.left = left;
    container.style.top = top;

    var alertNoDetection = document.createElement("img");
    alertNoDetection.className = "alertIconTeam";
    alertNoDetection.src = AlertImageDirectoryUrl + "alert_detection.png";
    alertNoDetection.style.position = "absolute";
    alertNoDetection.style.left = Position1;
    alertNoDetection.style.top = "2px";
    container.appendChild(alertNoDetection);

    var alertWards = document.createElement("img");
    alertWards.className = "alertIconTeam";
    alertWards.src = AlertImageDirectoryUrl + "alert_wards.png";
    alertWards.style.position = "absolute";
    alertWards.style.left = Position2;
    alertWards.style.top = "2px";
    container.appendChild(alertWards);

    var alertNoTp = document.createElement("img");
    alertNoTp.className = "alertIcon";
    alertNoTp.src = AlertImageDirectoryUrl + "alert_tp.png";
    alertNoTp.style.position = "absolute";
    alertNoTp.style.left = Position3;
    alertNoTp.style.top = "2px";
    container.appendChild(alertNoTp);

    var alertNoUlt = document.createElement("img");
    alertNoUlt.className = "alertIcon";
    alertNoUlt.src = AlertImageDirectoryUrl + "alert_ult.png";
    alertNoUlt.style.position = "absolute";
    alertNoUlt.style.left = Position4;
    alertNoUlt.style.top = "2px";
    container.appendChild(alertNoUlt);

    var alertHealth = document.createElement("img");
    alertHealth.className = "alertIcon";
    alertHealth.src = AlertImageDirectoryUrl + "alert_health.png";
    alertHealth.style.position = "absolute";
    alertHealth.style.left = Position5;
    alertHealth.style.top = "2px";
    container.appendChild(alertHealth);

    var alertMidas = document.createElement("img");
    alertMidas.className = "alertIcon";
    alertMidas.src = AlertImageDirectoryUrl + "alert_midas.png";
    alertMidas.style.position = "absolute";
    alertMidas.style.left = Position6;
    alertMidas.style.top = "2px";
    container.appendChild(alertMidas);

    container.SetDetectionAlert = function (enabled) {
        if (enabled) {
            alertNoDetection.style.visibility = "visible";
        }
        else {
            alertNoDetection.style.visibility = "hidden";
        }
    }

    container.SetWardAlert = function (enabled) {
        if (enabled) {
            alertWards.style.visibility = "visible";
        }
        else {
            alertWards.style.visibility = "hidden";
        }
    }

    container.SetTpAlert = function (enabled) {
        if (enabled) {
            alertNoTp.style.visibility = "visible";
        }
        else {
            alertNoTp.style.visibility = "hidden";
        }
    }

    container.SetUltAlert = function (enabled) {
        if (enabled) {
            alertNoUlt.style.visibility = "visible";
        }
        else {
            alertNoUlt.style.visibility = "hidden";
        }
    }

    container.SetHealthAlert = function (enabled) {
        if (enabled) {
            alertHealth.style.visibility = "visible";
        }
        else {
            alertHealth.style.visibility = "hidden";
        }
    }

    container.SetMidasAlert = function (enabled) {
        if (enabled) {
            alertMidas.style.visibility = "visible";
        }
        else {
            alertMidas.style.visibility = "hidden";
        }
    }

    // Add new widget to parent.
    parent.appendChild(container);

    return container;
}