/*global require, define */
define(['twitter/twitterFeed', 'twitter/tweetTracker', 'durandal/viewModel'], function (twitterFeed, tweetTracker, viewModel) {
    'use strict';
    var vm = {
        activeItem: viewModel.activator(),
        sidebar: tweetTracker,
        widget: null,
        activate: function () {
            vm.activeItem(twitterFeed);
        }
    };

    return vm;
});