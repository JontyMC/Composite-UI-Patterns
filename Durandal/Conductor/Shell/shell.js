/*global require, define */
define(['files/fileEditor', 'workspaces/myWorkspaces', 'search/search'], function (fileEditor, myWorkspaces, search) {
    'use strict';
    return {
        sidebar: myWorkspaces,
        main: fileEditor,
        widget: search
    };
});