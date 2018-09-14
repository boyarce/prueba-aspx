function fn_menu_show() {
    document.getElementById("pnl-menu").style.width = "300px";
    document.getElementById("pnl-container").style.marginLeft = "300px";
    document.getElementById("btn-menu-open").style.display = "none";
    document.getElementById("btn-menu-close").style.display = "inline";
}

function fn_menu_hidden() {
    document.getElementById("pnl-menu").style.width = "0";
    document.getElementById("pnl-container").style.marginLeft = "0";
    document.getElementById("btn-menu-open").style.display = "inline";
    document.getElementById("btn-menu-close").style.display = "none";
}