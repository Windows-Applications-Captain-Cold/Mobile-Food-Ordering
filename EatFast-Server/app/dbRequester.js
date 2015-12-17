var Location = require('./models/Location.js');

module.exports = function () {
    /*function createCategory(category) {
        return new Promise(function (reject, resolve) {
            if (!category.Name) {
                reject(new Error("Missing category name!"));
            }

            var category = new ArticleCategory({
                name: category.name,
                 articlesCount: 0
            });

            category.save(function (error) {
                if (error) {
                    reject(error);
                }
            });

            resolve("Category created!"); //TODO: Provide better way
        });
    }

    function getArticleById(id) {
        return new Promise(function (resolve, reject) {
            Article.findOne({_id: id}, function (error, article) {
                if (error) {
                    reject(error);
                }

                if (!article) {
                    console.error('Couldn\'t find any article with id: ' + id);
                }

                resolve(article);
            });
        });
    }*/

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

    return {
        locations: {
            all: getAllLocations,
            getById: getLocationById,
            save: saveLocation
        }
    }
};
