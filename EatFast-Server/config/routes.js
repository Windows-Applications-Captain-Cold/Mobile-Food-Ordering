var path = require('path'),
    express = require('express'),
    HTTPStatus = require('http-status'),
    User = require('../app/models/User.js');

module.exports = function (app, dbRequester, passport) {
    app.post('/api/signup', function (req, res, next) {
        //console.log("Registering user:");
        //console.log(req.body);
        passport.authenticate('local-signup', function (err, user, next) {
            if (err) {
                res.send(HTTPStatus.BAD_REQUEST);
            }
            if (!user) {
                res.send(HTTPStatus.BAD_REQUEST);
            }
            else {
                res.send(HTTPStatus.OK);
            }
        })(req, res, next);
    });

    app.post('/api/login', function(req, res, next) {
        passport.authenticate('local_login', function(err, user, info) {
            if (err)
            {
                res.send(HTTPStatus.BAD_REQUEST);
            }

            /*if (!user)
            {
                res.send(HTTPStatus.BAD_REQUEST);
            }*/
        })(req, res, next);

        dbRequester.users.get({Email: req.body.Email})
            .then(function (user) {
                if (!user) {
                    res.send(HTTPStatus.NOT_FOUND);
                }

                res.send(user);
            });
    });

    app.post('/api/users/update/:id', function(req, res) {
        updateUserInfo(req, res);
    });

    app.get('/api/users/:id', function(req, res) {
        dbRequester.users.getById(req.params.id)
            .then(function (user) {
                if (!user) {
                    res.send(HTTPStatus.NOT_FOUND);
                }

                res.send(user);
            });
    });

    app.get('/api/users/:username', function(req, res) {
        dbRequester.users.get(req.params.username)
            .then(function (users) {
                if (!users) {
                    res.send(HTTPStatus.NOT_FOUND);
                }

                res.send(users);
            });
    });

    app.get('/api/users', function(req, res) {
        dbRequester.users.get(req.body)
            .then(function (users) {
                if (!users) {
                    res.send(HTTPStatus.NOT_FOUND);
                }

                res.send(users);
            });
    });
}

function isLoggedIn(req, res, next) {
    if (req.isAuthenticated()) {
        return next();
    }

    res.send(HTTPStatus.BAD_REQUEST);
}

function updateUserInfo(req, res) {
    var user = User.findOne({_id: req.params.id}, function (err, user) {
        if (err) {
            throw err;
        }
        console.log("USER:");
        console.log(user);
        if (!user) {
            res.send(HTTPStatus.NOT_FOUND);
        }
    });

    User.update({_id: req.params.id}, req.body, function (err, numAffected) {
        console.log('Updated user: ' + req.params._id);
        res.send(HTTPStatus.OK);
    });
}
