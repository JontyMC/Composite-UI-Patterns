/*global require, define */
require.config({
    paths: {
        text: 'lib/text',
        durandal: 'lib/durandal',
        ko: 'lib/knockout-2.1.0'
    }
});

define(['durandal/app'], function (app) {
	'use strict';
    app.start().then(function () {
        app.setRoot('shell/shell');
    });
});