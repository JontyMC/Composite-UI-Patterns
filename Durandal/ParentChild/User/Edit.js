/*global require, define */
define(['ko'], function (ko) {
    'use strict';
    function Edit(details) {
        this.details = details;
        this.firstName = ko.observable(details.firstName());
        this.lastName = ko.observable(details.lastName());
        this.save = this.save.bind(this);
        this.close = this.close.bind(this);
    }

    Edit.prototype.save = function () {
        this.details.firstName(this.firstName());
        this.details.lastName(this.lastName());
        this.window.close();
    };

    Edit.prototype.close = function () {
        this.window.close();
    };

    return Edit;
});