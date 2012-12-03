/*global require, define */
require.config({
    baseUrl: '/model/',
    paths: {
        text: 'lib/text',
        durandal: 'lib/durandal',
        ko: 'lib/knockout-2.1.0',
        jquery: 'lib/jquery-1.7.min',
        crossroads: 'lib/crossroads',
        signals: 'lib/signals'
    },
    shim: {
        crossroads: {
            deps: ['signals']
        }
    }
});

define(['durandal/app', 'jquery', 'shell/navigationService'], function (app, $, navigationService) {
    'use strict';
    navigationService.registerRoutes();

    app.start().then(function () {
        app.setRoot('shell/shell');
    });
});