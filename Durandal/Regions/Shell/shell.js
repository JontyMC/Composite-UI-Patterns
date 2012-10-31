/*global require, define */
define(['whatsnew/whatsnew', 'workspaces/myworkspaces', 'search/search'], function (whatsnew, myworkspaces, search) {
    'use strict';
    return {
        sidebar: myworkspaces,
        main: whatsnew,
        widget: search
    };
});