/*global require, define */
require.config({
    paths: {
        text: 'lib/text',
        durandal: 'lib/durandal',
        ko: 'lib/knockout-2.1.0',
        jquery: 'lib/jqueryui/js/jquery-1.8.2'
    }
});

define(['durandal/app', 'jquery'], function (app) {
    'use strict';
    app.start().then(function () {
        app.setRoot('shell/shell');
    });
});