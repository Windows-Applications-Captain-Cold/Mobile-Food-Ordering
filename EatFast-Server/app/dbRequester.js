var User = require('./models/User.js');

module.exports = function () {
    function getUserById(id) {
        return new Promise(function (resolve, reject) {
            User.findOne({_id: id}, function (error, user) {
                if (error) {
                    reject(error);
                }

                if (!user) {
                    console.error("No location found whit id: " + id + " !...");
                }

                resolve(user);
            });
        });
    }

    function getUserByParams(params) {
        return new Promise(function (resolve, reject) {
            User.findOne(params, function (error, user) {
                if (error) {
                    reject(error);
                }

                if (!user) {
                    console.error("No location found whit id: " + id + " !...");
                }

                resolve(user);
            });
        });
    }
    return {
        users: {
            getById: getUserById,
            get: getUserByParams
        }
    }
};
