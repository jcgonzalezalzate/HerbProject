/// <reference path="jquery-1.4.4.js" />

(function ($, undefined) {

    $.fn.setupUnobtrusiveChildren = function () {
        setupAllUnobtrusiveChildrenOf($(this));
    }

    $(function () {
        $(document).setupUnobtrusiveChildren();
    });
})(jQuery);

// Helpers for handling attributes casing

function getAllAttributes(jQueryElement, prefix, mapAttrNameFunc) {
    var domElement = jQueryElement.get(0);
    var result = {};
    var attributes = domElement.attributes;
    for (var i = 0; i < attributes.length; i++) {
        var attrName = attributes.item(i).name;

        if (attrName.indexOf(prefix) == 0) {
            var attrValue = jQueryElement.attr(attrName);
            var attrNameWithoutPrefix = attrName.substring(prefix.length);
            var attrValue = jQueryElement.attr(attrName);
            var resultAttrName = attrNameWithoutPrefix;
            if (mapAttrNameFunc) {
                resultAttrName = mapAttrNameFunc(resultAttrName);
            }
            result[resultAttrName] = attrValue;
        }
    }
    return result;
}

function fixKnownAttrCasing(attrNameInLowerCase, knownAttributes) {
    for (var i = 0; i < knownAttributes.length; i++) {
        if (knownAttributes[i].toLowerCase() == attrNameInLowerCase) {
            return knownAttributes[i];
        }
    }
    return attrNameInLowerCase;
}

// Global plugin functions
function setupAllUnobtrusiveChildrenOf(jQueryElement) {
    setupAllUnobtrusiveDatepickerChildrenOf(jQueryElement);
    setupAllUnobtrusiveConfirmActionsChildrenOf(jQueryElement);
    setupAllUnobtrusiveDraggableChildrenOf(jQueryElement);
    setupAllUnobtrusiveAutocompleteChildrenOf(jQueryElement);
    setupAllUnobtrusiveAccordionChildrenOf(jQueryElement);
    setupAllUnobtrusiveSliderChildrenOf(jQueryElement);
    setupAllUnobtrusiveTabsChildrenOf(jQueryElement);
}
