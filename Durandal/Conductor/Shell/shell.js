/*global require, define */
define(['widgetpicker/widgetpicker', 'workspaces/myworkspaces', 'search/search'], function (widgetpicker, myworkspaces, search) {
    'use strict';
    return {
        sidebar: myworkspaces,
        main: widgetpicker,
        widget: search
    };
});