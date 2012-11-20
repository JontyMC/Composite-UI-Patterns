/*global require, define, setTimeout */
define(['ko', 'jquery', 'jqueryui'], function (ko, $, $ui) {
    'use strict';
    var init = true;

    ko.bindingHandlers.tabs = {
        update: function (element, valueAccessor) {
            var items = valueAccessor(),
                options = {};

            items().length;

            options.show = function show(ev, ui) {
                var item = items()[ui.index];
                if (item) {
                    item.parent.activateItem(item);
                }
            };
            setTimeout(function () {
                if (!init) {
                    $(element).tabs('destroy');
                }
                init = false;
                $(element).tabs(options);
            }, 0);
        }
    };
});