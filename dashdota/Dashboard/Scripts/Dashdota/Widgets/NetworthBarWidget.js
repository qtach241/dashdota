function getNetworthBarSrcImage(id) {
    return NetworthImageDirectoryUrl + id + ".png";
}

function NetworthBarWidget(parent, left, top, zIndex) {

    var container = document.createElement("div");
    container.className = "networthBar";
    container.style.position = "absolute";
    container.style.zIndex = zIndex;
    container.style.left = left;
    container.style.top = top;

    var networthBarImage = document.createElement("img");
    networthBarImage.style.position = "absolute";

    container.SetNetworthPercentage = function (percentage) {
        if ((percentage >= 0) && (percentage <= 100)) {
            networthBarImage.src = getNetworthBarSrcImage(percentage);
        }
        else {
            console.log("Networth percentage out of bounds!");
        }
    }

    // Set to default state
    container.SetNetworthPercentage(0);

    // Add image to container.
    container.appendChild(networthBarImage);

    // Add new widget to parent.
    parent.appendChild(container);

    return container;
}