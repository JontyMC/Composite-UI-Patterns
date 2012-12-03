/*global require, define */
define(['jquery', 'ko', 'model/user/inMemoryUserRepository', 'shell/navigationService', 'user/add', 'durandal/app', 'durandal/app'], function ($, ko, userRepository, navigationService, UserAdd, windowManager, eventAggregator) {
    'use strict';
    var links = ko.observableArray();

    eventAggregator.on('userAdded', function (userId) {
        links.push('/model/user/' + userId);
    });

    $.map(userRepository.getAll(), function (user) {
        links.push('/model/user/' + user.id);
    });

    function go(link) {
        navigationService.navigate(link);
    }

    function add() {
        var addViewModel = new UserAdd();
        windowManager.showModal(addViewModel);
    }

    return {
        links: links,
        go: go,
        add: add,
        widget: null
    };
});