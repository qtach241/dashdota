function NetworthWidget() {

    var container = document.createElement("div");
    container.className = "networthWidget";
    container.style.position = "relative";
    container.style.zIndex = 0;

    var background = document.createElement("img");
    background.src = BaseImageDirectoryUrl + "networth_background.png"
    background.style.position = "absolute";
    background.style.zIndex = 0;
    background.style.left = "0px";
    background.style.top = "0px";
    container.appendChild(background);

    var heroPortrait = document.createElement("img");
    heroPortrait.style.position = "absolute";
    heroPortrait.style.zIndex = 1;
    heroPortrait.style.left = "1px";
    heroPortrait.style.top = "2px";
    container.appendChild(heroPortrait);

    var networthNumberBox = document.createElement("div");
    networthNumberBox.className = "networthNumberBox";
    networthNumberBox.style.position = "absolute";
    networthNumberBox.style.zIndex = 1;
    networthNumberBox.style.left = "140px";
    networthNumberBox.style.top = "12px";
    container.appendChild(networthNumberBox);

    var nameTextBox = document.createElement("div");
    nameTextBox.className = "nameTextBox";
    nameTextBox.style.zIndex = 1;
    nameTextBox.style.left = "4px";
    nameTextBox.style.top = "54px";
    container.appendChild(nameTextBox);

    var gpmLabelBox = document.createElement("div");
    gpmLabelBox.className = "smallLabelBox";
    gpmLabelBox.innerHTML = "gpm:";
    gpmLabelBox.style.zIndex = 1;
    gpmLabelBox.style.left = "132px";
    gpmLabelBox.style.top = "56px";
    container.appendChild(gpmLabelBox);

    var xpmLabelBox = document.createElement("div");
    xpmLabelBox.className = "smallLabelBox";
    xpmLabelBox.innerHTML = "xpm:";
    xpmLabelBox.style.zIndex = 1;
    xpmLabelBox.style.left = "200px";
    xpmLabelBox.style.top = "56px";
    container.appendChild(xpmLabelBox);

    var gpmNumberBox = document.createElement("div");
    gpmNumberBox.className = "smallNumberBox";
    gpmNumberBox.style.zIndex = 1;
    gpmNumberBox.style.left = "162px";
    gpmNumberBox.style.top = "56px";
    container.appendChild(gpmNumberBox);

    var xpmNumberBox = document.createElement("div");
    xpmNumberBox.className = "smallNumberBox";
    xpmNumberBox.style.zIndex = 1;
    xpmNumberBox.style.left = "230px";
    xpmNumberBox.style.top = "56px";
    container.appendChild(xpmNumberBox);

    var networthBarWidget = new NetworthBarWidget(container, "127px", "26px", 0);

    // External Functions
    container.SetName = function (value) {
        nameTextBox.innerHTML = value;
    }

    container.SetHero = function (value) {
        heroPortrait.src = HeroImageDirectoryUrl + value + ".png";
    }

    container.SetGpm = function (value) {
        gpmNumberBox.innerHTML = value;
    }

    container.SetXpm = function (value) {
        xpmNumberBox.innerHTML = value;
    }

    container.SetNetworth = function (value) {
        networthNumberBox.innerHTML = value;
    }

    container.SetNetworthPercentage = function (value) {
        networthBarWidget.SetNetworthPercentage(value);
    }

    return container;
}