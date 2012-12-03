/*global require, define, window */
define(['crossroads', 'durandal/app', 'user/Details'], function (crossroads, eventAggregator, UserDetails) {
    'use strict';
    var registerRoutes = function () {
            crossroads.addRoute('/model/user/{id}', function (id, url) {
                id = parseInt(id, 10);
                var viewModel = new UserDetails(id);
                eventAggregator.trigger('navigationOccurred', { url: url, viewModel: viewModel });
            });
        },
        navigate = function (url) {
            window.history.pushState(null, null, url);
            crossroads.parse(url);
        };

    return {
        registerRoutes: registerRoutes,
        navigate: navigate
    };
});