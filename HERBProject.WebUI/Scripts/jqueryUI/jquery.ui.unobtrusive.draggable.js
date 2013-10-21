/// <reference path="..\jquery-1.4.4.js" />
/// <reference path="..\jquery-ui.js" />
/// <reference path="jquery.ui.unobtrusive.js" />

function fixKnownDraggableAttrCasing(attrName) {
    return fixKnownAttrCasing(attrName, draggableKnownAttributes);
}

function setupUnobtrusiveDraggable(jQueryElement) {
    jQueryElement.draggable(getAllAttributes(jQueryElement, "data-ui-draggable-", fixKnownDraggableAttrCasing));
}

function setupAllUnobtrusiveDraggableChildrenOf(jQueryElement) {
    jQueryElement.find("[data-ui-draggable=true]").each(function () {
        setupUnobtrusiveDraggable($(this));
    });
}

var draggableKnownAttributes = [
        "disabled", "addClasses", "appendTo", "axis", "cancel", "connectToSortable", "containment",
        "cursor", "cursorAt", "delay", "distance", "grid", "handle", "helper", "iframeFix",
        "opacity", "refreshPositions", "revert", "revertDuration", "scope", "scroll",
        "scrollSensitivity", "scrollSpeed", "snap", "snapMode", "snapTolerance", "stack",
        "zIndex"
        ];

