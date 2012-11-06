/*global require, define, setTimeout */
define(['ko', 'jquery', 'jqueryui'], function (ko, $, $ui) {
    'use strict';
    ko.bindingHandlers.tabBinding = {
        init: function (element, valueAccessor) {
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $(element).tabs("destroy");
            });
        },
        update: function (element, valueAccessor) {
            var options = valueAccessor() || {};
            setTimeout(function () {
                $(element).tabs(options);
            }, 0);
        }
    };
});