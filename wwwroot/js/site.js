var OnMyLinkClick = function (tabstrip, tabName, controller, action) {
    var tabStrip = $(tabstrip).data("kendoTabStrip");
    var items = tabStrip.items();
    for (var i = 1; i < items.length; i++) {
        if (items[i].textContent == tabName) {
            tabStrip.select(i);
            return;
        }            
    }
    tabStrip.append({
        contentUrl: controller + "/" + action,
        text: tabName + '<span data-type="remove" class="k-link"><span class="k-icon k-i-x"></span></span>',
        encoded: false
    });
    tabStrip.tabGroup.on("click", "[data-type='remove']", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var item = $(e.target).closest(".k-item");
        tabStrip.remove(item.index());

        if (tabStrip.items().length > 0 && item.hasClass('k-state-active')) {
            tabStrip.select(0);
        }
    });
};
