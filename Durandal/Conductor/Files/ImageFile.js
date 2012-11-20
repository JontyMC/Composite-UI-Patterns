/*global require, define */
define(['ko', 'extends', 'files/fileBase', 'files/toolbarButtons/SaveButton', 'files/toolbarButtons/DelegateButton'], function (ko, extend, fileBase, SaveButton, DelegateButton) {
    'use strict';
    function ImageFile(parent, displayName, toolbar) {
        this.resize = this.resize.bind(this);
        fileBase.call(this, displayName, toolbar);

        var saveButton = new SaveButton(this),
            resizeButton = new DelegateButton('Resize', this, this.resize),
            cropButton = new DelegateButton('Crop', this, function () { });

        this.buttons = [saveButton, resizeButton, cropButton];
        this.parent = parent;
        this.height = ko.observable(150);
        this.width = ko.observable(150);
    }
    extend(ImageFile, fileBase);

    ImageFile.prototype.resize = function () {
        this.isDirty(true);
        this.height(this.height() + 20);
        this.width(this.width() + 20);
    };

    return ImageFile;
});