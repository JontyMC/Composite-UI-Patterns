/*global require, define */
define(['ko', 'durandal/app'], function (ko, eventAggregator) {
    'use strict';
    function UserModel(id, firstName, lastName) {
        this.id = parseInt(id, 10);
        this.firstName = firstName;
        this.lastName = lastName;
        this.updateDetails = this.updateDetails.bind(this);
    }

    UserModel.prototype.updateDetails = function (firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        eventAggregator.trigger('userDetailsUpdated', this.id);
    };

    return UserModel;
});