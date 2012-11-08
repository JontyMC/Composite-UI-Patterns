/*global require, define, setTimeout */
define(['ko', 'jquery', 'jqueryui'], function (ko, $, $ui) {
    'use strict';
    ko.bindingHandlers.tabs = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            ko.applyBindingsToNode(
                element,
                {
                    tabsInner: valueAccessor
                },
                valueAccessor
            );
        }
    };

    ko.bindingHandlers.tabsInner = {
        init: function (element, valueAccessor) {
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $(element).tabs('destroy');
            });
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var options = valueAccessor() || {};

            options.show = function (ev, ui) {
                var item = viewModel.items[ui.index];
                viewModel.activateItem(item);
            };

            setTimeout(function () {
                $(element).tabs(options);
            }, 0);
        }
    };
});