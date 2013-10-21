/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery-ui.js" />

(function ($, undefined) {

    $.fn.requireConfirmation = function (message, confirmationFunc) {
        setupConfirmAction($(this), message, confirmationFunc);
    }

    // Require confirmation
    function setupConfirmAction(jQueryElement, message, confirmationFunc) {

        if (!confirmationFunc) {
            confirmationFunc = function (confirmationMessage) {
                return confirm(confirmationMessage);
            }
        }

        var domElement = jQueryElement.get(0);

        if (!jQueryElement.data('ui-require-confirmation_onclick')) {
            jQueryElement.data('ui-require-confirmation_onclick', this.onclick);
            domElement.onclick = function (e) {
                var event = e || window.event;
                var result = confirmationFunc(message);
                if (result) {
                    var originalOnClick = jQueryElement.data('ui-require-confirmation_onclick');
                    if (originalOnClick) {
                        originalOnClick.call(jQueryElement, event || window.event);
                    }
                    return true;
                }
                else {
                    if (event.preventDefault) {
                        event.preventDefault();
                    }
                    else {
                        event.returnValue = false;
                        event.cancelBubble = true;
                    }
                    return false;
                }
            }
        }
    }
})(jQuery);