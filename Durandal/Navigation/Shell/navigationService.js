/*global require, define, window */
define(['whatsnew/whatsnew', 'twitter/twitterfeed', 'crossroads'], function (whatsnew, twitterfeed, crossroads) {
    'use strict';

    var registerRoutes = function (shell) {
            crossroads.addRoute('whatsnew', function () {
                shell.activateItem(whatsnew);
            });

            crossroads.addRoute('twitterfeed', function () {
                shell.activateItem(twitterfeed);
            });
        },
        navigate = function (url) {
            window.history.pushState(null, null, url);
            crossroads.parse(url);
        };

    return {
        registerRoutes: registerRoutes,
        navigate: navigate
    };
});