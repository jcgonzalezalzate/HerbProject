/// <reference path="..\jquery-1.4.4.js" />
/// <reference path="..\jquery-ui.js" />
/// <reference path="jquery.ui.unobtrusive.js" />

function fixKnownAutocompleteAttrCasing(attrName) {
    return fixKnownAttrCasing(attrName, autocompleteKnownAttributes);
}

function setupUnobtrusiveAutocomplete(jQueryElement) {
    var options = getAllAttributes(jQueryElement, "data-ui-autocomplete-", fixKnownAutocompleteAttrCasing);
    // Must improve this implementation so that it works for callbacks, etc.
    // The same applies to events.
    if (options.source) {
        options.source = eval(options.source);
    }
    jQueryElement.autocomplete(options);
}

function setupAllUnobtrusiveAutocompleteChildrenOf(jQueryElement) {
    jQueryElement.find("[data-ui-autocomplete=true]").each(function () {
        setupUnobtrusiveAutocomplete($(this));
    });
}

var autocompleteKnownAttributes = [
            "disabled", "appendTo", "delay", "minLength", "position", "source"
        ];

