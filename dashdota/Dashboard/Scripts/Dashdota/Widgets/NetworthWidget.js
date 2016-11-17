function NetworthWidget() {

    var container = document.createElement("div");
    container.className = "networthWidget";
    container.style.position = "relative";
    container.style.zIndex = 0;

    var background = document.createElement("img");
    background.src = BaseImageDirectoryUrl + "networth_background.png"
    background.style.position = "absolute";
    background.style.zIndex = 0;
    background.style.left = "120px";
    background.style.top = "0px";
    container.appendChild(background);

    var heroPortrait = document.createElement("img");
    heroPortrait.style.position = "absolute";
    heroPortrait.style.zIndex = 1;
    heroPortrait.style.left = "121px";
    heroPortrait.style.top = "2px";
    container.appendChild(heroPortrait);

    var networthNumberBox = document.createElement("div");
    networthNumberBox.className = "networthNumberBox";
    networthNumberBox.style.position = "absolute";
    networthNumberBox.style.zIndex = 1;
    networthNumberBox.style.left = "262px";
    networthNumberBox.style.top = "12px";
    container.appendChild(networthNumberBox);

    var nameTextBox = document.createElement("div");
    nameTextBox.className = "nameTextBox";
    nameTextBox.style.zIndex = 1;
    nameTextBox.style.left = "124px";
    nameTextBox.style.top = "54px";
    container.appendChild(nameTextBox);

    var gpmBackgroundBox = document.createElement("img");
    gpmBackgroundBox.src = BaseImageDirectoryUrl + "value_box_olive.png";
    gpmBackgroundBox.style.position = "absolute";
    gpmBackgroundBox.style.zIndex = 0;
    gpmBackgroundBox.style.left = "0px";
    gpmBackgroundBox.style.top = "2px";
    container.appendChild(gpmBackgroundBox);

    var xpmBackgroundBox = document.createElement("img");
    xpmBackgroundBox.src = BaseImageDirectoryUrl + "value_box_teal.png";
    xpmBackgroundBox.style.position = "absolute";
    xpmBackgroundBox.style.zIndex = 0;
    xpmBackgroundBox.style.left = "0px";
    xpmBackgroundBox.style.top = "38px";
    container.appendChild(xpmBackgroundBox);

    var gpmLabelBox = document.createElement("div");
    gpmLabelBox.className = "smallLabelBox";
    gpmLabelBox.innerHTML = "gpm:";
    gpmLabelBox.style.zIndex = 1;
    gpmLabelBox.style.left = "5px";
    gpmLabelBox.style.top = "9px";
    container.appendChild(gpmLabelBox);

    var xpmLabelBox = document.createElement("div");
    xpmLabelBox.className = "smallLabelBox";
    xpmLabelBox.innerHTML = "xpm:";
    xpmLabelBox.style.zIndex = 1;
    xpmLabelBox.style.left = "5px";
    xpmLabelBox.style.top = "45px";
    container.appendChild(xpmLabelBox);

    var gpmNumberBox = document.createElement("div");
    gpmNumberBox.className = "smallNumberBox";
    gpmNumberBox.style.zIndex = 1;
    gpmNumberBox.style.left = "50px";
    gpmNumberBox.style.top = "3px";
    gpmNumberBox.style.color = "goldenrod";
    container.appendChild(gpmNumberBox);

    var xpmNumberBox = document.createElement("div");
    xpmNumberBox.className = "smallNumberBox";
    xpmNumberBox.style.zIndex = 1;
    xpmNumberBox.style.left = "50px";
    xpmNumberBox.style.top = "39px";
    xpmNumberBox.style.color = "purple";
    container.appendChild(xpmNumberBox);

    var networthBarWidget = new NetworthBarWidget(container, "247px", "26px", 0);

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