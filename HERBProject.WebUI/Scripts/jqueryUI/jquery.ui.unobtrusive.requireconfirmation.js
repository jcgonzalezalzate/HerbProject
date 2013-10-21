/// <reference path="..\jquery-1.4.4.js" />
/// <reference path="..\jquery-ui.js" />
/// <reference path="jquery.ui.requireconfirmation.js" />
/// <reference path="jquery.ui.unobtrusive.js" />

function setupUnobtrusiveConfirmAction(jQueryElement) {
    var message = jQueryElement.attr("data-ui-require-confirmation");
    if (message == null || message == 'undefined') {
        message = "Are you sure?";
    }
    jQueryElement.requireConfirmation(message);
}

function setupAllUnobtrusiveConfirmActionsChildrenOf(jQueryElement) {
    jQueryElement.find("[data-ui-require-confirmation]").each(function () {
        setupUnobtrusiveConfirmAction($(this));
    });
}
