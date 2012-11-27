/*global require, define */
define(['shell/navigationService', 'links/links', 'durandal/viewModel', 'durandal/app'], function (navigationService, links, viewModel, eventAggregator) {
    'use strict';

    var activator = viewModel.activator(),
        vm = {
            activeItem: activator,
            sidebar: links,
            widget: null,
            activateItem: function (item) {
                activator.activateItem(item);
            }
        };

    navigationService.registerRoutes(vm);

    return vm;
});