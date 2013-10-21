/// <reference path="..\jquery-1.4.4.js" />
/// <reference path="..\jquery-ui.js" />
/// <reference path="jquery.ui.unobtrusive.js" />

function fixKnownAccordionAttrCasing(attrName) {
    return fixKnownAttrCasing(attrName, accordionKnownAttributes);
}

function setupUnobtrusiveAccordion(jQueryElement) {
    jQueryElement.accordion(getAllAttributes(jQueryElement, "data-ui-Accordion-", fixKnownAccordionAttrCasing));
}

function setupAllUnobtrusiveAccordionChildrenOf(jQueryElement) {
    jQueryElement.find("[data-ui-accordion=true]").each(function () {
        setupUnobtrusiveAccordion($(this));
    });
}

var accordionKnownAttributes = [
            "disabled", "active", "animated", "autoHeight", "clearStyle", "collapsible",
            "event", "fillSpace", "header", "icons", "navigation", "navigationFilter"
        ];

