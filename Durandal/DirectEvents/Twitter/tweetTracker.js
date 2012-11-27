/*global require, define, $, ko, setTimeout */
define(['ko', 'twitter/twitterFeed'], function (ko, twitterFeed) {
    'use strict';

    var tweets = ko.observableArray();

    twitterFeed.selectedTweet.subscribe(function (tweet) {
        tweets.push(tweet);
    });

    return {
        tweets: tweets
    };
});