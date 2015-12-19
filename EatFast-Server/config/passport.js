var localStrategy = require('passport-local').Strategy,
    User = require('../app/models/User.js'),
    HTTPStatus = require('http-status');

module.exports = function (passport) {
   passport.serializeUser(function (user, done) {
       done(null, user.id);
   });

   passport.deserializeUser(function (id, done) {
       User.findById(id, function (err, user) {
           done(err, user);
       })
   });

   passport.use('local-signup', new localStrategy({
       // by default, local strategy uses username and password, we will override with email
       usernameField: 'Email',
       passwordField: 'Password',
       passReqToCallback: true // allows us to pass back the entire request to the callback
   }, function (req, email, password, done) {
       process.nextTick(function () {
           User.findOne({'Email': email}, function (err, user) {
               if (err) {
                   return done(err);
               }

               if (user) {
                   return done(null, false, HTTPStatus.BAD_REQUEST);
               } else {
                   var newUser = new User();
                   newUser.Email = email;
                   newUser.Password = newUser.generateHash(password);
                   newUser.Name = req.body.Name;
                   newUser.Organisation = "";
                   newUser.Team = "";

                   newUser.save(function (err) {
                       if (err) {
                           throw err;
                       }
                       //console.log("saved");
                       return done(null, newUser, HTTPStatus.OK);
                   });

                   //console.log("after save");
               }
           });
       })
   }));

   passport.use('local_login', new localStrategy({
       usernameField: 'Email',
       passwordField: 'Password',
       passReqToCallback: true
   },
    function (req, email, password, done) {
        User.findOne({'Email': email}, function (err, user) {
            if (err) {
                return done(err);
            }

            if (!user) {
                return done(null, false, HTTPStatus.NOT_FOUND);
            }

            if (!user.validatePassword(password)) {
                return done(null, false, HTTPStatus.NOT_FOUND);
            }
            return done(null, user, HTTPStatus.OK);
        });
    }))
}
