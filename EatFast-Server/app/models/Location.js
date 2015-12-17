var mongoose = require('mongoose');

var locationSchema = mongoose.Schema({
    Name : String,
    Address: String,
    PhoneNumber: String,
    Foods: Array
});

module.exports = mongoose.model('Location', locationSchema);
