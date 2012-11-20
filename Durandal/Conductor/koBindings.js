/*global require, define, setTimeout */
define(['ko', 'jquery', 'jqueryui'], function (ko, $, $ui) {
    'use strict';
    ko.bindingHandlers.tabs = {
        update: function (element, valueAccessor) {
            var items = valueAccessor(),
                options = {};

            options.show = function show(ev, ui) {
                var item = items[ui.index];
                if (item) {
                    item.parent.activateItem(item);
                }
            };
            setTimeout(function () { $(element).tabs(options); }, 0);
        }
    };
});