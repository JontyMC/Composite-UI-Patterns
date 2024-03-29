/*global require, define */
require.config({
    paths: {
        text: 'lib/text',
        durandal: 'lib/durandal',
        ko: 'lib/knockout-2.1.0',
        jquery: 'lib/jquery-1.7.min'
    }
});

define(['durandal/app', 'jquery'], function (app) {
    'use strict';
    app.start().then(function () {
        app.setRoot('shell/shell');
    });
});