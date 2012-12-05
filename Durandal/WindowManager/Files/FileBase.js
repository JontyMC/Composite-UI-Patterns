/*global require, define */
define(['ko', 'durandal/app'], function (ko, windowManager) {
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
        if (this.isDirty()) {
            return windowManager.showMessage('Are you sure you want to close?', '', ['Yes', 'No']);
        }
        return true;
    };

    FileBase.prototype.save = function () {
        //TO-DO: Save

        this.isDirty(false);
    };

    return FileBase;
});