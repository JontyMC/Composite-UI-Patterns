/*global require, define */
define(['ko'], function (ko) {
    'use strict';
    function FileBase(displayName, toolbar) {
        this.displayName = displayName;
        this.toolbar = toolbar;
        this.isDirty = ko.observable(false);
        this.activate = this.activate.bind(this);
        this.save = this.save.bind(this);
    }

    FileBase.prototype.activate = function () {
        this.toolbar.setButtons(this.buttons);
    };

    FileBase.prototype.save = function () {
        //TO-DO: Save

        this.isDirty(false);
    };

    return FileBase;
});