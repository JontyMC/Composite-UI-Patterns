/*global require, define */
define(['user/Details', 'links/links', 'durandal/app', 'durandal/viewModel'], function (UserDetails, links, eventAggregator, viewModel) {
    'use strict';
    var vm = {
        activeItem: viewModel.activator(),
        sidebar: links,
        widget: null
    };

    eventAggregator.on('navigationOccurred', function (message) {
        vm.activeItem(message.viewModel);
    });

    return vm;
});