/*global require, define */
define(['search/search', 'workspaces/myworkspaces', 'widgetpicker/widgetpicker', 'durandal/viewModel', 'ko'], function (search, myworkspaces, widgetpicker, viewModel, ko) {
    'use strict';
    var vm = {
        activeItem: viewModel.activator(),
        sidebar: myworkspaces,
        widget: search,
        activate: function () {
            vm.activeItem(widgetpicker);
        }
    };

    return vm;
});