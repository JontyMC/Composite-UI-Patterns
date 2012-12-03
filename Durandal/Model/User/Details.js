/*global require, define */
define(['ko', 'durandal/app', 'user/Edit', 'model/user/inMemoryUserRepository', 'durandal/app'], function (ko, windowManager, UserEdit, userRepository, eventAggregator) {
    'use strict';
    function Details(userId) {
        var that = this;
        this.userId = userId;
        this.firstName = ko.observable();
        this.lastName = ko.observable();
        eventAggregator.on('userDetailsUpdated', function () {
            that.refreshUser();
        });
        this.refreshUser = this.refreshUser.bind(this);
        this.activate = this.activate.bind(this);
        this.edit = this.edit.bind(this);
    }

    Details.prototype.refreshUser = function () {
        var user = userRepository.get(this.userId);
        this.firstName(user.firstName);
        this.lastName(user.lastName);
    };

    Details.prototype.activate = function () {
        this.refreshUser();
    };

    Details.prototype.edit = function () {
        var editViewModel = new UserEdit(this.userId);
        windowManager.showModal(editViewModel);
        editViewModel.activate();
    };

    return Details;
});