/*global require, define, setTimeout */
define(['ko', 'jquery', 'jqueryui'], function (ko, $, $ui) {
    'use strict';
    var updateTabs = function (element, items) {
        var options = {
            show: function (ev, ui) {
                var item = items[ui.index];
                if (item) {
                    item.parent.activateItem(item);
                }
            }
        };
        $(element).tabs(options);
    };

    ko.bindingHandlers.tabs = {
        init: function (element, valueAccessor) {
            var settings = valueAccessor(),
                items = settings.items,
                activeItem = settings.activeItem,
                init = true;

            items.subscribe(function (val) {
                setTimeout(function () {
                    $(element).tabs('destroy');
                    updateTabs(element, val);
                }, 0);
            });

            activeItem.subscribe(function (val) {
                var activeIndex = items.indexOf(val);
                $(element).tabs('select', activeIndex);
            });

            $(element).tabs();

            items.valueHasMutated();
        }
    };
});