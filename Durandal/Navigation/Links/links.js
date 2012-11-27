/*global require, define, window */
define(['durandal/app', 'shell/navigationService'], function (eventAggregator, navigationService) {
    'use strict';
    return {
        go: function (url) {
            navigationService.navigate(url);
        }
    };
});