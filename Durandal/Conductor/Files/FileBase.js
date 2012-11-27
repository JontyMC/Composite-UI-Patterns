/*global require, define */
define(['ko', 'durandal/app'], function (ko, app) {
    'use strict';
    function FileBase(displayName, toolbar) {
        this.displayName = displayName;
        this.toolbar = toolbar;
        this.isDirty = ko.observable(false);
        this.activate = this.activate.bind(this);
        this.save = this.save.bind(this);
        this.canClose = this.canClose.bind(this);
    }

    FileBase.prototype.activate = function () {
        this.toolbar.setButtons(this.buttons);
    };

    FileBase.prototype.canClose = function () {
        return !this.isDirty();
    };

    FileBase.prototype.save = function () {
        //TO-DO: Save

        this.isDirty(false);
    };

    return FileBase;
});