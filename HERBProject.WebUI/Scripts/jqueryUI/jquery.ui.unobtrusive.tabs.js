/// <reference path="..\jquery-1.4.4.js" />
/// <reference path="..\jquery-ui.js" />
/// <reference path="jquery.ui.unobtrusive.js" />

function fixKnownTabsAttrCasing(attrName) {
    return fixKnownAttrCasing(attrName, tabsKnownAttributes);
}

function setupUnobtrusiveTabs(jQueryElement) {
    jQueryElement.tabs(getAllAttributes(jQueryElement, "data-ui-tabs-", fixKnownTabsAttrCasing));
}

function setupAllUnobtrusiveTabsChildrenOf(jQueryElement) {
    jQueryElement.find("[data-ui-tabs=true]").each(function () {
        setupUnobtrusiveTabs($(this));
    });
}

var tabsKnownAttributes = [
            "disabled", "ajaxOptions", "cache", "collapsible", "cookie", "deselectable",
            "event", "fx", "idPrefix", "panelTemplate", "selected", "spinner", "tabTemplate"
        ];

