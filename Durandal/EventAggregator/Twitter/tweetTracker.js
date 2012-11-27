/*global require, define, $, ko, setTimeout */
define(['ko', 'durandal/app'], function (ko, eventAggregator) {
    'use strict';

    var tweets = ko.observableArray();

    eventAggregator.on('selectedTweetChanged', function (tweet) {
        tweets.push(tweet);
    });

    return {
        tweets: tweets
    };
});