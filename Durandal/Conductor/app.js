/*global require, define */
require.config({
	paths: {
		text: 'lib/text',
		durandal: 'lib/durandal',
        jqueryui: 'lib/jqueryui/js/jquery-ui-1.9.1.custom',
        ko: 'lib/knockout-2.1.0',
        jquery: 'lib/jqueryui/js/jquery-1.8.2'
    },
    shim: {
        jqueryui: {
            deps: ['jquery']
        },
        koBindings: {
            deps: ['ko']
        }
    }
});

define(['durandal/app', 'jqueryui', 'koBindings'], function (app) {
	'use strict';
    app.start().then(function () {
        app.setRoot('shell/shell');
    });
});