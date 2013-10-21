/// <reference path="..\jquery-1.4.4.js" />
/// <reference path="..\jquery-ui.js" />
/// <reference path="jquery.ui.unobtrusive.js" />

function fixKnownSliderAttrCasing(attrName) {
    return fixKnownAttrCasing(attrName, sliderKnownAttributes);
}

function setupUnobtrusiveSlider(jQueryElement) {
    jQueryElement.slider(getAllAttributes(jQueryElement, "data-ui-slider-", fixKnownSliderAttrCasing));
}

function setupAllUnobtrusiveSliderChildrenOf(jQueryElement) {
    jQueryElement.find("[data-ui-slider=true]").each(function () {
        setupUnobtrusiveSlider($(this));
    });
}

var sliderKnownAttributes = [
            "disabled", "animate", "max", "min", "orientation", "range", "step", "value", "values"
        ];

