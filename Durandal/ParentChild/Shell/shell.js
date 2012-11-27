/*global require, define */
define(['user/Details'], function (UserDetails) {
    'use strict';
    return {
        activeItem: new UserDetails("Remedy", "Malahide"),
        sidebar: null,
        widget: null
    };
});