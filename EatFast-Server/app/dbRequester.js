var Location = require('./models/Location.js');
var Food = require('./models/Food.js');

module.exports = function () {
    function getAllLocations() {
        return new Promise(function (resolve, reject) {
            Location.find({}, function (error, locations) {
                if (error) {
                    reject(error);
                }

                if (!locations) {
                    console.error("There are no locations!...");
                }

                resolve(locations);
            });
        });
    }

    function getLocationById(id) {
        return new Promise(function (resolve, reject) {
            Location.findOne({_id: id}, function (error, location) {
                if (error) {
                    reject(error);
                }

                if (!location) {
                    console.error("No location found whit id: " + id + " !...");
                }

                resolve(location);
            });
        });
    }

    function saveLocation(locationData) {
        return new Promise(function (resolve, reject) {
            location = new Location({
                Name: locationData.Name,
                PhoneNumber: locationData.PhoneNumber,
                Foods: locationData.Foods,
                Address: locationData.Address
            });

            location.save(function (error) {
                if (error) {
                    reject(error);
                }
            });

            resolve(true);
        });
    }

    function getFoods(type) {
        return new Promise(function (resolve, reject) {
            Food.find({Type: type}, function (error, foods) {
                if (error) {
                    reject(error);
                }

                if (!foods) {
                    console.error("There are no locations!...");
                }

                resolve(foods);
            });
        });
    }

    function addFood(foodData) {
        return new Promise(function (resolve, reject) {
            food = new Food({
                Name: foodData.Name,
                Price: foodData.Price,
                Type: foodData.Type,
                Description: foodData.Description,
                ImgSource: foodData.ImgSource
            });

            food.save(function (error) {
                if (error) {
                    reject(error);
                }
            });

            resolve(food);
        });
    }

    function getAllFoods() {
        return new Promise(function (resolve, reject) {
            Food.find({}, function (error, foods) {
                if (error) {
                    reject(error);
                }

                if (!foods) {
                    console.error("There are no locations!...");
                }

                resolve(foods);
            });
        });
    }

    return {
        locations: {
            all: getAllLocations,
            getById: getLocationById,
            save: saveLocation
        },
        foods : {
            get: getFoods,
            add: addFood,
            all: getAllFoods
        }
    }
};
