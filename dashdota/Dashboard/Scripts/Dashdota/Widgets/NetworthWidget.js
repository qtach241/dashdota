function NetworthWidget() {

    var container = document.createElement("div");
    container.className = "networthWidget";
    container.style.position = "relative";
    container.style.zIndex = 0;

    var background = document.createElement("img");
    background.src = BaseImageDirectoryUrl + "networth_background.png";
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

    var levelBackground = document.createElement("img");
    levelBackground.src = BaseImageDirectoryUrl + "gold_shield.png";
    levelBackground.style.position = "absolute";
    levelBackground.style.zIndex = 2;
    levelBackground.style.width = "28px";
    levelBackground.style.height = "35px";
    levelBackground.style.left = "0px";
    levelBackground.style.top = "0px";
    container.appendChild(levelBackground);

    var levelNumberBox = document.createElement("div");
    levelNumberBox.className = "levelNumberBox";
    levelNumberBox.style.zIndex = 3;
    levelNumberBox.style.left = "2px";
    levelNumberBox.style.top = "5px";
    container.appendChild(levelNumberBox);

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

    // Xpm and Gpm
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

    // Item Slots
    var itemSlot0 = document.createElement("img");
    itemSlot0.className = "itemSlot";
    itemSlot0.style.position = "absolute";
    itemSlot0.style.left = "270px";
    itemSlot0.style.top = "2px";
    container.appendChild(itemSlot0);

    var itemSlot1 = document.createElement("img");
    itemSlot1.className = "itemSlot";
    itemSlot1.style.position = "absolute";
    itemSlot1.style.left = "323px";
    itemSlot1.style.top = "2px";
    container.appendChild(itemSlot1);

    var itemSlot2 = document.createElement("img");
    itemSlot2.className = "itemSlot";
    itemSlot2.style.position = "absolute";
    itemSlot2.style.left = "376px";
    itemSlot2.style.top = "2px";
    container.appendChild(itemSlot2);

    var itemSlot3 = document.createElement("img");
    itemSlot3.className = "itemSlot";
    itemSlot3.style.position = "absolute";
    itemSlot3.style.left = "429px";
    itemSlot3.style.top = "2px";
    container.appendChild(itemSlot3);

    var itemSlot4 = document.createElement("img");
    itemSlot4.className = "itemSlot";
    itemSlot4.style.position = "absolute";
    itemSlot4.style.left = "482px";
    itemSlot4.style.top = "2px";
    container.appendChild(itemSlot4);

    var itemSlot5 = document.createElement("img");
    itemSlot5.className = "itemSlot";
    itemSlot5.style.position = "absolute";
    itemSlot5.style.left = "535px";
    itemSlot5.style.top = "2px";
    container.appendChild(itemSlot5);

    var networthBarWidget = new NetworthBarWidget(container, "127px", "26px", 0);

    // External Functions
    container.SetName = function (value) {
        nameTextBox.innerHTML = value;
    }

    container.SetHero = function (value) {
        heroPortrait.src = HeroImageDirectoryUrl + value + ".png";
    }

    container.SetLevel = function (value) {
        levelNumberBox.innerHTML = value;
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

    container.SetItemSlot0 = function (value) {
        itemSlot0.src = ItemImageDirectoryUrl + value + ".png";
    }

    container.SetItemSlot1 = function (value) {
        itemSlot1.src = ItemImageDirectoryUrl + value + ".png";
    }

    container.SetItemSlot2 = function (value) {
        itemSlot2.src = ItemImageDirectoryUrl + value + ".png";
    }

    container.SetItemSlot3 = function (value) {
        itemSlot3.src = ItemImageDirectoryUrl + value + ".png";
    }

    container.SetItemSlot4 = function (value) {
        itemSlot4.src = ItemImageDirectoryUrl + value + ".png";
    }

    container.SetItemSlot5 = function (value) {
        itemSlot5.src = ItemImageDirectoryUrl + value + ".png";
    }

    container.SetNetworthPercentage = function (value) {
        networthBarWidget.SetNetworthPercentage(value);
    }

    return container;
}