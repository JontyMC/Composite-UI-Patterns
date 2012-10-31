/*global require, define */
require.config({
    paths: {
        "text": "lib/text",
        "durandal": "lib/durandal"
    }
});

define(['durandal/app'], function (app) {
	'use strict';
    app.start().then(function () {
        app.setRoot('shell/shell');
    });
});