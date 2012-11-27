/*global require, define */
define(['ko', 'durandal/app', 'user/Edit'], function (ko, windowManager, UserEdit) {
    'use strict';
    function Details(firstName, lastName) {
        this.firstName = ko.observable(firstName);
        this.lastName = ko.observable(lastName);
        this.edit = this.edit.bind(this);
    }

    Details.prototype.edit = function () {
        var editViewModel = new UserEdit(this);
        windowManager.showModal(editViewModel);
    };

    return Details;
});