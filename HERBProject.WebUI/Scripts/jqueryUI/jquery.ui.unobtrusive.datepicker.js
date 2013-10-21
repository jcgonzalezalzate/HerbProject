/// <reference path="..\jquery-1.4.4.js" />
/// <reference path="..\jquery-ui.js" />
/// <reference path="jquery.ui.unobtrusive.js" />

function fixKnownDatepickerAttrCasing(attrName) {
    return fixKnownAttrCasing(attrName, datepickerKnownAttributes);
}

function setupUnobtrusiveDatepicker(jQueryElement) {
    jQueryElement.datepicker(getAllAttributes(jQueryElement, "data-ui-datepicker-", fixKnownDatepickerAttrCasing));
}

function setupAllUnobtrusiveDatepickerChildrenOf(jQueryElement) {
    jQueryElement.find("[data-ui-datepicker=true]").each(function () {
        setupUnobtrusiveDatepicker($(this));
    });
}

var datepickerKnownAttributes = [
        "buttonImage", "buttonImageOnly", "altField", "altFormat", "appendText", "autoSize", "buttonText",
        "calculateWeek", "changeMonth", "changeYear", "closeText", "constrainInput", "currentText", "dateFormat", "dayNames",
        "dayNamesMin", "dayNamesShort", "defaultDate", "firstDay", "gotoCurrent", "hideIfNoPrevNext", "isRTL", "maxDate",
        "minDate", "monthNames", "monthNamesShort", "navigationAsDateFormat", "nextText", "numberOfMonths", "prevText",
        "selectOtherMonths", "shortYearCutoff", "showAnim", "showOn", "showOptions", "showOtherMonths", "showWeek",
        "stepMonths", "weekHeader", "yearRange", "yearSuffix"
        ];

